using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace S_tp1
{
    public class Program
    {

        private const string pathMedias = "s_medias.json",
        pathUtilisateurs = "s_utilisateurs.json",
        pathEvaluations = "s_evalutations.json",
        pathFavoris = "s_favoris.json";
        private static string pathDossierSerial = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";




        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web\n");


        /*string pathDossierSeriala = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";


        /*
         * c_media: ajouter(media), supprimer(media), clear, getCote(media), getMedia(), remplacer(media1, media2), sérializer/déserialiser
         * c_eval: ajouter, supprimer, clear, getEval(media), getEval(user), sérializer/déserialiser
         * 
         * c_user: ajouter, supprimer, clear,getUser(), sérializer/déserialiser
         * c_fav: ajouter, supprimer, clear, getFav(user), (si on veut: getFav(media)), sérializer/déserialiser
         * 
         * 
         * 
         * TODO:
         * c_media:
         * c_eval: 
         * 
         * c_user:
         * c_fav:
         * 
         * 
         

            List<Media> mediaListe = new List<Media>(); // mediaId pis c toute
            List<Utilisateur> userListe = new List<Utilisateur>(); // users pis c toute

            List<Evaluation> evalListe = new List<Evaluation>(); // evals: cote, id, identifiantUser
            List<Favoris> favorisListe = new List<Favoris>(); // evals: cote, id, identifiantUser


            Media media1 = new Media("m1");
            Media media2 = new Media("m1");
            Media media3 = new Media("m3");

            Utilisateur user1 = new Utilisateur("user1", "mdp");
            Utilisateur user2 = new Utilisateur("user2", "mpd");
            Utilisateur user3 = new Utilisateur("user2", "mdp");

            Evaluation eval1 = new Evaluation(user1.getId(), media1.getId(), 87);
            Evaluation eval2 = new Evaluation(user2.getId(), media1.getId(), 8);
            Evaluation eval3 = new Evaluation(user3.getId(), media1.getId(), 50);

            Favoris fav1 = new Favoris(user1.getId(), media1.getId());
            Favoris fav2 = new Favoris(user2.getId(), media2.getId());
            Favoris fav3 = new Favoris(user3.getId(), media3.getId());

            mediaListe.Add(media2);
            userListe.Add(user2);
            evalListe.Add(eval2);
            favorisListe.Add(fav2);
            mediaListe.Add(media3);
            userListe.Add(user3);
            evalListe.Add(eval3);
            favorisListe.Add(fav3);
            mediaListe.Add(media1);
            userListe.Add(user1);
            evalListe.Add(eval1);
            favorisListe.Add(fav1);

            Console.WriteLine(media1);
            Console.WriteLine(media2);
            Console.WriteLine(user2);
            Console.WriteLine(user3);

            Console.WriteLine("Ajouter: GOOD");
            Console.WriteLine("mediaListe: " + mediaListe.Count());
            Console.WriteLine("userListe: " + userListe.Count());
            Console.WriteLine("evalListe: " + evalListe.Count());
            Console.WriteLine("favorisListe: " + favorisListe.Count());

            Console.WriteLine("\nget: DONE");
            // a partir d'un eval → get MediaId et UserId
            //eval1;    
            Media mediaQuery = mediaListe.Where(x => x.getId() == eval1.MediaId).ToList()[0];
            Utilisateur userQuery = userListe.Where(x => x.getId() == eval1.UserId).ToList()[0];

            /*Console.WriteLine(eval1);
            Console.WriteLine(mediaQuery);
            Console.WriteLine(userQuery);

            Console.WriteLine("\nmodifier: a revoir ???)()))");
            //user1.Pseudo = "alloBOB";
            //Console.WriteLine("user1 → "+user1.Id);
            //media1.Complet = "protumanux";
            //Console.WriteLine("media1 → complet" + media1.Complet);

            Console.WriteLine("\nsupprimer: TODO 💀💀");
            // function removeMedia(media) {
            evalListe.RemoveAll(x => x.MediaId == media1.Id);
            favorisListe.RemoveAll(x => x.MediaId == media1.Id);
            mediaListe.Remove(media1);
            Console.WriteLine("deleted media1");
            //}

            Console.WriteLine("mediaListe: " + mediaListe.Count());
            Console.WriteLine("userListe: " + userListe.Count());
            Console.WriteLine("evalListe: " + evalListe.Count());
            Console.WriteLine("favorisListe: " + favorisListe.Count());

            // function removeUser(user) {
            evalListe.RemoveAll(x => x.UserId == user2.Id);
            favorisListe.RemoveAll(x => x.UserId == user2.Id);
            userListe.Remove(user2);
            Console.WriteLine("\n\ndeleted user2");
            //}

            Console.WriteLine("mediaListe: " + mediaListe.Count());
            Console.WriteLine("userListe: " + userListe.Count());
            Console.WriteLine("evalListe: " + evalListe.Count());
            Console.WriteLine("favorisListe: " + favorisListe.Count());

            // function removeEval(eval) {
            evalListe.Remove(eval3);
            Console.WriteLine("\n\ndeleted eval3");
            //}

            Console.WriteLine("mediaListe: " + mediaListe.Count());
            Console.WriteLine("userListe: " + userListe.Count());
            Console.WriteLine("evalListe: " + evalListe.Count());
            Console.WriteLine("favorisListe: " + favorisListe.Count());

            // function removeFav(fav) {
            favorisListe.Remove(fav3);
            Console.WriteLine("\n\ndeleted fav3");
            //}

            Console.WriteLine("mediaListe: " + mediaListe.Count());
            Console.WriteLine("userListe: " + userListe.Count());
            Console.WriteLine("evalListe: " + evalListe.Count());
            Console.WriteLine("favorisListe: " + favorisListe.Count());

            Console.WriteLine("\n\nGET COTE: media1");
            Console.WriteLine(evalListe.Count > 0 ? (byte)Math.Round((double)(evalListe.Select(x => x.Cote).Aggregate((a, b) => a += b) / evalListe.Count)) : (byte)0);
            
            Console.WriteLine("\n\nseriliser tout");
            File.WriteAllText(@$"{pathDossierSerial}\{pathMedias}", JsonConvert.SerializeObject(mediaListe, Formatting.Indented));
            File.WriteAllText(@$"{pathDossierSerial}\{pathUtilisateurs}", JsonConvert.SerializeObject(userListe, Formatting.Indented));
            File.WriteAllText(@$"{pathDossierSerial}\{pathEvaluations}", JsonConvert.SerializeObject(evalListe, Formatting.Indented));
            File.WriteAllText(@$"{pathDossierSerial}\{pathFavoris}", JsonConvert.SerializeObject(favorisListe, Formatting.Indented));


            Console.WriteLine("\n\nDÉseriliser tout");


            List<Media> mediaListe2 = new List<Media>(); // mediaId pis c toute
            List<Utilisateur> userListe2 = new List<Utilisateur>(); // users pis c toute

            List<Evaluation> evalListe2 = new List<Evaluation>(); // evals: cote, id, identifiantUser
            List<Favoris> favorisListe2 = new List<Favoris>(); // evals: cote, id, identifiantUser

            mediaListe2 = JsonConvert.DeserializeObject<List<Media>>(File.ReadAllText(@$"{pathDossierSerial}\{pathMedias}"));
            userListe2 = JsonConvert.DeserializeObject<List<Utilisateur>>(File.ReadAllText(@$"{pathDossierSerial}\{pathUtilisateurs}"));
            evalListe2 = JsonConvert.DeserializeObject<List<Evaluation>>(File.ReadAllText(@$"{pathDossierSerial}\{pathEvaluations}"));
            favorisListe2 = JsonConvert.DeserializeObject<List<Favoris>>(File.ReadAllText(@$"{pathDossierSerial}\{pathFavoris}"));

            Console.WriteLine("mediaListe: " + mediaListe2.Count());
            Console.WriteLine("userListe: " + userListe2.Count());
            Console.WriteLine("evalListe: " + evalListe2.Count());
            Console.WriteLine("favorisListe: " + favorisListe2.Count());
            /*
             * Liste MediaId
             * Liste UserId
             * Liste Eval
             * Liste Favoris
             * 
             * 
             * ajouter GOOD
             * get GOOD
             * modifier
             * supprimer MediaId/UserId/Eval
             * céréales mmmm :)
             

            Console.WriteLine(mediaListe2.Select(x => x.ToString()).Aggregate((a, b) => a += b + "\n\n"));*/

            Catalogue catalogue = new Catalogue();
            CatalogueUtilisateur catalogueUtilisateur = new CatalogueUtilisateur();
            CatalogueEvaluation catalogueEvaluation = new CatalogueEvaluation();
            CatalogueFavoris catalogueFavoris = new CatalogueFavoris();


            Media test = new Media("Smooth Criminal", Types.POP, 1001032, 10, "Micheal Jackson", "Micheal Jakson", "Path extrait", "Path full", "Path image");
            Media test2 = new Media("heart shaped box", Types.ROCK, 11032, 120, "Nirvana", "Nirvana", "Path extrait", "Path full", "Path image");
            Media test3 = new Media("Imagine", Types.CLASSIQUE, 10, 1120, "John Lennon", "John Lennon", "Path extrait", "Path full", "Path image");
            Media test4 = new Media("Smooth Criminal", Types.POP, 1001032, 10, "Micheal Jackson", "Micheal Jackson", "Path extrait", "Path full", "Path image");

            test.DateRealisation = 2198702198021980321;
            Console.WriteLine(DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Console.WriteLine(test.DateRealisation);
            

            Utilisateur felix = new Utilisateur("FB", "abc123", "Blanchette", "Félix", Role.TECHNICIEN);
            Utilisateur maek = new Utilisateur("ML", "abc123", "Lorman", "Maëk", Role.ADMIN);
            Utilisateur lcb = new Utilisateur("LCB", "abc123", "Biron", "Louis-charles", Role.UTILISATEUR);

            //affichage utilisateurs
            Console.WriteLine("=========================================================");
            Console.WriteLine("Affichage des utilisateurs:\n\n");
            Console.WriteLine(felix.ToString() + "\n\n" + maek.ToString() + "\n\n" + lcb.ToString());
            Console.WriteLine("=========================================================\n");


            Evaluation ev1 = new Evaluation(maek, test2, 100);
            Evaluation ev2 = new Evaluation(felix, test, 11);
            Evaluation ev3 = new Evaluation(felix, test3, 121);
            Evaluation ev4 = new Evaluation(lcb, test, 120);

            catalogue.Ajouter(test);
            catalogue.Ajouter(test2);
            catalogue.Ajouter(test3);

            Console.WriteLine("Tentative d'ajouter un mediaId qui est déja dans le catalogue...\n");
            catalogue.Ajouter(test4);
            Console.WriteLine();

            Console.WriteLine("Ajout des utilisateurs das la liste des utilisateurs...\n");

            catalogueUtilisateur.Ajouter(felix);
            catalogueUtilisateur.Ajouter(lcb);
            catalogueUtilisateur.Ajouter(maek);
            Console.WriteLine();

            Console.WriteLine("Ajout des evaluations dans la liste des evaluations...\n");

            catalogueEvaluation.AjouterEvaluation(ev1);
            catalogueEvaluation.AjouterEvaluation(ev2);
            catalogueEvaluation.AjouterEvaluation(ev3);
            catalogueEvaluation.AjouterEvaluation(ev4);
            Console.WriteLine();

            Console.WriteLine("sauvegarde/seréalisation...\n");
            catalogue.Sauvegarder(pathMedias, pathDossierSerial);
            catalogueUtilisateur.Sauvegarder(pathUtilisateurs, pathDossierSerial);
            catalogueEvaluation.Sauvegarder(pathEvaluations, pathDossierSerial);
            Console.WriteLine();

            Console.WriteLine("Affichage des catalogues/listes");
            Console.WriteLine($"Catalogue mediaId:\n {catalogue} \n");
            Console.WriteLine($"Catalogue utilisateurs:\n {catalogueUtilisateur} \n");
            Console.WriteLine($"Catalogue evaluations:\n {catalogueEvaluation} \n");


            Console.WriteLine("Suppression du catalogue mediaId...");

            catalogue.Supprimer();

            Console.WriteLine($"Catalogue mediaId:\n {catalogue} \n");



            Console.WriteLine("déseréalisation...\n");
            catalogue.Ajouter(pathMedias, pathDossierSerial);
            catalogueUtilisateur.Ajouter(pathUtilisateurs, pathDossierSerial);
            catalogueEvaluation.Ajouter(pathEvaluations, pathDossierSerial);
            catalogueFavoris.Ajouter(pathFavoris, pathDossierSerial);

            Console.WriteLine("Affichage apres déserialisation");
            Console.WriteLine(catalogue.ToString());
            Console.WriteLine(catalogueUtilisateur.ToString());
            Console.WriteLine(catalogueEvaluation.ToString());
            Console.WriteLine(catalogueFavoris.ToString());
        }
    }
}