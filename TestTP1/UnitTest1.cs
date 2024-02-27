using static S_tp1.Catalogue;
using static S_tp1.Media;
using static S_tp1.Utilisateur;
using static S_tp1.Evaluation;
using static S_tp1.Role;
using S_tp1;

namespace TestTP1
{
    public class Tests
    {
        //Acteurs
        Catalogue catalogue;
        Media mediaTest;
        Utilisateur johny = new Utilisateur("JohnyX", "abc123", "Test", "Johny", Role.UTILISATEUR);
        Utilisateur lcb = new Utilisateur();
        Utilisateur maek = new Utilisateur("ML", "abc123", "Lorman", "Maek", Role.UTILISATEUR);
        Utilisateur felix = new Utilisateur("FB", "ofdh");
        Evaluation evaluation;

        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
            mediaTest = new Media("media", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");
            evaluation = new Evaluation(johny, mediaTest, 3);
        }

        //Utilisateurs=============================================================================
        [Test]
        public void Constructeur1()
        {
            String id = lcb.IdentifiantUnique;

            Assert.That(id, Is.EqualTo("nomUtilisateurDefault_1"));
        }

        [Test]
        public void Constructeur2()
        {
            String id = maek.IdentifiantUnique;

            Assert.That(id, Is.EqualTo("ML_2"));
        }

        [Test]
        public void Constructeur3()
        {
            String id = felix.IdentifiantUnique;

            Assert.That(id, Is.EqualTo("FB_4"));
        }


        [TestCase("Jtesteur", "Jtesteur_5")]
        public void EtantJTesteur_QuandsetIdentifiantUnique_AlorsGetRetourneTesteurAvecNum(String valeur, String resultat)
        {
            //Action
            johny.IdentifiantUnique = valeur;
            String valRetournee = johny.IdentifiantUnique;

            //Assertion
            Assert.That(valRetournee, Is.EqualTo(resultat));
        }

        [Test]
        public void getPseudo()
        {
            //Action
            String resultat = johny.Pseudo;

            //Assertion
            Assert.That(resultat, Is.EqualTo("JohnyX"));
        }

        [Test]
        public void setPseudo()
        {
            //Action
            johny.Pseudo = "TestUser";
            String resultat = johny.Pseudo;

            //Assertion
            Assert.That(resultat, Is.EqualTo("TestUser"));
        }

        [Test]
        public void getMDP()
        {
            //Action
            johny.MotDePasse = "abc123$$$LOL";
            String resultat = johny.MotDePasse;

            //Assertion
            Assert.That(resultat, Is.EqualTo("abc123$$$LOL"));
        }

        [Test]
        public void setMDPMauvais()
        {
            //Action
            johny.MotDePasse = "pasbon";
            String resultat = johny.MotDePasse;

            //Assertion
            Assert.That(resultat, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }

        [Test]
        public void setMDPon()
        {
            //Action
            johny.MotDePasse = "cePassword3stb()n";
            String resultat = johny.MotDePasse;

            //Assertion
            Assert.That(resultat, Is.EqualTo("cePassword3stb()n"));
        }

        [Test]
        public void EtantEvaluationCount_QuandAjouterEvaluation_AlorsReturnEvaluationsListeCountPlus1()
        {
            //Action
            int nbEvalAv = johny.Evaluations.Count;
            johny.AjouterEvaluation(evaluation);
            int nbEvalAp = johny.Evaluations.Count;

            //Assertion
            Assert.That(nbEvalAp, Is.EqualTo(nbEvalAv + 1));

        }

        [Test]
        public void EtantFavorisCount_QuandAjouterFavoris_AlorsReturnFavorisCountPlus1()
        {
            //Action
            int nbFavAv = johny.Favoris.Count;
            johny.AjouterFavori(mediaTest);
            int nbFavAp = johny.Favoris.Count;

            //Assertion
            Assert.That(nbFavAp, Is.EqualTo(nbFavAv + 1));
        }


    }
}