using Newtonsoft.Json;

namespace S_tp1
{
    public class CatalogueEvaluation
    {

        private string PATH_SOURCE = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private List<Evaluation> listeEvaluations;

        public CatalogueEvaluation() {

        }

        public bool ajouter(string nomFichierSauvegarde) {

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
                consoleState(true);
                Console.WriteLine("Dossier existe pas: " + err.Message);
                consoleState(isSauvegarde = false);
            }
            catch (Exception err)
            {
                consoleState(true);
                Console.WriteLine("Erreur autre: " + err.Message);
                consoleState(isSauvegarde = false);
            }
            return isSauvegarde;
        }



        /*
        * Change la couleur du message dans la console pour les erreurs
        */
        private void consoleState(bool isError)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.White;
        }

    }
}
