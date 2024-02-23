﻿using Newtonsoft.Json;

namespace S_tp1
{
    /*
     * Regroupe les médias et s'occupe de la sérialisation de l'objet catalogue
     */
    public class Catalogue
    {
        //TODO: 20-02-2024 -> définir le path du fichier de sauvegarde
        private const string MESSAGE_ERREUR = "Erreur! 1D10T-6969: Un événement inattendu s'est produit!";

        //TODO: 20-02-2024 -> maybe singleton, getInstance et le constructeur private maybe
        private static List<Media>? catalogue;

        private string PATH_SOURCE = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        // Constructeur par défaut
        public Catalogue()
        {
            catalogue = new List<Media>();
        }

        /*
         * ajoute un media passé en paramètre dans le catalogue
         * 
         * @param identifiantMedia -> l'identifiant unique du media à ajouter
         * @return -> retourne vrai si le media a bel et bien été ajouter au catalogue
         */
        // TODO -> check si autre message à retourner
        // TODO -> faire ajouter avec param fichier JSON
        public bool Ajouter(Media media)
        {
            bool isAjouter = false;
            if (!MediaExisteDansCatalogue(media))
            {
                catalogue.Add(media);
                isAjouter = true;
            }
            else if (MediaExisteDansCatalogue(media))
            {
                Console.WriteLine($"Le media {media.GetNom()} existe déjà dans le catalogue et n'a pas pu être ajouté");
            }
            else
            {
                consoleState(true);
                Console.WriteLine(MESSAGE_ERREUR);
                consoleState(false);
            }
            return isAjouter;
        }

        /*
         * remplace un media passé en paramètre par un autre aussi passé en paramètre
         * 
         * @param mediaToAdd -> media à ajouter
         * @param mediaToRemove -> media à remplacer
         * @return -> retourne vrai si le media a bel et bien été remplacé
         */
        public bool Remplacer(Media mediaToAdd, Media mediaToRemove)
        {
            string messageRetour;
            bool isRemplace = false;
            if (!(MediaExisteDansCatalogue(mediaToAdd)) && MediaExisteDansCatalogue(mediaToRemove))
            {
                isRemplace = true;
                messageRetour = $"Le media {mediaToAdd.GetNom()} a été ajouté au catalogue et le media {mediaToRemove.GetNom()} a été supprimé";
                this.Supprimer(mediaToRemove);
                this.Ajouter(mediaToAdd);
            }
            else if (!(MediaExisteDansCatalogue(mediaToRemove)))
            {
                messageRetour = $"Le media {mediaToRemove.GetNom()} n'existe pas dans le catalogue et ne peut donc pas être supprimé!";
            }
            else if (MediaExisteDansCatalogue(mediaToAdd))
            {
                messageRetour = $"Le media {mediaToAdd.GetNom()} existe déjà dans le catalogue et ne peut donc pas être ajouté!";
            }
            else
            {
                consoleState(true);
                messageRetour = MESSAGE_ERREUR;
                consoleState(false);
            }

            Console.WriteLine(messageRetour);
            return isRemplace;
        }

        /*
         * supprime le media passé en paramètre du catalogue
         * 
         * @param media -> l'identifiant unique du media à supprimer
         * @return -> retourne vrai si le media a bel et bien supprimé
         */
        public bool Supprimer(Media media)
        {
            return true;
        }

        /*
         * supprime le catalogue au complet
         * 
         * @return -> retourne vrai si le catalogue est supprimé correctement
         */
        public bool Supprimer()
        {
            catalogue.Clear();
            bool isSupprime = true;
            string messageRetour = "Le catalogue a été complètement supprimé!";
            if (catalogue.Count != 0)
            {
                isSupprime = false;
                consoleState(true);
                messageRetour = MESSAGE_ERREUR;
                consoleState(false);
            }

            Console.WriteLine(messageRetour);
            return isSupprime;
        }

         /*
         * TODO -> documentation
         */
        public bool Ajouter(string nomFichierSauvegarde) {
            bool bienAjoute = true;
            try
            {
                catalogue = JsonConvert.DeserializeObject<List<Media>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}"));
            } catch (FileNotFoundException err) {
                consoleState(true);
                Console.WriteLine("Fichier existe pas: " + err.Message);
                consoleState(bienAjoute = false);
            }
            catch (Exception err)
            {
                consoleState(true);
                Console.WriteLine("Erreur autre: " + err.Message);
                consoleState(bienAjoute = false);
            }

            return bienAjoute;
        }

        /*
         * sauvegarde le catalogue et le sérialise dans un fichier JSON
         * 
         * @param nomFichierSauvegarde -> le nom du fichier JSON de sauvegarde YOFO
         */
        public bool Sauvegarder(string nomFichierSauvegarde) {
            bool isSauvegarde = true;
            try {
                File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(catalogue, Formatting.Indented));
            } catch (DirectoryNotFoundException err) {
                consoleState(true);
                Console.WriteLine("Dossier existe pas: "+err.Message);
                consoleState(isSauvegarde = false);
            } catch (Exception err) {
                consoleState(true);
                Console.WriteLine("Erreur autre: "+err.Message);
                consoleState(isSauvegarde = false);
            }
            return isSauvegarde;
        }

        // Méthode Override
        //TODO
        public override string ToString()
        {
            return "(☞ﾟヮﾟ)☞";
        }


        // Méthodes ajoutées

        public bool MediaExisteDansCatalogue(Media media)
        {
            return catalogue.Contains(media);
        }

        //get catalogue
        public List<Media>? getCatalogue() { return catalogue; }


        private void consoleState(bool isError)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.White;
        }
    }


}

