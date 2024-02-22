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
            return true;
        }

        /*
         * remplace un media passé en paramètre par un autre aussi passé en paramètre
         * 
         * @param mediaToAdd -> l'identifiant unique du media à ajouter
         * @param mediaToRemove -> l'identifiant unique du media à remplacer
         * @return -> retourne vrai si le media a bel et bien été remplacé
         */
        public bool Remplacer(Media mediaToAdd, Media mediaToRemove)
        {
            return true;
        }

        /*
         * supprime le media passé en paramètre du catalogue
         * 
         * @param media -> l'identifiant unique du media à supprimer
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
         * @param nomFichierSauvegarde -> le nom du fichier JSON de sauvegarde YOFO
         */
        public void Sauvegarder(Media media)
        {
            
        }
        
        public override string ToString()
        {
            return "singe :)";
        }

    }
}

