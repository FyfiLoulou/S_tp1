using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace S_tp1
{
    public class CatalogueUtilisateur
    {

        private string PATH_SOURCE = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private List<Utilisateur> listeUtilisateurs;

        public CatalogueUtilisateur() {
            listeUtilisateurs = new List<Utilisateur>();
        }

        public void ajouterListe(Utilisateur utilisateur) {
            listeUtilisateurs.Add(utilisateur);
        }

    public bool ajouter(string nomFichierSauvegarde) {

        return true;
    }
    public bool sauvegarder(string nomFichierSauvegarde) {
            bool isSauvegarde = true;
            try
            {
                File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(listeUtilisateurs, Formatting.Indented));
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
