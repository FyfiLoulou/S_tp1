﻿using static S_tp1.Evaluation;
using static S_tp1.Role;
namespace S_tp1
{
    public class Utilisateur
    {
        //attributs
        private String identifiantUnique;
        private static int nombreIncremente = 0;
        private String pseudo;
        private String motDePasse;
        private String nom;
        private String prenom;
        private Enum role;
        private List<Media> favoris;
        private Dictionary<String, Evaluation> evaluations;



        //Constructeur par défaut
        /*public Utilisateur() : this($"Utilisateur{nombreIncremente++}", "abc123", "Lorman", "Maek")
        {

        }*/

        //Constructeur Login et mdp
        /*public Utilisateur(string pseudo, string motDePasse) : this(pseudo, motDePasse, "Lorman", "Maek")
        {
            this.identifiantUnique = $"{pseudo}#{nombreIncremente}";
            this.pseudo = pseudo;
            this.motDePasse = motDePasse;
        }*/
        

        /*
         * Constructeur de la classe utilisateur
         * @param pseudo -> le pseudonyme que l'utilisateur utilisera
         * @param motDePasse -> le mot de passe que l'utilisateur va utiliser pour entrer dans son compte
         * @param nom -> le nom de famille de l'utilisateur
         * @param prenom -> le prénom de l'utilisateur
         */
        public Utilisateur(String pseudo, String motDePasse, String nom, String prenom, Enum role)
        {
            this.identifiantUnique = $"{this.pseudo = pseudo}_{nombreIncremente++}";
            this.motDePasse = motDePasse;
            this.nom = nom;
            this.prenom = prenom;
            this.role = role;
            this.favoris = new List<Media>();
            this.evaluations = new Dictionary<String, Evaluation>();
        }

        /*
         * @param identifiantMedia -> l'idantifiant du media que l'on veux ajouter à nos favoris
         * @return la liste de favoris actualisée
         */
        public List<Media> AjouterFavori(Media media)
        {
            favoris.Add(media);
            return this.favoris;
        }


        /*
         * @param media -> media que l'on veut ajouter à nos favoris
         * @param cote -> la cote que l'on veux ajouter au media que l'on veut
         * @return la validation de si l'ajout d'une evaluation a fonctionné
         */
        public void AjouterEvaluation(Media media, byte cote)
        {
            //TODO
            Evaluation eval = new Evaluation(this, media, cote);
            this.evaluations.Add(media.IdentifiantMedia, eval);
            //media.ajouterEvaluation(eval);
        }

        //getters & setters
        public string IdentifiantUnique
        {
            get { return identifiantUnique; }
            set
            {
                String[] tab = identifiantUnique.Split("#");
                String nb = tab[tab.Length - 1];
                identifiantUnique = $"{value} + # + {nb}";
            }
        }


        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public Enum Role
        {
            get { return role; }
            set { role = value; }
        }


        /*
         * méthode qui retourne l'objet Utilisateur en une chaine de charactères lisible pour l'homme
         */
        public override string ToString()
        {
            return $"Identifiant unique : {identifiantUnique}\nPseudonyme : {pseudo}\nMot de Passe : {motDePasse}\nNom : {nom}"
                + $"\nPrenom : {prenom}\nRôle : {role}";
        }

    }
}

