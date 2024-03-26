using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace S_tp1
{
    public class Utilisateur
    {
        [JsonIgnore]
        public const string PASSWORD_PAR_DEFAUT_PAS_BON = "FélixAimeLesPatatesPlainsFULL<3";
        [JsonIgnore]
        public const string PSEUDO_DEFAULT = "pseudo";
        [JsonIgnore]
        public const string NOM_DEFAULT = "nom";
        [JsonIgnore]
        public const string PRENOM_DEFAULT = "prenom";
        [JsonIgnore]
        public const Role ROLE_DEFAULT = Role.UTILISATEUR;

        [JsonIgnore]
        private static int nombreIncremente = 0;

        //attributs
        private string identifiantUnique;
        private string pseudo;
        private string motDePasse;
        private string nom;
        private string prenom;
        private Role role;
        private List<Media> favoris;
        [JsonIgnore]
        private List<Evaluation> evaluations;



        [JsonConstructor]
        public Utilisateur(String pseudo, String motDePasse, String nom, String prenom, Role role)
        {

            IdentifiantUnique = $"{Pseudo}_{nombreIncremente++}";
            Pseudo = pseudo;
            MotDePasse = motDePasse;
            Nom = nom;
            Prenom = prenom;
            Role = role;

            //Todo -> On devrait pas avoir des new ici
            this.favoris = new List<Media>();
            this.evaluations = new List<Evaluation>();
        }


        public Utilisateur(string pseudo, string motDePasse) : this(pseudo, motDePasse, NOM_DEFAULT, PRENOM_DEFAULT, ROLE_DEFAULT)
        {
            IdentifiantUnique = $"{Pseudo}_{nombreIncremente++}";
            Pseudo = pseudo;
            MotDePasse = motDePasse;
        }

        //Constructeur par défaut
        public Utilisateur() : this(PSEUDO_DEFAULT, PASSWORD_PAR_DEFAUT_PAS_BON, NOM_DEFAULT, PRENOM_DEFAULT, ROLE_DEFAULT)
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
            evaluations.Add(eval);
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
            // Pseudo doit contenir seulement des chiffres et des lettres et doit avoir une longueur minimale de 5 caractères et une longueur maximale de 50 caractère
            set { pseudo = value.Length >= 5 && value.Length <= 50 && new Regex("[a-z]", RegexOptions.IgnoreCase).IsMatch(value) && new Regex("[0-9]+").IsMatch(value) ? value : PSEUDO_DEFAULT; }
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
            set { nom = value.Length > 1 && new Regex("[a-z]", RegexOptions.IgnoreCase).IsMatch(value) ? value : NOM_DEFAULT; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value.Length > 1 && new Regex("[a-z]", RegexOptions.IgnoreCase).IsMatch(value) ? value : PRENOM_DEFAULT; }
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

