using static S_tp1.Catalogue;
using static S_tp1.Media;
using static S_tp1.Utilisateur;
using static S_tp1.Evaluation;
using S_tp1;

namespace TestTP1
{
    public class Tests
    {
        Catalogue catalogue;
        Media mediaTest;
        Utilisateur johny = new Utilisateur("JohnyX", "abc123", "Test", "Johny", Role.UTILISATEUR);
        Utilisateur lcb = new Utilisateur("LCB", "v87e", "Biron", "Louis-Charles", Role.UTILISATEUR);
        Utilisateur maek = new Utilisateur("ML", "abc123", "Lorman", "Maek", Role.UTILISATEUR);
        Utilisateur felix = new Utilisateur("FB", "ofdh", "Felix", "Blanchette", Role.UTILISATEUR);
        Evaluation evaluation;

        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
            mediaTest = new Media("media", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");
            evaluation = new Evaluation(johny, mediaTest, 3);
        }
        
        //Utilisateurs=============================================================================
        [TestCase("testeur", "testeur_0")]
        [TestCase("test_eur", "test_eur_0")]
        [TestCase("testeur_", "testeur__0")]
        [TestCase("testeur_1", "testeur_1_0")]
        public void EtantTesteur_QuandsetIdentifiantUnique_AlorsGetRetourneTesteurAvecNum(String valeur, String resultat)
        {
            johny.IdentifiantUnique = valeur;
            String valRetournee = johny.IdentifiantUnique;

            Assert.That(valRetournee, Is.EqualTo(resultat));
        }

        [Test]
        public void getPseudo()
        {
            
            String resultat = johny.Pseudo;

            Assert.That(resultat, Is.EqualTo("JohnyX"));
        }

        [Test]
        public void setPseudo()
        {
            johny.Pseudo = "TestUser";
            String resultat = johny.Pseudo;

            Assert.That(resultat, Is.EqualTo("TestUser"));
        }

        [Test]
        public void getMDP()
        {
            johny.MotDePasse = "abc123$$$LOL";
            String resultat = johny.MotDePasse;

            Assert.That(resultat, Is.EqualTo("abc123$$$LOL"));
        }

        [Test]
        public void setMDPMauvais()
        {
            johny.MotDePasse = "pasbon";
            String resultat = johny.MotDePasse;

            Assert.That(resultat, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }

        [Test]
        public void setMDPon()
        {
            johny.MotDePasse = "cePassword3stb()n";
            String resultat = johny.MotDePasse;

            Assert.That(resultat, Is.EqualTo("cePassword3stb()n"));
        }

        [Test]
        public void EtantEvaluationCount_QuandAjouterEvaluation_AlorsReturnEvaluationsListeCountPlus1()
        {
            int nbEvalAv = johny.Evaluations.Count;
            johny.AjouterEvaluation(evaluation);
            int nbEvalAp = johny.Evaluations.Count;
            Assert.That(nbEvalAp, Is.EqualTo(nbEvalAv + 1));

        }

        [Test]
        public void EtantFavorisCount_QuandAjouterFavoris_AlorsReturnFavorisCountPlus1()
        {
            
            int nbFavAv = johny.Favoris.Count;
            johny.AjouterFavori(mediaTest);
            int nbFavAp = johny.Favoris.Count;
            Assert.That(nbFavAp, Is.EqualTo(nbFavAv + 1));
        }


        //Media====================================================================================

        [Test]
        public void constructeurMedia()
        {
            //TODO

        }

        [Test]
        public void egalite()
        {
            //TODO

        }

        [Test]
        public void deuxChamps()
        {
            //TODO
        }

        [Test]
        public void toStringMedia()
        {
            //TODO
        }

        [Test]
        public void getCoteMediaia()
        {
            //TODO
        }

    }
}