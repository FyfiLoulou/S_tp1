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
            set {}
        }

        public Media Media
        {
            get { return media; }
            set {}
        }

        public byte Cote
        {
            get { return cote; }
            set {}
        }

        public override string ToString() {
            return $"evaluation: {utilisateur.IdentifiantUnique}, media: {media.IdentifiantMedia}, cote: {cote}";
        }

    }
}
