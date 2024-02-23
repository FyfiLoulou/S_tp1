using Newtonsoft.Json;

namespace S_tp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web\n");
            

            Catalogue catalogue = new Catalogue();

            Media test = new Media("testLOL", Media.Types.POP, 1001032, 10, "ads", "asddsa", "/s/s/s//s", new List<Evaluation>(), "a/f/f/f/f", "1132sad");
            Media test2 = new Media("testLOL2");
            Media test3 = new Media("testLOL3");

            catalogue.Ajouter(test);
            catalogue.Ajouter(test2);
            catalogue.Ajouter(test3);
            Console.WriteLine(catalogue.getCatalogue().Count);

            catalogue.Sauvegarder("test.json");
            

        }
    }
}