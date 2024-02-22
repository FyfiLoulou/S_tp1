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

            catalogue.Sauvegarder();



        }
    }
}