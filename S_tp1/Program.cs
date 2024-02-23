namespace S_tp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web");

            Catalogue catalogue = new Catalogue();

            Media test = new Media("testLOL");

            catalogue.Ajouter(test);
            Console.WriteLine(test.GetIdentifiantMedia());

            Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
            Console.WriteLine(catalogue.getCatalogue().Count);

            catalogue.Sauvegarder();



        }
    }
}