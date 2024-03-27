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
        /// et l'objet userId avec la nouvelle évaluation.
        /// </remarks>
        /*public void AjouterEvaluation(Evaluation eval)
        {
            eval.MediaId.AjouterEvaluation(eval);
            eval.UserId.AjouterEvaluation(eval);
            listeEvaluations.Add(eval);
        }*/

        /// <summary>
        /// Lit une liste d'évaluations d'un fichier JSON, try catch non inclus
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
        /// Sauvegarde la liste d'évaluations dans un fichier JSON, try catch non inclus
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le nom du fichier de sauvegarde</param>
        /// <returns>True si le sauvegarde est réussi, false autrement</returns>
        public bool Sauvegarder(string nomFichierSauvegarde)
        {
            bool isSauvegarde = true;
            File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(listeEvaluations, Formatting.Indented));
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
