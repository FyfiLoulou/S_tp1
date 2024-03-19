using Newtonsoft.Json;

namespace S_tp1
{
    public class CatalogueEvaluation
    {

        private string PATH_SOURCE = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";

        private List<Evaluation> listeEvaluations;

        public CatalogueEvaluation()
        {
            listeEvaluations = new List<Evaluation>();
        }
        /// <summary>
        /// Retourne une liste de toutes les évaluations
        /// </summary>
        /// <returns>Une liste évaluation</returns>
        public List<Evaluation> GetEvaluations() { return listeEvaluations; }

        /// <summary>
        /// Ajoute une évaluation dans la liste d'évaluations
        /// </summary>
        /// <param name="eval">L'évaluation à ajouter</param>
        /// <remarks>
        /// Cette fonction ajoute une évaluation dans la liste d'évaluations et met à jour l'objet média
        /// et l'objet utilisateur avec la nouvelle évaluation.
        /// </remarks>
        public void AjouterEvaluation(Evaluation eval)
        {
            eval.Media.AjouterEvaluation(eval);
            eval.Utilisateur.AjouterEvaluation(eval);
            listeEvaluations.Add(eval);
        }

        /// <summary>
        /// Lit une liste d'évaluations d'un fichier JSON, si le nom du fichier n'existe pas, erreur par défaut
        /// </summary>
        /// <param name="nomFichierSauvegarde"><Le nom du fichier à lire/param>
        /// <returns>Une liste d'évaluations</returns>
        public List<Evaluation> Ajouter(string nomFichierSauvegarde)
        {
            List<Evaluation> list = null;
            listeEvaluations = list = JsonConvert.DeserializeObject<List<Evaluation>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}"));
            return list;
        }

        /// <summary>
        /// Sauvegarde la liste d'évaluations dans un fichier JSON
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le nom du fichier de sauvegarde</param>
        /// <returns>True si le sauvegarde est réussi, false autrement</returns>
        /// <exception cref="DirectoryNotFoundException">Lancée si le dossier de sauvegarde n'existe pas</exception>
        /// <exception cref="Exception">Lancée en cas d'erreur inattendue</exception>
        public bool Sauvegarder(string nomFichierSauvegarde)
        {
            bool isSauvegarde = true;
            try
            {
                File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(listeEvaluations, Formatting.Indented));
            }
            catch (DirectoryNotFoundException err)
            {
                Console.WriteLine("Dossier existe pas: " + err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine("Erreur autre: " + err.Message);
            }
            return isSauvegarde;
        }

        public override string ToString()
        {
            string retVal = "";
            foreach (Evaluation evaluation in listeEvaluations)
            {
                retVal += $"{evaluation.ToString()} \n\n";
            }
            return retVal;
        }


    }
}
