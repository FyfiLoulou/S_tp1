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
        Utilisateur lcb;
        Utilisateur maek;
        Utilisateur felix;
        Evaluation evaluation;

        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
            mediaTest = new Media("media", Types.ROCK, 1, 1, "felix", "maek", "extrait", new List<Evaluation>(), "complet", "image");
            
            lcb = new Utilisateur("LCB", "v87e", "Biron", "Louis-Charles", RoleUtilisateur.UTILISATEUR);
            maek = new Utilisateur("ML", "abc123", "Lorman", "Maek", RoleUtilisateur.UTILISATEUR);
            felix = new Utilisateur("FB", "ofdh", "Felix", "Blanchette", RoleUtilisateur.UTILISATEUR);
            evaluation = new Evaluation(johny, mediaTest, 3);
        }

        //Utilisateurs=============================================================================
        [TestCase("testeur", "testeur#1")]
        [TestCase("test#eur", "test#eur#2")]
        [TestCase("testeur#", "testeur##3")]
        [TestCase("testeur#1", "testeur#1#4")]
        public void EtantTesteur_QuandsetIdentifiantUnique_AlorsGetRetourneTesteurAvecNum(String valeur, String resultat)
        {
            johny.IdentifiantUnique = valeur;
            String valRetournee = johny.IdentifiantUnique;

            Assert.That(valRetournee, Is.EqualTo(resultat));
        }

        [Test]
        public void constructeurUser()
        {
            
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
        public void ajouterFavori()
        {

        }

        [Test]
        public void ajouterEvaluation()
        {

        }


        //Media====================================================================================

        [Test]
        public void constructeurMedia()
        {

        }

        [Test]
        public void egalite()
        {

        }

        [Test]
        public void deuxChamps()
        {

        }

        [Test]
        public void toStringMedia()
        {

        }

        //Catalogue================================================================================

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

        }


        [Test]
        public void Remplacer()
        {

        }

        [Test]
        public void SupprimerUnMedia()
        {

        }

        [Test]
        public void SupprimerLeCatalogue()
        {

        }

        [Test]
        public void Sauvegarder()
        {

        }

        [Test]
        public void MediaExisteDansCatalogue()
        {

        }

        [Test]
        public void toStringCatalogue()
        {

        }
    }
}