using System;

namespace S_tp1 {
    public class Evaluation {

        private string identifiantUtilisateur;
        private string identifiantMedia;
        private byte cote;


        public Evaluation(string identifiantUtilisateur, string identifiantMedia, byte cote) {
            this.identifiantUtilisateur = identifiantUtilisateur;
            this.identifiantMedia = identifiantMedia;
            this.cote = cote;
        }

        public string getIdentifiantUtilisateur() { return identifiantUtilisateur; }
        public string getIdentifiantMedia() {  return identifiantMedia; }
        public byte getCote() {  return cote; }  

    }
}
