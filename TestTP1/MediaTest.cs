using S_tp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static S_tp1.Types;

namespace TestTP1
{
    public class MediaTest
    {

        Catalogue catalogue;
        Media media1;
        Media media11;
        Media media3;
        Media mediaVide;
        Media mediaConstructeur1;

        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait.mp3", "complet.mp3", "image.png");
            media11 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait.mp3", "complet.mp3", "image.png");
            media3 = new Media("media3", Types.ROCK, 1, 1, "felix", "maek", "extrait.mp3", "complet.mp3", "image.png");
            mediaVide = new Media();
            mediaConstructeur1 = new Media("test");
        }

        [Test]
        public void égalité() {
            Assert.That(media1 == media1, Is.True);
        }

        [Test]
        public void pasÉgalité()
        {
            Assert.That(media1 != media3, Is.True);
        }

        [Test]
        public void toString()
        {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");

            // action
            string toStringVal = media1.ToString();

            // assertion
            Console.WriteLine(toStringVal);
            Assert.That(toStringVal.GetTypeCode(), Is.EqualTo(TypeCode.String));
        }

        [Test]
        public void setNomBon()
        {
            //string old = media1.Nom;
            media1.Nom = "mediaIdk";
            string nev = media1.Nom;

            // assertion
            Assert.That(nev, Is.EqualTo("mediaIdk"));
        }

        [Test]
        public void setNomMauvais()
        {
            media1.Nom = "$%#?@%(*@!#&()&#!@)(*#?)";
            string nev = media1.Nom;

            // assertion
            Assert.That(nev, Is.EqualTo(Media.NOM_DEFAULT));
        }

        [Test]
        public void setDureeBon()
        {
            media1.Duree = 100;
            int dureeVal = media1.Duree;

            // assertion
            Assert.That(dureeVal, Is.EqualTo(100));
        }

        [Test]
        public void setDureeMauvais()
        {
            media1.Duree = -100;
            int dureeVal = media1.Duree;

            // assertion
            Assert.That(dureeVal, Is.EqualTo(Media.DUREE_DEFAULT));
        }

        [Test]
        public void ConstructeurVide()
        {
            Assert.That(mediaVide.Nom, Is.EqualTo(Media.NOM_DEFAULT));
            Assert.That(mediaVide.DateRealisation, Is.EqualTo(Media.DATE_DEFAULT));
            Assert.That(mediaVide.Duree, Is.EqualTo(Media.DUREE_DEFAULT));
            Assert.That(mediaVide.Auteur, Is.EqualTo(Media.AUTEUR_DEFAULT));
            Assert.That(mediaVide.Producteur, Is.EqualTo(Media.PRODUCTEUR_DEFAULT));
            Assert.That(mediaVide.Extrait, Is.EqualTo(Media.EXTRAIT_DEFAULT));
            Assert.That(mediaVide.Complet, Is.EqualTo(Media.COMPLET_DEFAULT));
            Assert.That(mediaVide.Image, Is.EqualTo(Media.IMAGE_DEFAULT));
        }

        [Test]
        public void constructeurJusteIdentifiant()
        {
            Assert.That(mediaConstructeur1.Nom, Is.EqualTo("test"));
            Assert.That(mediaConstructeur1.Type, Is.EqualTo(Media.TYPE_DEFAULT));
            Assert.That(mediaConstructeur1.DateRealisation, Is.EqualTo(Media.DATE_DEFAULT)); 
            Assert.That(mediaConstructeur1.Duree, Is.EqualTo(Media.DUREE_DEFAULT));
            Assert.That(mediaConstructeur1.Auteur, Is.EqualTo(Media.AUTEUR_DEFAULT));
            Assert.That(mediaConstructeur1.Producteur, Is.EqualTo(Media.PRODUCTEUR_DEFAULT));
            Assert.That(mediaConstructeur1.Extrait, Is.EqualTo(Media.EXTRAIT_DEFAULT));
            Assert.That(mediaConstructeur1.Complet, Is.EqualTo(Media.COMPLET_DEFAULT));
            Assert.That(mediaConstructeur1.Image, Is.EqualTo(Media.IMAGE_DEFAULT));
        }

        [Test]
        public void constructeurPlein()
        {
            Assert.That(media1.Nom, Is.EqualTo("media1"));
            Assert.That(media1.Type, Is.EqualTo(Types.ROCK));
            Assert.That(media1.DateRealisation, Is.EqualTo(1));
            Assert.That(media1.Duree, Is.EqualTo(1));
            Assert.That(media1.Auteur, Is.EqualTo("felix"));
            Assert.That(media1.Producteur, Is.EqualTo("maek"));
            Assert.That(media1.Extrait, Is.EqualTo("extrait.mp3"));
            Assert.That(media1.Complet, Is.EqualTo("complet.mp3"));
            Assert.That(media1.Image, Is.EqualTo("image.png"));
        }

    }
}
