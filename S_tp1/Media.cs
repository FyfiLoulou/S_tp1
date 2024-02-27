using System;
using Newtonsoft.Json;

namespace S_tp1
{
    public class Media
    {

        public enum Types
        {
            RAP,
            POP,
            JAZZ,
            ROCK,
            ELECTRO,
            COUNTRY,
            RELAXATION,
            INSTRUMENTAL,
            CONCEPTUALSYNTH,
            PARTY,
            CLASSIQUE,
            OST
        }


        private static int nombreIncremente = 0;

        private string? identifiantMedia;
        private Types? type;
        private long? dateRealisation;
        private int? duree;
        private string? auteur;
        private string? producteur;
        private string? extrait;
        private string? complet;
        private string? image;
        [JsonIgnore]
        private List<Evaluation>? evaluations;


        public Media(string identifiantMedia, Types type, long dateRealisation, int duree, string auteur, string producteur, string extrait, List<Evaluation> evaluations, string complet, string image)
        {
            this.identifiantMedia = $"{identifiantMedia}_{nombreIncremente++}";
            this.type = type;
            this.dateRealisation = dateRealisation;
            this.duree = duree;
            this.auteur = auteur;
            this.producteur = producteur;
            this.complet = complet;
            this.extrait = extrait;
            this.image = image;
            this.evaluations = evaluations;
        }


        public Media(string identifiantMedia) : this(identifiantMedia, Types.ELECTRO, 1, 1, "Félix Blanchette", "Louis-Charles Biron", "", new List<Evaluation>(), "", "")
        {
            this.identifiantMedia = $"{identifiantMedia}_{nombreIncremente++}";
        }


        public Media() : this($"nomMediaDefaut_{nombreIncremente++}", Types.ELECTRO, 1, 1, "Félix Blanchette", "Louis-Charles Biron", "", new List<Evaluation>(), "", "")
        {

        }



        public void AjouterEvaluation(Evaluation eval)
        {
            this.evaluations.Add(eval);
        }

        //overrides
        public override bool Equals(Object? obj)
        {
            if (obj == null || !(obj is Media))
                return false;
            else
                return this.identifiantMedia == ((Media)obj).identifiantMedia;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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

        public Types? Type
        {
            get { return type; }
            set { this.type = value; }
        }

        [JsonIgnore]
        public List<Evaluation>? Evaluations
        {
            get { return evaluations; }
            set { this.evaluations = value; }
        }

        public long? DateRealisation
        {
            get { return dateRealisation; }
            set { this.dateRealisation = value; }
        }

        public int? Duree
        {
            get { return duree; }
            set { this.duree = value; }
        }


        public string? Auteur
        {
            get { return auteur; }
            set { this.auteur = value; }
        }

        public string? Producteur
        {
            get { return producteur; }
            set { this.producteur = value; }
        }

        public string? Extrait
        {
            get { return extrait; }
            set { this.extrait = value; }
        }

        public string? Complet
        {
            get { return complet; }
            set { this.complet = value; }
        }

        public string? Image
        {
            get { return image; }
            set { this.image = value; }
        }


        /// <summary>
        /// Calcule la cote (moyenne) à partir des évaluations associées à cet objet (this) média
        /// </summary>
        /// <returns>La cote calculée à partir des évaluations</returns>
        public byte GetCote()
        {
            return evaluations.Count > 0 ? (byte)Math.Floor((double)(evaluations.Select(x => x.Cote).Aggregate((a, b) => a += b) / evaluations.Count)) : (byte)0;
        }

        /// <summary>
        /// Récupère le nom de l'objet média à partir de son identifiant unique
        /// </summary>
        /// <returns>Le nom de l'objet média extrait de son identifiant. Si l'identitfant n'est pas défini, retourne "Nom non défini"</returns>
        public string GetNom() { return this.identifiantMedia?.Split("_")[0] ?? "'Nom non définit'"; }

        public override string ToString()
        {
            return $"id: {this.identifiantMedia}\n  Name: {this.GetNom()}\n Type: {this.type}\nCote: {this.GetCote()}/100\n  Date de realisation: {this.dateRealisation}\n Duree: {this.duree}\n Auteur: {this.auteur}\n Producteur: {this.producteur}\n Path: {this.complet}\n EvalCoutn: {evaluations.Count}";
        }

    }
}