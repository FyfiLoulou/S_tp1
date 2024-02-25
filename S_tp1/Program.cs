using static S_tp1.Role;
using Newtonsoft.Json;

namespace S_tp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web\n");
            

            Catalogue catalogue = new Catalogue();
            CatalogueUtilisateur catalogueUtilisateur = new CatalogueUtilisateur();
            CatalogueEvaluation catalogueEvaluation = new CatalogueEvaluation();


            Media test = new Media("testLOL", Types.POP, 1001032, 10, "ads", "asddsa", "asd", new List<Evaluation>(), "apap", "1132sad");
            Media test2 = new Media("testLOL2");
            Media test3 = new Media("testLOL3");

            Utilisateur johnyTest = new Utilisateur("JohnyX", "abc123", "Test", "Johny", Role.TECHNICIEN);
            Utilisateur bob = new Utilisateur("bob", "bob", "bob", "bob", Role.ADMIN);
            Utilisateur johnyTest2 = new Utilisateur("JohnyX2", "abc123", "Test", "Johny", Role.UTILISATEUR);

            catalogue.Ajouter(test);
            catalogue.Ajouter(test2);
            catalogue.Ajouter(test3);

            catalogueUtilisateur

            johnyTest.AjouterEvaluation(test, 1);
            johnyTest.AjouterEvaluation(test2, 3);

            catalogue.Sauvegarder("test.json");

            Console.WriteLine(catalogue.getCatalogue().Count);

            
            
            catalogue.Sauvegarder();
            
        }
    }
}