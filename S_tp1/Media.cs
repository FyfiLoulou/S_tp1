using System;
using System.Numerics;
using static S_tp1.Evaluation;
using static System.Net.Mime.MediaTypeNames;

namespace S_tp1 {
    public class Media {

        public enum Types {
            test
        };
        private string? identifiantMedia;
        private Types? type;
        private byte? cote;
        private List<Evaluation>? evaluations;
        private long? dateRealisation;
        private int? duree;
        private string? auteur;
        private string? producteur;
        private string? extrait;
        private string? complet;
        private string? image;


        public Media() {

        }

        public Media(string identifiantMedia) {
            this.identifiantMedia = identifiantMedia;
        }

        public Media(string identifiantMedia, Types type, byte cote, long dateRealisation, int duree, string auteur, string producteur, string extrait, List<Evaluation> evaluations, string complet, string image) {
            this.identifiantMedia = identifiantMedia;
            this.type = type;
            this.cote = cote;
            this.dateRealisation = dateRealisation;
            this.duree = duree;
            this.auteur = auteur;
            this.producteur = producteur;
            this.complet = complet;
            this.extrait = extrait;
            this.image = image;
        }


    }
}


