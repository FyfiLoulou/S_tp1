using System.Net.Http.Headers;

namespace S_tp1
{
    /*
     * Regroupe les médias et s'occupe de la sérialisation de l'objet catalogue
     */
    public class Catalogue
    {
        //TODO: 20-02-2024 -> définir le path du fichier de sauvegarde
        private const string PATH_FICHIER_SAUVEGARDE = "path du fichier";

        //TODO: 20-02-2024 -> maybe singleton, getInstance et le constructeur private maybe
        private static List<Media>? catalogue;


        // Constructeur par défaut
        public Catalogue()
        {
            catalogue = new List<Media>();
        }

        /*
         * ajoute un media passé en paramètre dans le catalogue
         * 
         * @param identifiantMedia -> l'identifiant unique du media à ajouter
         * @return -> retourne vrai si le media a bel et bien été ajouter au catalogue
         */
        public bool Ajouter(Media media)
        {
            bool ajoute = false;
            if (!(mediaExisteDansCatalogue(media)))
            {
                catalogue.Add(media);
                ajoute = true;
            }
            return ajoute;
        }

        /*
         * remplace un media passé en paramètre par un autre aussi passé en paramètre
         * 
         * @param identifiantMediaToAdd -> l'identifiant unique du media à ajouter
         * @param identifiantMediaToRemove -> l'identifiant unique du media à remplacer
         * @return -> retourne vrai si le media a bel et bien été remplacé
         */
        public bool Remplacer(Media mediaToAdd, Media mediaToRemove)
        {
            return true;
        }

        /*
         * supprime le media passé en paramètre du catalogue
         * 
         * @param identifiantMedia -> l'identifiant unique du media à supprimer
         * @return -> retourne vrai si le media a bel et bien supprimé
         */
        public bool Supprimer(Media media) { return true; }

        /*
         * supprime le catalogue au complet
         * 
         * @return -> retourne vrai si le catalogue est supprimé correctement
         */
        public bool Supprimer() { return true; }

        /*
         * sauvegarde le catalogue et le sérialise dans un fichier JSON
         * 
         * @param nomFichierSauvegarde -> le nom du fichier JSON de sauvegarde
         */
        public void Sauvegarder(string nomFichierSauvegarde)
        {

        }

        // Méthode Override
        public override string ToString()
        {
            return ":)";
        }


        // Méthodes ajoutées

        private bool mediaExisteDansCatalogue(Media media)
        {
            bool retVal = !true; // GÉNIE!
            foreach (Media m in catalogue)
            {
                if (m.Equals(media))
                {
                    retVal = true;
                }
            }
            return retVal;
        }
    }
}

