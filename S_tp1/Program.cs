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

            Media test = new Media("Smooth Criminal", Types.POP, 1001032, 10, "Micheal Jackson", "Micheal Jakson", "Path extrait",  "Path full", "Path image");
            Media test2 = new Media("heart shaped box", Types.ROCK, 11032, 120, "Nirvana", "Nirvana", "Path extrait",  "Path full", "Path image");
            Media test3 = new Media("Imagine", Types.CLASSIQUE, 10, 1120, "John Lennon", "John Lennon", "Path extrait", "Path full", "Path image");
            Media test4 = new Media("Smooth Criminal", Types.POP, 1001032, 10, "Micheal Jackson", "Micheal Jackson", "Path extrait",  "Path full", "Path image");

            Utilisateur felix = new Utilisateur("FB", "abc123", "Blanchette", "Félix", Role.TECHNICIEN);
            Utilisateur maek = new Utilisateur("ML", "abc123", "Lorman", "Maëk", Role.ADMIN);
            Utilisateur lcb = new Utilisateur("LCB", "abc123", "Biron", "Louis-charles", Role.UTILISATEUR);

            //affichage utilisateurs
            Console.WriteLine("=========================================================");
            Console.WriteLine("Affichage des utilisateurs:\n\n");
            Console.WriteLine(felix.ToString() + "\n\n" + maek.ToString() + "\n\n" + lcb.ToString());
            Console.WriteLine("=========================================================");


            Evaluation ev1 = new Evaluation(maek, test2, 100);
            Evaluation ev2 = new Evaluation(felix, test, 11);
            Evaluation ev3 = new Evaluation(felix, test3, 121);
            Evaluation ev4 = new Evaluation(lcb, test, 120);

            catalogue.Ajouter(test);
            catalogue.Ajouter(test2);
            catalogue.Ajouter(test3);

            Console.WriteLine("Tentative d'ajouter un media qui est déja dans le catalogue:\n");
            catalogue.Ajouter(test4);
            Console.WriteLine("Ajout des utilisateurs das la liste des utilisateurs");

            catalogueUtilisateur.AjouterListe(felix);
            catalogueUtilisateur.AjouterListe(lcb);
            catalogueUtilisateur.AjouterListe(maek);
            Console.WriteLine("Ajout des evaluations dans la liste des evaluations");

            catalogueEvaluation.AjouterEvaluation(ev1);
            catalogueEvaluation.AjouterEvaluation(ev2);
            catalogueEvaluation.AjouterEvaluation(ev3);
            catalogueEvaluation.AjouterEvaluation(ev4);

            Console.WriteLine("sauvegarde/seréalisation");
            catalogue.Sauvegarder(pathMedias);
            catalogueUtilisateur.Sauvegarder(pathUtilisateurs);
            catalogueEvaluation.Sauvegarder(pathEvaluations);



            Console.WriteLine("déseréalisation");
            utilitaire.deserializer(pathMedias, pathUtilisateurs, pathEvaluations);


        }
    }
}