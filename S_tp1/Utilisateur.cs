using static S_tp1.Evaluation;
using Newtonsoft.Json;
namespace S_tp1
{
    public class Utilisateur
    {
        //attributs
        private String identifiantUnique;
        private static int nombreIncremente = 0;
        private String pseudo;
        private String motDePasse;
        private String nom;
        private String prenom;
        private Enum role;
        private List<Media> favoris;
        private Dictionary<String, Evaluation> evaluations;

        [JsonIgnore]
        private Catalogue catalogue;
        


        /*
         * énumération des rôles qu'un utilisateur pourrait être
         */
        enum Role
        {
            UTILISATEUR,
            TECHNICIEN,
            ADMIN
        }


        /*
         * Constructeur de la classe utilisateur
         * @param pseudo -> le pseudonyme que l'utilisateur utilisera
         * @param motDePasse -> le mot de passe que l'utilisateur va utiliser pour entrer dans son compte
         * @param nom -> le nom de famille de l'utilisateur
         * @param prenom -> le prénom de l'utilisateur
         */
        public Utilisateur(String pseudo, String motDePasse, String nom, String prenom, Catalogue catalogue)
        {
            this.identifiantUnique = $"{this.pseudo = pseudo}_{++nombreIncremente}";
            this.motDePasse = motDePasse;
            this.nom = nom;
            this.prenom = prenom;
            this.role = Role.UTILISATEUR;
            this.catalogue = catalogue;
        }

        /*
         * @param identifiantMedia -> l'idantifiant du media que l'on veux ajouter à nos favoris
         * @return la liste de favoris actualisée
         */
        public List<Media> AjouterFavori(Media media) {
            if (catalogue.MediaExisteDansCatalogue(media)) {
                favoris.Add(media);
            }
            return this.favoris;
        }


        /*
         * @param media -> media que l'on veut ajouter à nos favoris
         * @param cote -> la cote que l'on veux ajouter au media que l'on veut
         * @return la validation de si l'ajout d'une evaluation a fonctionné
         */
        public bool AjouterEvaluation(Media media, byte cote)
        {
            //TODO
            //TODO - faut acceder au catalogue
            new Evaluation(this, media, cote);



            return false;
        }

        //getters
        public String getIdentifiantUnique() {return identifiantUnique;}
        public String getPseudo() {return pseudo;}
        public String getMotDePasse() { return motDePasse; }
        public String getNom() { return nom;}
        public String getPrenom() { return prenom;}
        


        //setters



        /*
         * méthode qui retourne l'objet Utilisateur en une chaine de charactères lisible pour l'homme
         */
        public override string ToString()
        {
            return "Identifiant unique : " + identifiantUnique
                + "\nPseudonyme : " + pseudo
                + "\nMot de Passe : " + motDePasse
                + "\nNom : " + nom
                + "\nPrenom : " + prenom
                + "\nRôle : " + role;
        }

    }
}

