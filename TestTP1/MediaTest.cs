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
            Assert.That(dureeVal, Is.EqualTo(100));
        }

        [Test]
        public void etantDonneConstructeurVide_quandCreerMediaVide_alorsRetourneMediaParDefaut()
        {
            // acteurs
            media1 = new Media();
            List<bool> res = new List<bool>();

            // action
            res.Add(new Regex($"^{Media.ID_DEFAULT}_[0-9]+$").IsMatch(media1.IdentifiantMedia));
            res.Add(media1.Type == Media.TYPE_DEFAULT);
            res.Add(media1.DateRealisation == Media.DATE_DEFAULT);
            res.Add(media1.Duree == Media.DUREE_DEFAULT);
            res.Add(media1.Auteur == Media.AUTEUR_DEFAULT);
            res.Add(media1.Producteur == Media.PRODUCTEUR_DEFAULT);
            res.Add(media1.Extrait == Media.EXTRAIT_DEFAULT);
            res.Add(media1.Complet == Media.COMPLET_DEFAULT);
            res.Add(media1.Image == Media.IMAGE_DEFAULT);

            // assertion
            Assert.That(res.All(x=>x==true), Is.True);
        }

        [Test]
        public void etantDonneConstructeurJusteIdentifiant_quandCreerMediaJusteIdentifiant_alorsRetourneMediaResteParDefaut()
        {
            // acteurs
            media1 = new Media("ID_TETS");
            List<bool> res = new List<bool>();

            // action
            res.Add(media1.Type == Media.TYPE_DEFAULT);
            res.Add(media1.DateRealisation == Media.DATE_DEFAULT);
            res.Add(media1.Duree == Media.DUREE_DEFAULT);
            res.Add(media1.Auteur == Media.AUTEUR_DEFAULT);
            res.Add(media1.Producteur == Media.PRODUCTEUR_DEFAULT);
            res.Add(media1.Extrait == Media.EXTRAIT_DEFAULT);
            res.Add(media1.Complet == Media.COMPLET_DEFAULT);
            res.Add(media1.Image == Media.IMAGE_DEFAULT);

            // assertion
            Assert.That(res.All(x => x == true), Is.True);
        }

        [Test]
        public void etantDonneConstructeurPlein_quandCreerMedia_alorsRetourneMediaPlein()
        {
            // acteurs
            media1 = new Media("media1", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");
            List<bool> res = new List<bool>();

            // action
            res.Add(!string.IsNullOrEmpty(media1.IdentifiantMedia+"_0"));
            res.Add(media1.Type != null);
            res.Add(media1.DateRealisation != null);
            res.Add(media1.Duree != null);
            res.Add(!string.IsNullOrEmpty(media1.Auteur));
            res.Add(!string.IsNullOrEmpty(media1.Producteur));
            res.Add(!string.IsNullOrEmpty(media1.Extrait));
            res.Add(!string.IsNullOrEmpty(media1.Complet));
            res.Add(!string.IsNullOrEmpty(media1.Image));

            // assertion
            Assert.That(res.All(x => x == true), Is.True);
        }

    }
}
