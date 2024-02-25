using Newtonsoft.Json;

namespace S_tp1
{
    public class CatalogueEvaluation
    {

        private string PATH_SOURCE = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private List<Evaluation> listeEvaluations;

        public CatalogueEvaluation()
        {
            listeEvaluations = new List<Evaluation>();
        }

        public void ajouterList(Evaluation evaluation) {
            listeEvaluations.Add(evaluation);
        }

        public bool ajouter(string nomFichierSauvegarde)
        {
            /*bool isAjoute = true;
            try
            {
                listeEvaluations.JsonConvertDeserializeObject<List<Evaluation>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomDeFichierSauvegarde}"))
            }
            catch (FileNotFoundException e)
            {
                consoleState(true);
                Console.WriteLine($"Fichier existe pas: {err.Message}");
                consoleState(isAjoute = false);
            }
            catch (Exception err)
            {
                consoleState(true);
                Console.WriteLine($"Erreur: {err.Message}");
                consoleState(isAjoute = false);
            }
            */
            return true;
        }
        public bool sauvegarder(string nomFichierSauvegarde) {
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




    }
}
