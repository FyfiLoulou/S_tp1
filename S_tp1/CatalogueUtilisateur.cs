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
        /// Ajoute un nouvel userId dans la liste d'utilisateurs
        /// </summary>
        /// <param name="utilisateur">L'userId à ajouter</param>
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
        /// Lit un fichier JSON et retourne une liste d'objet userId
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le nom du fichier à lire</param>
        /// <returns>Une liste d'objet userId</returns>
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
                Console.WriteLine("Fichier existe pas: " + err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine("Erreur autre: " + err.Message);
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
            foreach (Utilisateur u in listeUtilisateurs)
            {
                retVal += $"{u.ToString()} \n\n";
            }
            return retVal;
        }

        /// <summary>
        /// Récupère un userId à partir de son id
        /// </summary>
        /// <param name="id">l'id (pseudo) de l'userId à récupérer</param>
        /// <returns>L'userId correspondant à l'id spécifié</returns>
        public Utilisateur GetUtilisateur(string id)
        {
            // Recherche de l'userId dans la liste des utilisateurs
            // en fonction de son pseudo.
            return listeUtilisateurs.Where(u => u.Id == id).Count()>0 ? listeUtilisateurs.Where(u => u.Id == id).First() : null;
        }

    }
}
