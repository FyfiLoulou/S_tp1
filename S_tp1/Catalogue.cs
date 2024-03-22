﻿using Newtonsoft.Json;
using static S_tp1.Utilitaire;

namespace S_tp1
{
    /*
     * Regroupe les Médias et s'occupe de la sérialisation de l'objet catalogue
     */
    public class Catalogue
    {

        private static List<Media> catalogue;

        private string PATH_SOURCE = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";

        // Constructeur par défaut
        public Catalogue()
        {
            catalogue = new List<Media>();
        }

        /// <summary>
        /// Ajoute un objet média dans le catalogue
        /// </summary>
        /// <param name="media">L'objet média à ajouter</param>
        /// <returns>True si le média est ajouté au catalogue, false si le média existe déjà</returns>
        public bool Ajouter(Media media)
        {
            
            bool isAjouter = false;
            if (!MediaExisteDansCatalogue(media))
            {
                catalogue.Add(media);
                isAjouter = true;
            }
            
            return isAjouter;
        }

        /// <summary>
        /// remplace un objet média déjà présent dans le catalogue par un nouvel objet média
        /// </summary>
        /// <param name="mediaToAdd">Le nouvel objet média à ajouter dans le catalogue</param>
        /// <param name="mediaToRemove">L'objet média à remplacer dans le catalogue</param>
        /// <returns>True si l'objet média est remplacé par le nouvel objet média, false autrement</returns>
        public bool Remplacer(Media mediaToAdd, Media mediaToRemove)
        {
            bool isRemplace = false;

            // mediaToAdd n'est pas dans le catalogue et mediaToRemove y est
            // on doit ajouter le nouvel objet média dans le catalogue et retirer le média à remplacer
            if (!MediaExisteDansCatalogue(mediaToAdd) && MediaExisteDansCatalogue(mediaToRemove))
            {
                isRemplace = true;
                this.Supprimer(mediaToRemove);
                this.Ajouter(mediaToAdd);
            }

            return isRemplace;
        }

        /// <summary>
        /// Supprime le media passé en paramètre du catalogue
        /// </summary>
        /// <param name="media">L'objet media à supprimer</param>
        /// <returns>True si le media a été supprimé, false si le media n'a pas été supprimé</returns>
        public bool Supprimer(Media media)
        {
            bool isSupprime = false;
            if (MediaExisteDansCatalogue(media))
            {
                catalogue.Remove(media);
                if (!MediaExisteDansCatalogue(media))
                {
                    isSupprime = true;
                }
            }
            
            return isSupprime;
        }

        /// <summary>
        /// Supprime tous les médias du catalogue
        /// </summary>
        /// <returns> True si le catalogue a bien été supprimé, false autrement</returns>
        public bool Supprimer()
        {
            catalogue.Clear();
            return catalogue.Count() == 0;
        }

        /// <summary>
        /// Lit in fichier JSON du chemin spécifié et ajoute les médias à la liste des médias du catalogue
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le chemin du fichier JSON</param>
        /// <returns>Le catalogue rempli d'objet média</returns>
        public List<Media> Ajouter(string nomFichierSauvegarde)
        {
            List<Media> list = null;
            try
            {
                catalogue = list = JsonConvert.DeserializeObject<List<Media>>(File.ReadAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}"));
            }
            catch (FileNotFoundException err)
            {
                //Todo -> Qu'est ce qu'on fait avec ca
                Console.WriteLine("Fichier existe pas: " + err.Message);
            }
            catch (Exception err)
            {
                //Todo -> Qu'est ce qu'on fait avec ca
                Console.WriteLine("Erreur autre: " + err.Message);
            }

            return list;
        }


        /// <summary>
        /// Sauvegarde l'état actuel du catalogue dans un fichier JSON.
        /// </summary>
        /// <param name="nomFichierSauvegarde">Le nom du fichier à sauvegarder</param>
        /// <returns>True si la sauvegarde est réussi, false autrement</returns>
        public bool Sauvegarder(string nomFichierSauvegarde)
        {
            bool isSauvegarde = true;
            try
            {
                File.WriteAllText(@$"{PATH_SOURCE}\{nomFichierSauvegarde}", JsonConvert.SerializeObject(catalogue, Formatting.Indented));
            }
            catch (DirectoryNotFoundException err)
            {
                //Todo -> Qu'est ce qu'on fait avec ca
                Console.WriteLine("Dossier existe pas: " + err.Message);
                
            }
            catch (Exception err)
            {
                //Todo -> Qu'est ce qu'on fait avec ca
                Console.WriteLine("Erreur autre: " + err.Message);
                
            }
            return isSauvegarde;
        }

        // Méthode Override

        public override string ToString()
        {
            string retVal = "media: ";
            foreach (Media media in catalogue)
            {
                retVal += $"{media.ToString()} \n\n";
            }
            return retVal;
        }


        // Méthodes ajoutées

        /// <summary>
        /// Todo -> Est-ce qu'on garde ?
        /// Vérifie si le média passé en paramètre existe dans le catalogue
        /// </summary>
        /// <param name="media">Le média à chercher dans le catalogue</param>
        /// <returns>True si le média existe, false s'il n'existe pas</returns>
        public bool MediaExisteDansCatalogue(Media media)
        {
            return catalogue.Contains(media);
        }

        /// <summary>
        /// permet l'accès au catalogue
        /// </summary>
        /// <returns>Le catalogue</returns>
        public List<Media>? getCatalogue() { return catalogue; }


        /// <summary>
        /// Todo -> Est-ce qu'on en vraiment besoin ?
        /// Récupère un média à partir de son identifiant
        /// </summary>
        /// <param name="id">l'indentifiantMedia du Media à récuprérer</param>
        /// <returns>Le média coresspondant à l'identififant spécifié</returns>
        public Media GetMedia(string id)
        {   
            return catalogue.Where(m => m.IdentifiantMedia == id).Count()>0 ? catalogue.Where(m => m.IdentifiantMedia == id).First() : null;
        }

    }


}

