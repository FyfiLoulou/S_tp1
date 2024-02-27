using S_tp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static S_tp1.Types;

namespace TestTP1
{
    public class MediaTest
    {

        Catalogue catalogue;
        Media media1;
        Media media2;
        Media media3;

        public void Setup()
        {
            catalogue = new Catalogue();
        }

        [Test]
        public void etantDonne2mediaPareils_quandEgalite_alorsMediaEgaux() {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");
            media2 = new Media("media2", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");

            // action
            bool paspareil = media1 == media2;

            // assertion
            Assert.That(paspareil, Is.False);

        }

        [Test]
        public void etantDonne2mediaPasPareils_quandEgalite_alorsMediaNonEgaux()
        {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");
            media3 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");

            // action
            bool pareil = media1 == media3;

            // assertion
            Assert.That(pareil, Is.True);
        }

        [Test]
        public void etantDonneMedia_quandToString_alorsRetourneBonString()
        {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");

            // action
            string toStringVal = media1.ToString();

            // assertion
            Console.WriteLine(toStringVal);
        }

        [Test]
        public void etantDonneComplet_quandGetSetComplet_alorsRetourneBonComplet()
        {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");

            // action
            media1.Complet = "completTest";
            string completVal = media1.Complet;

            // assertion
            Assert.That(completVal, Is.EqualTo("completTest"));
        }

        [Test]
        public void etantDonneDuree_quandGetSetDuree_alorsRetourneBonDuree()
        {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");

            // action
            media1.Duree = 100;
            int dureeVal = (int)media1.Duree;

            // assertion
            Assert.That(dureeVal, Is.EqualTo(1001));
        }

    }
}
