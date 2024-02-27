using Newtonsoft.Json;
using static S_tp1.Utilitaire;

namespace S_tp1
{
    /*
     * Regroupe les médias et s'occupe de la sérialisation de l'objet catalogue
     */
    public class Catalogue
    {

        private const string MESSAGE_ERREUR = "Erreur! 1D10T-6969: Un événement inattendu s'est produit!";


        private static List<Media>? catalogue;

        private string PATH_SOURCE = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";

        // Constructeur par défaut
        public Catalogue()
        {
            catalogue = new List<Media>();
        }

        /// <summary>
        /// Ajoute un objet média dans le catalogue
        /// </summary>
        /// <param name="media">L'objet média à ajouter</param>
        /// <returns>True si le média est ajouté au catalogue, false si le média existe déjà</returns>
        public bool Ajouter(Media media)
        {
            bool isAjouter = false;
            if (!MediaExisteDansCatalogue(media))
            {
                catalogue.Add(media);
                isAjouter = true;
            }
            else if (MediaExisteDansCatalogue(media))
            {
                Console.WriteLine($"Le media {media.GetNom()} existe déjà dans le catalogue et n'a pas pu être ajouté");
            }
            else
            {
                Utilitaire.consoleState(true);
                Console.WriteLine(MESSAGE_ERREUR);
                Utilitaire.consoleState(false);
            }
            return isAjouter;
        }

        /// <summary>
        /// remplace un objet média déjà présent dans le catalogue par un nouvel objet média
        /// </summary>
        /// <param name="mediaToAdd">Le nouvel objet média à ajouter dans le catalogue</param>
        /// <param name="mediaToRemove">L'objet média à remplacer dans le catalogue</param>
        /// <returns>True si l'objet média est remplacé par le nouvel objet média, false autrement</returns>
        public bool Remplacer(Media mediaToAdd, Media mediaToRemove)
        {
            string messageRetour;
            bool isRemplace = false;

            // mediaToAdd n'est pas dans le catalogue et mediaToRemove y est
            // on doit ajouter le nouvel objet média dans le catalogue et retirer le média à remplacer
            if (!(MediaExisteDansCatalogue(mediaToAdd)) && MediaExisteDansCatalogue(mediaToRemove))
            {
                isRemplace = true;
                messageRetour = $"Le media {mediaToAdd.GetNom()} a été ajouté au catalogue et le media {mediaToRemove.GetNom()} a été supprimé";
                this.Supprimer(mediaToRemove);
                this.Ajouter(mediaToAdd);
            }
            else if (!(MediaExisteDansCatalogue(mediaToRemove)))
            {
                // Le média à remplacer n'est pas dans le catalogue
                messageRetour = $"Le media {mediaToRemove.GetNom()} n'existe pas dans le catalogue et ne peut donc pas être supprimé!";
            }
            else if (MediaExisteDansCatalogue(mediaToAdd))
            {
                // Le media à ajouter existe déjà dans le catalogue
                messageRetour = $"Le media {mediaToAdd.GetNom()} existe déjà dans le catalogue et ne peut donc pas être ajouté!";
            }
            else
            {
                // Erreur inattendue
                Utilitaire.consoleState(true);
                messageRetour = MESSAGE_ERREUR;
                Utilitaire.consoleState(false);
            }

            // Message de retour dans la console
            Console.WriteLine(messageRetour);

            return isRemplace;
        }

        /// <summary>
        /// Supprime le media passé en paramètre du catalogue
        /// </summary>
        /// <param name="media">L'objet media à supprimer</param>
        /// <returns>True si le media a été supprimé, false si le media n'a pas été supprimé</returns>
        public bool Supprimer(Media media)
        {
            bool isSupprime = false;
            if (MediaExisteDansCatalogue(media))
            {
                catalogue.Remove(media);
                if (!MediaExisteDansCatalogue(media))
                {
                    Console.WriteLine($"Le media {media} a ete supprime!");
                    isSupprime = true;
                }
                else
                {
                    Utilitaire.consoleState(true);
                    Console.WriteLine(MESSAGE_ERREUR);
                    Utilitaire.consoleState(false);
                }
            }
            else
            {
                Utilitaire.consoleState(true);
                Console.WriteLine(MESSAGE_ERREUR);
                Utilitaire.consoleState(false);
            }

            return isSupprime;
        }

        /// <summary>
        /// Supprime tous les médias du catalogue
        /// </summary>
        /// <returns> True si le catalogue a bien été supprimé, false autrement</returns>
        public bool Supprimer()
        {
            catalogue.Clear();
            bool isSupprime = true;
            string messageRetour = "Le catalogue a été complètement supprimé!";
            if (catalogue.Count != 0)
            {
                isSupprime = false;
                Utilitaire.consoleState(true);
                messageRetour = MESSAGE_ERREUR;
                Utilitaire.consoleState(false);
            }

            Console.WriteLine(messageRetour);
            return isSupprime;
        }

        /// <summary>
        /// Lit in fichier JSON du chemin spécifié et ajoute les médias à la liste des médias du catalogue
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le chemin du fichier JSON</param>
        /// <returns>Le catalogue rempli d'objet média</returns>
        public List<Media> Ajouter(string nomFichierSauvegarde)
        {
            List<Media> list = null;
            try
            {
                catalogue = list = JsonConvert.DeserializeObject<List<Media>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}"));
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

        /*
         * sauvegarde le catalogue et le sérialise dans un fichier JSON
         * 
         * @param nomFichierSauvegarde -> le nom du fichier JSON de sauvegarde YOFO
         */
        public bool Sauvegarder(string nomFichierSauvegarde)
        {
            bool isSauvegarde = true;
            try
            {
                File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(catalogue, Formatting.Indented));
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

        // Méthode Override

        public override string ToString()
        {
            string retVal = "";
            foreach (Media media in catalogue)
            {
                retVal += $"{media.ToString()} \n\n";
            }
            return retVal;
        }


        // Méthodes ajoutées

        /*
         * Vérifie que le media en paramèter existe dans le catalogue
         * 
         * @return -> retourne vrai si le media existe dans le catalogue
         */
        public bool MediaExisteDansCatalogue(Media media)
        {
            return catalogue.Contains(media);
        }

        /*
         * @return -> retourne le catalogue
         */
        public List<Media>? getCatalogue() { return catalogue; }

        public Media GetMedia(string id)
        {
            Console.WriteLine(id);
            return catalogue.Where(m => m.GetNom() == id).First();
        }

    }


}

