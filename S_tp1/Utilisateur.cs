using static S_tp1.Evaluation;
namespace S_tp1
{
    public class Utilisateur
    {
        //attributs
        private String identifiantUnique;
        private static int nombreIncremente;
        private String pseudo;
        private String motDePasse;
        private String nom;
        private String prenom;
        private Enum role;
        private List<String> favoris;
        private Dictionary<String, Evaluation> evaluations;
        
        //constructor
        public Utilisateur()
        {

        }
    }
}

