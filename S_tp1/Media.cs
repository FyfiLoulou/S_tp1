using System;
using static S_tp1.Types;


namespace S_tp1
{
    public class Media
    {



        private static int nombreIncremente = 0;

        private string? identifiantMedia;
        private Enum? type;
        private List<Evaluation>? evaluations;
        private long? dateRealisation;
        private int? duree;
        private string? auteur;
        private string? producteur;
        private string? extrait;
        private string? complet;
        private string? image;


        public Media() : this($"media{nombreIncremente++}", Types.ELECTRO, 1, 1, "Félix Blanchette", "Louis-Charles Biron", "", new List<Evaluation>(), "", "")
        {

        }

        public Media(string identifiantMedia) : this(identifiantMedia, Types.ELECTRO, 1, 1, "Félix Blanchette", "Louis-Charles Biron", "", new List<Evaluation>(), "", "")
        {
            this.identifiantMedia = identifiantMedia + nombreIncremente++;
        }

        public Media(string identifiantMedia, Enum type, long dateRealisation, int duree, string auteur, string producteur, string extrait, List<Evaluation> evaluations, string complet, string image)
        {
            this.identifiantMedia =$"{identifiantMedia}_{nombreIncremente++}";
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

        public Enum? Type
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
        public string GetNom() { return this.identifiantMedia?.Split("_")[0]??"'Nom non définit'"; }

        public override string ToString()
        {
            return $" Name: {this.GetNom()}, Type: {this.type}, Cote: {this.GetCote()}/100, Date de realisation`{this.dateRealisation}, Duree: {this.duree}, Auteur: {this.auteur}, Producteur: {this.producteur}, Path: {this.complet}";
        }

    }
}