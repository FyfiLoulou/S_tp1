using NUnit.Framework.Internal;
using S_tp1;

namespace TestTP1
{
    public class TestCatalogue
    {
        Catalogue catalogue;
        const string NOM_DE_FICHIER = "s_test_catalogue.json",
          AUTRE_NOM_FICHIER = "testDonnes.json";



        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
        }

        [Test]
        public void TestConstructeur()
        {
            //Acteurs

            //Actions
            List<Media> cat = catalogue.getCatalogue();

            //Assertions
            Assert.That(cat.Count(), Is.EqualTo(0));
        }

        [Test]
        public void etandDonneMediaAAjouterDansCatalogue_quandAjouterAvecParam_alorsMediaAjouterDansCatalogue()
        {
            //Acteurs
            Media m = new Media();
            //Actions
            catalogue.Ajouter(m);
            //Assertions
            Assert.That(catalogue.getCatalogue().Contains(m), Is.True);
        }

        [Test]
        public void etantDonneFichierJsonAvecContenu_quandAjouterAvecFichierEnParam_alorsAjouterContenuFichierEnParam()
        {
            //Acteurs


            //Actions
            catalogue.Ajouter(AUTRE_NOM_FICHIER);

            //Assertions
            Assert.That(catalogue.getCatalogue().Count(), Is.EqualTo(4));
        }

        [Test]
        public void etantDonneCatalogueAvecContenu_quandSauvegarder_alorsContenuDansFichierSauvegarde()
        {
            //Acteurs
            Media m = new Media("allo");
            Media m1 = new Media("bonjour");
            Media m2 = new Media("salut");
            //Actions
            catalogue.Ajouter(m);
            catalogue.Ajouter(m1);
            catalogue.Ajouter(m2);
            catalogue.Sauvegarder(NOM_DE_FICHIER);
            catalogue.Supprimer();
            catalogue.Ajouter(NOM_DE_FICHIER);
            //Assertions
            Assert.That(catalogue.getCatalogue().Count(), Is.EqualTo(3));
        }

        [Test]
        public void etantDonneCatalogueRempli_quandSupprimerSansParam_alorsCatalogueVide()
        {
            //Acteurs
            Media m = new Media();
            Media m1 = new Media();
            Media m2 = new Media();
            catalogue.Ajouter(m);
            catalogue.Ajouter(m1);
            catalogue.Ajouter(m2);
            //Actions
            catalogue.Supprimer();
            //Assertions
            Assert.That(catalogue.getCatalogue().Count(), Is.EqualTo(0)); 
        }

        [Test]
        public void etantDonneMediaASupprimerDuCatalogue_quandSupprimerAvecMediaEnParam_alorsMediaSupprimeDuCatalogue()
        {
            //Acteurs
            Media m = new Media("media");
            //Actions
            catalogue.Ajouter(m);
            catalogue.Supprimer(m);
            //Assertions
            Assert.That(catalogue.getCatalogue().Count, Is.EqualTo(0));
        }

        [Test]
        public void TestRemplacer()
        {
            //Acteurs
            Media m1 = new Media("media1");
            Media m2 = new Media("media2");
            //Actions
            catalogue.Ajouter(m1);
            catalogue.Remplacer(m2, m1);
            //Assertions
            Assert.That(catalogue.getCatalogue().Count, Is.EqualTo(1));
        }

        [Test]
        public void TestToString()
        {
            //Acteurs
            String expected = "media: ";
            String actual = catalogue.ToString();
            //Assertions
            Assert.That (expected, Is.EqualTo (actual));
        }
    }
}
