using static S_tp1.Role;
using Newtonsoft.Json;

namespace S_tp1
{
    internal class Program
    {

        private const string pathMedias = "s_medias.json",
        pathUtilisateurs = "s_utilisateurs.json",
        pathEvaluations = "s_evalutations.json";
        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web\n");
            

            Catalogue catalogue = new Catalogue();
            CatalogueUtilisateur catalogueUtilisateur = new CatalogueUtilisateur();
            CatalogueEvaluation catalogueEvaluation = new CatalogueEvaluation();
            Utilitaire utilitaire = new Utilitaire(catalogue, catalogueUtilisateur, catalogueEvaluation);

            Media test = new Media("testLOL", Types.POP, 1001032, 10, "ads", "asddsa", "asd", new List<Evaluation>(), "apap", "1132sad");
            Media test2 = new Media("testLOL23", Types.CONCEPTUALSYNTH, 11032, 120, "adsdasdasdasdasdasd", "asd12312dsa", "asd", new List<Evaluation>(), "ap123123ap", "1132sad");
            Media test3 = new Media("testLOL123123", Types.CLASSIQUE, 10, 1120, "adsasdasd", "asd1231231231231231dsa", "asd", new List<Evaluation>(), "apap", "1132s31123123ad");

            Utilisateur j = new Utilisateur("JohnyX", "abc123", "Test", "Johny", Utilisateur.RoleUtilisateur.TECHNICIEN);
            Utilisateur bob = new Utilisateur("bob", "bob", "bob", "bob", Utilisateur.RoleUtilisateur.ADMIN);
            Utilisateur j2 = new Utilisateur("JohnyX2", "abc123", "Test", "Johny", Utilisateur.RoleUtilisateur.UTILISATEUR);
            Console.WriteLine(j);
            j.IdentifiantUnique = "allo";
            Console.WriteLine(j);
            /*

            Evaluation ev1 = new Evaluation(bob, test2, 100);
            Evaluation ev2 = new Evaluation(j, test, 11);
            Evaluation ev3 = new Evaluation(j, test3, 121);
            Evaluation ev4 = new Evaluation(j2, test, 120);

            catalogue.Ajouter(test);
            catalogue.Ajouter(test2);
            catalogue.Ajouter(test3);

            catalogueUtilisateur.AjouterListe(j);
            catalogueUtilisateur.AjouterListe(j2);
            catalogueUtilisateur.AjouterListe(bob);

            catalogueEvaluation.AjouterList(ev1);
            catalogueEvaluation.AjouterList(ev2);
            catalogueEvaluation.AjouterList(ev3);
            catalogueEvaluation.AjouterList(ev4);


            catalogue.Sauvegarder(pathMedias);
            catalogueUtilisateur.Sauvegarder(pathUtilisateurs);
            catalogueEvaluation.Sauvegarder(pathEvaluations);

            utilitaire.deserializer(pathMedias, pathUtilisateurs, pathEvaluations);

            */
        }
    }
}