using Newtonsoft.Json;

namespace S_tp1
{
    public class CatalogueEvaluation
    {
        private List<Evaluation> listeEvaluations;

        public CatalogueEvaluation()
        {
            listeEvaluations = new List<Evaluation>;
        }

        public bool ajouter(string nomFichierSauvegarde)
        {
            bool isAjoute = true;
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
                Console.WriteLine($"Erreur: {err.Message}")
                consoleState(isAjoute = false);
            }

            return true;
        }
        public bool sauvegarder(string nomFichierSauvegarde)
        {

            return true;
        }



    }
}
