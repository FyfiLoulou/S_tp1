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
        Media media;
        Utilisateur johny;
        Evaluation evaluation;

        [SetUp]
        public void Setup()
        {
            catalogue = new Catalogue();
            media = new Media();
            johny = new Utilisateur("JohnyX", "abc123", "Test", "Johny");
            evaluation = new Evaluation(johny, media, 3);
        }

        [TestCase(media, "")]
        public void etantCatalogue_QuandAjouter_alorsReturnValidation(Media mediaParam, String resultat)
        {
            String message = "";

            Assert.That(message, Is.EqualTo();

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
    }
}