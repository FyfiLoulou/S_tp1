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
        /// 
        /// </summary>
        /// <param name="nomFichierSauvegarde"></param>
        /// <returns></returns>
        public List<Evaluation> Ajouter(string nomFichierSauvegarde)
        {
            List<Evaluation> list = null;
            try
            {
                listeEvaluations = list = JsonConvert.DeserializeObject<List<Evaluation>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}"));
            }
            catch (FileNotFoundException err)
            {
                Utilitaire.consoleState(true);
                Console.WriteLine("Fichier existe pas: " + err.Message);
                Utilitaire.consoleState(false);
            }
            catch (Exception err)
            {
                Utilitaire.consoleState(true);
                Console.WriteLine("Erreur autre: " + err.Message);
                Utilitaire.consoleState(false);
            }

            return list;
        }
        public bool Sauvegarder(string nomFichierSauvegarde)
        {
            bool isSauvegarde = true;
            try
            {
                File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(listeEvaluations, Formatting.Indented));
            }
            catch (DirectoryNotFoundException err)
            {
                Utilitaire.consoleState(true);
                Console.WriteLine("Dossier existe pas: " + err.Message);
                Utilitaire.consoleState(isSauvegarde = false);
            }
            catch (Exception err)
            {
                Utilitaire.consoleState(true);
                Console.WriteLine("Erreur autre: " + err.Message);
                Utilitaire.consoleState(isSauvegarde = false);
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
