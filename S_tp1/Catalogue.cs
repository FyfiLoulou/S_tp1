namespace S_tp1
{
    /*
     * Regroupe les médias et s'occupe de la sérialisation des objets
     */
    public class Catalogue
    {
        // Constructeur par défaut
        public Catalogue() { }

        /*
         * Permet d'ajouter un media 
         */
        public bool ajouter(string identifiantMedia)
        {
            return true;
        }

        public bool remplacer(string identifiantMediaToAdd, string identifiantMediaToRemove)
        {
            return true;
        }

        public bool supprimer(string identifiantMedia) { return true; }

        public bool supprimer() { return true; }

        public string sauvegarder(string nomFichierSauvegarde)
        {
            return "";
        }

    }
}

