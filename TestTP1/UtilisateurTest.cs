using static S_tp1.Catalogue;
using static S_tp1.Media;
using static S_tp1.Utilisateur;
using static S_tp1.Evaluation;
using static S_tp1.Role;
using S_tp1;
using System.Text.RegularExpressions;

namespace TestTP1
{
    public class UtilisateurTest
    {
        //Acteurs
        Catalogue catalogue;
        Media mediaTest;
        Utilisateur user1;
        Utilisateur user2;
        Utilisateur userVide;
        Utilisateur userConstructeur1;

        [SetUp]
        public void Setup()
        {
            user1 = new Utilisateur("JohnyX1", "aBc123!", "Test", "Johny", Role.UTILISATEUR);
            user2 = new Utilisateur("ML10", "aBc123%", "Lorman", "Maek", Role.ADMIN);
            userVide = new Utilisateur();
            userConstructeur1 = new Utilisateur("testa1", "Soleil0!");
            catalogue = new Catalogue();
            mediaTest = new Media("media", Types.ROCK, 1, 1, "felix", "maek", "extrait", "complet", "image");
        }

        [Test]
        public void constructeurVide()
        {
            Assert.That(userVide.Pseudo, Is.EqualTo(Utilisateur.PSEUDO_DEFAULT));
            Assert.That(userVide.MotDePasse, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
            Assert.That(userVide.Prenom, Is.EqualTo(Utilisateur.PRENOM_DEFAULT));
            Assert.That(userVide.Nom, Is.EqualTo(Utilisateur.NOM_DEFAULT));
            Assert.That(userVide.Role, Is.EqualTo(Utilisateur.ROLE_DEFAULT));
        }

        [Test]
        public void constructeur_Pseudo_MotDePasse()
        {
            Assert.That(userConstructeur1.Pseudo, Is.EqualTo("testa1"));
            Assert.That(userConstructeur1.MotDePasse, Is.EqualTo("Soleil0!"));
            Assert.That(userConstructeur1.Prenom, Is.EqualTo(Utilisateur.PRENOM_DEFAULT));
            Assert.That(userConstructeur1.Nom, Is.EqualTo(Utilisateur.NOM_DEFAULT));
            Assert.That(userConstructeur1.Role, Is.EqualTo(Utilisateur.ROLE_DEFAULT));
        }

        [Test]
        public void constructeurFull()
        {
            Assert.That(user1.Pseudo, Is.EqualTo("JohnyX1"));
            Assert.That(user1.MotDePasse, Is.EqualTo("aBc123!"));
            Assert.That(user1.Prenom, Is.EqualTo("Johny"));
            Assert.That(user1.Nom, Is.EqualTo("Test"));
            Assert.That(user1.Role, Is.EqualTo(Role.UTILISATEUR));
        }

        [Test]
        public void setPseudoBon()
        {
            user2.Pseudo = "pseudoBon10";
            Assert.That(user2.Pseudo, Is.EqualTo("pseudoBon10"));
        }

        [Test]
        public void setPseudoTorpCourt()
        {
            user2.Pseudo = "p";
            Assert.That(user2.Pseudo, Is.EqualTo(Utilisateur.PSEUDO_DEFAULT));
        }

        [Test]
        public void setPseudoPasChiffre()
        {
            user2.Pseudo = "pasdasdas";
            Assert.That(user2.Pseudo, Is.EqualTo(Utilisateur.PSEUDO_DEFAULT));
        }

        [Test]
        public void setPseudoPasLettre()
        {
            user2.Pseudo = "123123";
            Assert.That(user2.Pseudo, Is.EqualTo(Utilisateur.PSEUDO_DEFAULT));
        }

        [Test]
        public void setMotDePasseBon()
        {
            user2.MotDePasse = "Abc12#";
            Assert.That(user2.MotDePasse, Is.EqualTo("Abc12#"));
        }

        [Test]
        public void setMotDePasseTropCourt()
        {
            user2.MotDePasse = "a";
            Assert.That(user2.MotDePasse, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }

        [Test]
        public void setMotDePassePasMaj()
        {
            user2.MotDePasse = "abc12#";
            Assert.That(user2.MotDePasse, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }

        [Test]
        public void setMotDePassePasChiffre()
        {
            user2.MotDePasse = "abc#";
            Assert.That(user2.MotDePasse, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }

        [Test]
        public void setMotDePassePasSymbol()
        {
            user2.MotDePasse = "abc12";
            Assert.That(user2.MotDePasse, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }




    }
}