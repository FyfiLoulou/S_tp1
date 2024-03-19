using System;

namespace S_tp1 {
    public class Evaluation {//

        private Utilisateur utilisateur;
        private Media media;
        private byte cote;


        public Evaluation(Utilisateur utilisateur, Media media, byte cote) {
            Utilisateur = utilisateur;
            Media = media;
            Cote = cote;
        }

        public Utilisateur Utilisateur
        {
            get { return utilisateur; }
            set {utilisateur = value;}
        }

        public Media Media
        {
            get { return media; }
            set {media = value;}
        }

        public byte Cote
        {
            get { return cote; }
            set { cote = value > 100 ? (byte)100 : value; }
        }

        public override string ToString() {
            return $"evaluation: {utilisateur.IdentifiantUnique}, media: {media.IdentifiantMedia}, cote: {cote}";
        }

    }
}
