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
        public void testConstructeur()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void etantDonneAjouterUnMedia_quandAjouterUnMedia_alorsUnMediaDansCatalogue()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void etantDonneAjouterUnFichier_quandAjouterUnFichier_alorsCatalogueRempliDeMedia()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void testSauvegarder()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void testSupprimerUnFichier()
        {
            //Acteurs

            //Actions

            //Assertions
        }

        [Test]
        public void testSupprimerUnMedia()
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
            String expected = "";
            String actual = catalogue.ToString();
            //Actions

            //Assertions
        }
    }
}
