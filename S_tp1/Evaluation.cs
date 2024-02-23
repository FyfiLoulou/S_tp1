using System;

namespace S_tp1 {
    public class Evaluation {//

        private Utilisateur utilisateur;
        private Media media;
        private byte cote;


        public Evaluation(Utilisateur utilisateur, Media media, byte cote) {
            this.utilisateur = utilisateur;
            this.media = media;
            this.cote = cote;
        }

        public Utilisateur Utilisateur
        {
            get { return utilisateur; }
            private set { this.utilisateur = value; }
        }

        public Media Media
        {
            get { return media; }
            private set { this.media = value; }
        }

        public Byte Cote
        {
            get { return cote; }
            set { this.cote = value; }
        }

    }
}
