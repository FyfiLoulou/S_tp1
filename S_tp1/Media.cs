using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace S_tp1
{
    public class Media
    {/*
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
        */
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


        /*public Media() : this($"media{nombreIncremente++}", Types.ELECTRO, 1, 1, "Félix Blanchette", "Louis-Charles Biron", "", new List<Evaluation>(), "", "")
        {

        }*/

        /*public Media(string identifiantMedia) : this(identifiantMedia, Types.ELECTRO, 1, 1, "Félix Blanchette", "Louis-Charles Biron", "", new List<Evaluation>(), "", "")
        {
            this.identifiantMedia = $"{identifiantMedia}_{nombreIncremente++}";
        }*/

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
                return this.identifiantMedia == ((Media)obj).identifiantMedia;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // redéfinition des opérateurs
        public static bool operator ==(Media m1, Media m2) => m1.Equals(m2);

        public static bool operator !=(Media m1, Media m2) => !(m1.identifiantMedia == m2.identifiantMedia);

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


        public byte GetCote() { return 1; }// TODO
        public string GetNom() { return this.identifiantMedia?.Split("_")[0] ?? "'Nom non définit'"; }

        public override string ToString()
        {
            return $" Name: {this.GetNom()}\n Type: {this.type}\nCote: {this.GetCote()}/100, Date de realisation`{this.dateRealisation}\n Duree: {this.duree}\n Auteur: {this.auteur}\n Producteur: {this.producteur}\n Path: {this.complet}\n EvalCoutn: {evaluations.Count}";
        }

    }
}