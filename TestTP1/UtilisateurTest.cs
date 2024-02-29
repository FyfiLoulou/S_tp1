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
        public void EtantDonneConstructeurVide_quandCreerUtilisateur_AlorsUtilisateurParDefaut()
        {
            // acteurs
            lcb = new Utilisateur();
            List<bool> res = new List<bool>
            {
                // action
                new Regex($"^{Utilisateur.PSEUDO_DEFAULT}_[0-9]+$").IsMatch(lcb.IdentifiantUnique),
                lcb.Role == Utilisateur.ROLE_DEFAULT,
                lcb.MotDePasse == Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON,
                lcb.Nom == Utilisateur.NOM_DEFAULT,
                lcb.Prenom == Utilisateur.PRENOM_DEFAULT
            };

            // assertion
            Assert.That(res.All(x => x == true), Is.True);
        }

        [Test]
        public void etantDonneConstructeurAvecPseudoEtMotDePasseParam_quandCreerUtilisateur_AlorsUtilisateurPseudoMDP()
        {
            //TODO: pseudo + mdp
            maek = new Utilisateur("ML", "abc123");
            List<bool> res = new List<bool>
            {
                new Regex($"^ML_[0-9]+$").IsMatch(maek.IdentifiantUnique),
                maek.Role == Utilisateur.ROLE_DEFAULT,
                maek.MotDePasse == "abc123",
                maek.Nom == Utilisateur.NOM_DEFAULT,
                maek.Prenom == Utilisateur.PRENOM_DEFAULT
            };


        Assert.That(res.All(x => x == true), Is.True);
        }

        [Test]
        public void EtantDonneCreerUtilisateurConstructeurFull_QuandConstructeurFull_AlorsCreerUtilisateurConstructeurFull()
        {
            //TODO: FULLO
            felix = new Utilisateur("FB", "ofdh", "Blanchette", "Felix", Role.UTILISATEUR);
            List<bool> res = new List<bool>
            {
                new Regex($"^FB_[0-9]+$").IsMatch(felix.IdentifiantUnique),
                felix.Role == Role.UTILISATEUR,
                felix.MotDePasse == "ofdh",
                felix.Nom == "Blanchette",
                felix.Prenom == "Felix"
            };

            Assert.That(res.All(x => x == true), Is.True);
        }

        //TODO -> regex

        public void EtantJTesteur_QuandsetIdentifiantUnique_AlorsGetRetourneTesteurAvecNum(String valeur, String resultat)
        {
            //Acteur
            johny = new Utilisateur("JTesteur", "abc123", "Test", "Johny", Role.UTILISATEUR);
            //Action
            bool res = new Regex("^JTesteur_[0-9]$").IsMatch(johny.IdentifiantUnique);
            //Assertion
            Assert.That(res, Is.True);
        }

        [Test]
        public void EtantDonneJohnyXCommePseudo_QuandGetPseudo_AlorsJohnyXCommePseudo()
        {
            //Action
            String resultat = johny.Pseudo;

            //Assertion
            Assert.That(resultat, Is.EqualTo("JohnyX"));
        }

        [Test]
        public void EtantDonnePseudoDefaut_QuandSetPseudo_AlorsPseudoChanger()
        {
            //Action
            johny.Pseudo = "TestUser";
            String resultat = johny.Pseudo;

            //Assertion
            Assert.That(resultat, Is.EqualTo("TestUser"));
        }

        [Test]
        public void EtantDonneMotDePasse_QuandGetMotDePasse_AlorsMotDePasseRetourne()
        {
            //Action
            johny.MotDePasse = "abc123$$$LOL";
            String resultat = johny.MotDePasse;

            //Assertion
            Assert.That(resultat, Is.EqualTo("abc123$$$LOL"));
        }

        [Test]
        public void EtantDonneMotDePassePasBon_QuandSetMotDePasse_AlorsMotDePasseParDefaut()
        {
            //Action
            johny.MotDePasse = "pasbon";
            String resultat = johny.MotDePasse;

            //Assertion
            Assert.That(resultat, Is.EqualTo(Utilisateur.PASSWORD_PAR_DEFAUT_PAS_BON));
        }

        [Test]
        public void EtantDonneMotDePasseCorrect_QuandSetMotDePasse_AlorsMotDePasseChange()
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