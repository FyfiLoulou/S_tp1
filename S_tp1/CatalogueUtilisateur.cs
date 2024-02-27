using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace S_tp1
{
    public class CatalogueUtilisateur
    {

        private string PATH_SOURCE = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";

        private List<Utilisateur> listeUtilisateurs;

        public CatalogueUtilisateur()
        {
            listeUtilisateurs = new List<Utilisateur>();
        }

        /// <summary>
        /// Ajoute un nouvel utilisateur dans la liste d'utilisateurs
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à ajouter</param>
        public void AjouterListe(Utilisateur utilisateur)
        {
            listeUtilisateurs.Add(utilisateur);
        }

        /// <summary>
        /// Retourne la liste des utilisateurs
        /// </summary>
        /// <returns>La liste des utilisateurs</returns>
        public List<Utilisateur> GetUtilisateurs() { return listeUtilisateurs; }

        /// <summary>
        /// Lit un fichier JSON et retourne une liste d'objet utilisateur
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le nom du fichier à lire</param>
        /// <returns>Une liste d'objet utilisateur</returns>
        /// <exception cref="FileNotFoundException"> Lancée lorsque le fichier n'est pas trouvé</exception>
        /// <exception cref="Exception"> Lancée en cas d'erreur inattendue </exception>
        public List<Utilisateur> Ajouter(string nomFichierSauvegarde)
        {
            List<Utilisateur> list = null;
            try
            {
                listeUtilisateurs = list = JsonConvert.DeserializeObject<List<Utilisateur>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}"));
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

        /// <summary>
        /// Sauvegarde la liste des utilisateurs dans un fichier JSON
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le nom du fichier de sauvegarde</param>
        /// <returns>True si la sauvegarde est réussi, false autrement</returns>
        /// <exception cref="">Lancée si le dossier de sauvegarde n'existe pas</exception>
        /// <exception cref="Exception"> Lancée en cas d'erreur inattendue</exception>
        public bool Sauvegarder(string nomFichierSauvegarde)
        {
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

        public override string ToString()
        {
            string retVal = "";
            foreach (Utilisateur u in listeUtilisateurs)
            {
                retVal += $"{u.ToString()} \n\n";
            }
            return retVal;
        }

        public Utilisateur GetUtilisateur(string id)
        {
            return listeUtilisateurs.Where(u => u.Pseudo == id).First();
        }

    }
}
