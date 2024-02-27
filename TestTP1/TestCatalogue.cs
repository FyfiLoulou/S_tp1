﻿using S_tp1;

namespace TestTP1
{
    public class TestCatalogue
    {
        Catalogue catalogue;
        const string NOM_DE_FICHIER = "s_test_catalogue.json";



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

            //Actions
            catalogue.Ajouter(NOM_DE_FICHIER);
            //Assertions
            Assert.That(catalogue.getCatalogue().Count(), Is.EqualTo(4));
        }

        [Test]
        public void TestSauvegarder()
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
        public void TestSupprimerUnFichier()
        {
            //Acteurs
            Media m = new Media();
            catalogue.Ajouter(m);
            catalogue.Ajouter(m);
            //Actions
            catalogue.Supprimer(m);
            //Assertions
            Assert.That(catalogue.getCatalogue().Count(), Is.EqualTo(1));
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
