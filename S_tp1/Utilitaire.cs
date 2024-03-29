namespace S_tp1
{
    public class Utilitaire
    {
       /* private Catalogue catalogue;
        private CatalogueUtilisateur catalogueUtilisateur;
        private CatalogueEvaluation catalogueEvaluation;

        public Utilitaire(Catalogue catalogue, CatalogueUtilisateur catalogueUtilisateur, CatalogueEvaluation catalogueEvaluation)
        {
            this.catalogue = catalogue;
            this.catalogueUtilisateur = catalogueUtilisateur;
            this.catalogueEvaluation = catalogueEvaluation;
        }

        /// <summary>
        /// Désérialise les données à partir des fichiers spécifiés et remplie les catalogues média, userId et évaluation
        /// </summary>
        /// <param name="pathMedia">Le chemin du fichier contenant les données de média</param>
        /// <param name="pathUtilisateur">Le chemin du fichier contenant les données d'userId</param>
        /// <param name="pathEvaluation">Le chemin du fichier contenant les données d'évaluation</param>
        public void deserializer(string pathMedia, string pathUtilisateur, string pathEvaluation)
        {
            // Ajoute les médias à partir du fichier de sauvegarde
            //catalogue.Ajouter(pathMedia);

            // Ajoute les utilisateurs à partir du fichier de sauvegarde
            catalogueUtilisateur.Ajouter(pathUtilisateur);

            // Ajoute les évaluations
            catalogueEvaluation.Ajouter(pathEvaluation).ForEach((eval) =>
            {
                MediaId m = catalogue.GetMedia(eval.MediaId.Id);
                UserId u = catalogueUtilisateur.GetUtilisateur(eval.UserId.IdentifiantUnique);

                // Ajoute chaque évaluations associée à son média correspondant dans le catalogue média
                m?.AjouterEvaluation(eval);
                // Ajoute chaque évaluations associée à son userId correspondant dans le catalogue userId
                u?.AjouterEvaluation(eval);
            });

            // TODO -> à supprimer?
            /*
            Console.WriteLine("cm: " + catalogue.getCatalogue().Count);
            Console.WriteLine("cu: " + catalogueUtilisateur.GetUtilisateurs().Count);
            Console.WriteLine("ce: " + catalogueEvaluation.GetEvaluations().Count);
            Console.WriteLine("\n\nCatalogue média");
            Console.WriteLine(catalogue.ToString());
            Console.WriteLine("\n\nCatalogue Utilisateurs");
            Console.WriteLine(catalogueUtilisateur.ToString());
            Console.WriteLine("\n\nCatalogue Evaluation");
            Console.WriteLine(catalogueEvaluation.ToString());
            
        }
*/

    }
}