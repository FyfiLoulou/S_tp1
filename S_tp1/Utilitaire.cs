namespace S_tp1
{
    public class Utilitaire
    {
        private Catalogue catalogue;
        private CatalogueUtilisateur catalogueUtilisateur;
        private CatalogueEvaluation catalogueEvaluation;

        public Utilitaire (Catalogue catalogue, CatalogueUtilisateur catalogueUtilisateur, CatalogueEvaluation catalogueEvaluation)
        {
            this.catalogue = catalogue;
            this.catalogueUtilisateur = catalogueUtilisateur;
            this.catalogueEvaluation = catalogueEvaluation;
        }


        /*
         * Change la couleur du message dans la console pour les erreurs
         */
        public static void consoleState(bool isError)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.White;
        }



        public void deserializer(string pathMedia, string pathUtilisateur, string pathEvaluation) {
            catalogue.Ajouter(pathMedia);
            catalogueUtilisateur.Ajouter(pathUtilisateur);

            catalogueEvaluation?.Ajouter(pathEvaluation).ForEach((eval)=>{
                catalogue.GetMedia(eval.Media.GetNom())?.AjouterEvaluation(eval);
                catalogueUtilisateur.GetUtilisateur(eval.Utilisateur.Pseudo)?.AjouterEvaluation(eval);
            });

            Console.WriteLine("cm: " + catalogue.getCatalogue().Count);
            Console.WriteLine("cu: " + catalogueUtilisateur.GetUtilisateurs().Count);
            Console.WriteLine("ce: " + catalogueEvaluation.GetEvaluations().Count);
            Console.WriteLine(catalogue.ToString());
            Console.WriteLine(catalogueUtilisateur.ToString());
            Console.WriteLine(catalogueEvaluation.ToString()); ; ;


        }


    }
}