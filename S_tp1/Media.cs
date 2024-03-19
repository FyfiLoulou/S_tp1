using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using static S_tp1.Types;

namespace S_tp1
{
    public class Media
    {
        [JsonIgnore]
        public const string ID_DEFAULT = "media default";
        [JsonIgnore]
        public const Types TYPE_DEFAULT = Types.JAZZ;
        [JsonIgnore]
        public const long DATE_DEFAULT = 1;
        [JsonIgnore]
        public const int DUREE_DEFAULT = 1;
        [JsonIgnore]
        public const string AUTEUR_DEFAULT = "Auteur default";
        [JsonIgnore]
        public const string PRODUCTEUR_DEFAULT = "Productueur default";
        [JsonIgnore]
        public const string EXTRAIT_DEFAULT = null;
        [JsonIgnore]
        public const string COMPLET_DEFAULT = null;
        [JsonIgnore]
        public const string IMAGE_DEFAULT = null;

        [JsonIgnore]
        private static int nombreIncremente = 0;

        private string identifiantMedia;
        private Types type;
        private long dateRealisation;
        private int duree;
        private string auteur;
        private string producteur;
        private string extrait;
        private string complet;
        private string image;
        [JsonIgnore]
        private List<Evaluation> evaluations = new List<Evaluation>();


        [JsonConstructor]
        public Media(string identifiantMedia, Types type, long dateRealisation, int duree, string auteur, string producteur, string extrait, string complet, string image)
        {

            IdentifiantMedia = new Regex("_[0-9]$").IsMatch(identifiantMedia) ? identifiantMedia : $"{identifiantMedia}_{nombreIncremente++}";
            Type = type;
            DateRealisation = dateRealisation;
            Duree = duree;
            Auteur = auteur;
            Producteur = producteur;
            Complet = complet;
            Extrait = extrait;
            Image = image;
        }


        public Media(string identifiantMedia) : this(identifiantMedia, TYPE_DEFAULT, DATE_DEFAULT, DUREE_DEFAULT, AUTEUR_DEFAULT, PRODUCTEUR_DEFAULT, EXTRAIT_DEFAULT, COMPLET_DEFAULT, IMAGE_DEFAULT)
        {
            IdentifiantMedia = $"{identifiantMedia}_{nombreIncremente++}";

        }


        public Media() : this($"{ID_DEFAULT}_{nombreIncremente}", TYPE_DEFAULT, DATE_DEFAULT, DUREE_DEFAULT, AUTEUR_DEFAULT, PRODUCTEUR_DEFAULT, EXTRAIT_DEFAULT, COMPLET_DEFAULT, IMAGE_DEFAULT)
        {

        }



        public void AjouterEvaluation(Evaluation eval)
        {
            this.evaluations.Add(eval);
        }

        //overrides
        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Media))
                return false;
            else
                return this.GetNom() == ((Media)obj).GetNom();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdentifiantMedia, this.GetNom());
        }

        // redéfinition des opérateurs
        public static bool operator ==(Media m1, Media m2) => m1.Equals(m2);

        public static bool operator !=(Media m1, Media m2) => !m1.Equals(m2);

        //getters setter
        public string IdentifiantMedia
        {
            get { return identifiantMedia; }
            set { }
        }

        public Types Type
        {
            get { return type; }
            set { this.type = value; }
        }

        [JsonIgnore]
        public List<Evaluation> Evaluations
        {
            get { return evaluations; }
            set { this.evaluations = value; }
        }

        public long DateRealisation
        {
            get { return dateRealisation; }
            set {
                this.dateRealisation = value < DateTimeOffset.Now.ToUnixTimeMilliseconds() ? value : DATE_DEFAULT;
            }
        }

        public int Duree
        {
            get { return duree; }
            set { this.duree = value>0 ? value : DUREE_DEFAULT; }
        }


        public string Auteur
        {
            get { return auteur; }
            set { this.auteur = value!="" && value.Length<50 ? value : AUTEUR_DEFAULT; }
        }

        public string Producteur
        {
            get { return producteur; }
            set { this.producteur = value != "" && value.Length < 50 ? value : PRODUCTEUR_DEFAULT; }
        }

        public string Extrait
        {
            get { return extrait; }
            set { this.extrait = value.IndexOf(".") >= 0 ? value : EXTRAIT_DEFAULT;}
        }

        public string Complet
        {
            get { return complet; }
            set { this.complet = value.IndexOf(".") >= 0 ? value : COMPLET_DEFAULT; }
        }

        public string Image
        {
            get { return image; }
            set { this.image = value.IndexOf(".") >= 0 ? value : IMAGE_DEFAULT;}
        }


        /// <summary>
        /// Calcule la cote (moyenne) à partir des évaluations associées à cet objet (this) média
        /// </summary>
        /// <returns>La cote calculée à partir des évaluations</returns>
        public byte GetCote()
        {
            return evaluations.Count > 0 ? (byte)Math.Round((double)(evaluations.Select(x => x.Cote).Aggregate((a, b) => a += b) / evaluations.Count)) : (byte)0;
        }

        /// <summary>
        /// Récupère le nom de l'objet média à partir de son identifiant unique
        /// </summary>
        /// <returns>Le nom de l'objet média extrait de son identifiant. Si l'identitfant n'est pas défini, retourne "Nom non défini"</returns>
        public string GetNom() { return this.identifiantMedia?.Split("_")[0] ?? "'Nom non définit'"; }

        public override string ToString()
        {
            return $"id: {this.identifiantMedia}\n type:{this.Type}, complet:{this.extrait}, image:{this.Image},  Name: {this.GetNom()}\n Type: {this.type}\nCote: {this.GetCote()}/100\n  Date de realisation: {this.dateRealisation}\n Duree: {this.duree}\n Auteur: {this.auteur}\n Producteur: {this.producteur}\n Path: {this.complet}\n EvalCoutn: {evaluations.Count}";
        }

    }
}