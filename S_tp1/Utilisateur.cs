using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static S_tp1.Evaluation;
using System.Text.RegularExpressions;
using static S_tp1.Role;
using System.Runtime.ExceptionServices;
namespace S_tp1
{
    public class Utilisateur
    {

        public const string PASSWORD_PAR_DEFAUT_PAS_BON = "FélixAimeLesPatatesPlainsFULL<3";

        //attributs
        private String identifiantUnique;
        private static int nombreIncremente = 0;
        private String pseudo;
        private String motDePasse;
        private String nom;
        private String prenom;
        private Role role;
        private List<Media> favoris;
        [JsonIgnore]
        private List<Evaluation> evaluations;



        [JsonConstructor]
        public Utilisateur(String pseudo, String motDePasse, String nom, String prenom, Role role)
        {

            this.identifiantUnique = $"{pseudo}_{nombreIncremente++}";
            this.pseudo = pseudo;
            this.motDePasse = motDePasse;
            this.nom = nom;
            this.prenom = prenom;
            this.role = role;
            this.favoris = new List<Media>();
            this.evaluations = new List<Evaluation>();
        }


        public Utilisateur(string pseudo, string motDePasse) : this(pseudo, motDePasse, "Lorman", "Maek", Role.UTILISATEUR)
        {
            this.identifiantUnique = $"{pseudo}_{nombreIncremente++}";
            this.pseudo = pseudo;
            this.motDePasse = motDePasse;
        }

        //Constructeur par défaut
        public Utilisateur() : this($"nomUtilisateurDefault_{nombreIncremente++}", "abc123", "Lorman", "Maek", Role.UTILISATEUR)
        {

        }

        /// <summary>
        /// Ajoute un média à la liste des favoris
        /// </summary>
        /// <param name="media">Le média à ajouter</param>
        public void AjouterFavori(Media media)
        {
            favoris.Add(media);
        }


        /// <summary>
        /// Ajoute une évaluation à la liste des évaluations associées à cet utilisateur (this)
        /// </summary>
        /// <param name="eval">L'évaluation à ajouter</param>
        public void AjouterEvaluation(Evaluation eval)
        {
            this.evaluations.Add(eval);
        }

        //getters & setters
        public string IdentifiantUnique
        {
            get { return identifiantUnique; }
            set
            {
                identifiantUnique = new Regex("_[0-9]$").IsMatch(value) ? value : $"{value}_{nombreIncremente++}";
            }
        }


        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public string MotDePasse
        {
            get { return motDePasse; }
            set
            {
                //doit avoir lettres et chiffres, minimum 5 de long, au moins un maj, un char non alphanumérique
                motDePasse = value.Length >= 5 && new Regex("[0-9]+").IsMatch(value) && new Regex("[a-z]").IsMatch(value) && new Regex("[A-Z]").IsMatch(value) && new Regex("[^a-zA-Z0-9]+").IsMatch(value) ? value : PASSWORD_PAR_DEFAUT_PAS_BON;
            }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        [JsonIgnore]
        public List<Evaluation> Evaluations
        {
            get { return evaluations; }
            set { evaluations = value; }
        }

        public List<Media> Favoris
        {
            get { return favoris; }
            set { favoris = value; }
        }


        /*
         * méthode qui retourne l'objet Utilisateur en une chaine de charactères lisible pour l'homme
         */
        public override string ToString()
        {
            return $"Identifiant unique : {identifiantUnique}\nPseudonyme : {pseudo}\nMot de Passe : {motDePasse}\nNom : {nom} \nPrenom : {prenom}\nRôle : {role}\nEvalcount: {evaluations.Count}";
        }


    }
}

