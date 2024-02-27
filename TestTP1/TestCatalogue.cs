using S_tp1;

namespace TestTP1
{
    public class TestCatalogue
    {
        Catalogue catalogue;



        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
        }

        [Test]
        public void TestConstructeur()
        {
            //TODO
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void TestAjouterMediaEnParam()
        {
            //Acteurs
            Media m = new Media();
            //Actions
            catalogue.Ajouter(m);
            //Assertions
            Assert.That(catalogue.getCatalogue().Contains(m), Is.True);
        }

        [Test]
        public void testAjouterFichierEnParam()
        {
            //Acteurs
            string nomDeFichier = "s_test_catalogue.json";
            //Actions
            catalogue.Ajouter(nomDeFichier);
            //Assertions
            Assert.That(catalogue.getCatalogue().Count(), Is.EqualTo(4));
        }

        [Test]
        public void TestSauvegarder()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void TestSupprimerUnFichier()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void TestSupprimerUnMedia()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        public void TestRemplacer()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        public void TestToString()
        {
            //Acteurs

            //Actions

            //Assertions
        }
    }
}
