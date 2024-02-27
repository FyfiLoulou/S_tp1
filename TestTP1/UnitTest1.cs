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
        Utilisateur johny = new Utilisateur("JohnyX", "abc123", "Test", "Johny", RoleUtilisateur.UTILISATEUR);
        Utilisateur lcb = new Utilisateur("LCB", "v87e", "Biron", "Louis-Charles", RoleUtilisateur.UTILISATEUR);
        Utilisateur maek = new Utilisateur("ML", "abc123", "Lorman", "Maek", RoleUtilisateur.UTILISATEUR);
        Utilisateur felix = new Utilisateur("FB", "ofdh", "Felix", "Blanchette", RoleUtilisateur.UTILISATEUR);
        Evaluation evaluation;

        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
            mediaTest = new Media("media", Types.ROCK, 1, 1, "felix", "maek", "extrait", new List<Evaluation>(), "complet", "image");
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
        public void constructeurUser()
        {
            //TODO
            
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
            String resultat = johny.MotDePasse;

            Assert.That(resultat, Is.EqualTo("abc123"));
        }

        [Test]
        public void setMDP()
        {
            johny.MotDePasse = "1212Test";
            String resultat = johny.MotDePasse;

            Assert.That(resultat, Is.EqualTo("1212Test"));
        }

        [Test]
        public void EtantEvaluationCount_QuandAjouterEvaluation_AlorsReturnFavorisCountPlus1()
        {
            int nbEvalAv = johny.Favoris.Count;
            johny.AjouterEvaluation(evaluation);
            int nbEvalAp = johny.Favoris.Count;
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

        //Catalogue================================================================================
        //TODO
        /*
        [TestCase(media, "")]
        public void etantCatalogue_QuandAjouter_alorsReturnValidation(Media mediaParam, String resultat)
        {
            String message = "";

            Assert.That(message, Is.EqualTo();

        }
        */


        [Test]
        public void constructeurCatalogue()
        {
            //TODO
        }


        [Test]
        public void Remplacer()
        {
            //TODO
        }

        [Test]
        public void SupprimerUnMedia()
        {
            //TODO
        }

        [Test]
        public void SupprimerLeCatalogue()
        {
            //TODO
        }

        [Test]
        public void Sauvegarder()
        {
            //TODO
        }

        [Test]
        public void MediaExisteDansCatalogue()
        {
            //TODO
        }

        [Test]
        public void toStringCatalogue()
        {
            //TODO
        }
    }
}