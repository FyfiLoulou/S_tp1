using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace S_tp1
{
    internal class Program
    {

        private const string pathMedias = "s_medias.json",
        pathUtilisateurs = "s_utilisateurs.json",
        pathEvaluations = "s_evalutations.json",
        pathFavoris = "s_favoris.json";
        private static string pathDossierSerial = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\serial";




        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web\n");

            List<Media> mediaListe = new List<Media>(); // mediaId pis c toute
            List<Utilisateur> userListe = new List<Utilisateur>(); // users pis c toute

            List<Evaluation> evalListe = new List<Evaluation>(); // evals: cote, id, identifiantUser
            List<Favoris> favorisListe = new List<Favoris>(); // evals: cote, id, identifiantUser


            Media media1 = new Media("steawkc");
            Utilisateur user1 = new Utilisateur("asdasda", "asdasd");
            Evaluation eval1 = new Evaluation(user1.Id, media1.Id, 87);
            Favoris fav1 = new Favoris(user1.Id, media1.Id);
            Media media2 = new Media("steawkc2");
            Utilisateur user2 = new Utilisateur("asdasda332", "asdasd3123");
            Evaluation eval2 = new Evaluation(user2.Id, media1.Id, 8);
            Favoris fav2 = new Favoris(user2.Id, media2.Id);
            Media media3 = new Media("steawkc3");
            Utilisateur user3 = new Utilisateur("asdasda12", "asdasd12");
            Evaluation eval3 = new Evaluation(user3.Id, media1.Id, 50);
            Favoris fav3 = new Favoris(user3.Id, media3.Id);

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

            Console.WriteLine("Ajouter: GOOD");
            Console.WriteLine("mediaListe: " + mediaListe.Count());
            Console.WriteLine("userListe: " + userListe.Count());
            Console.WriteLine("evalListe: " + evalListe.Count());
            Console.WriteLine("favorisListe: " + favorisListe.Count());

            Console.WriteLine("\nget: DONE");
            // a partir d'un eval → get MediaId et UserId
            //eval1;    
            Media mediaQuery = mediaListe.Where(x => x.Id == eval1.MediaId).ToList()[0];
            Utilisateur userQuery = userListe.Where(x => x.Id == eval1.UserId).ToList()[0];

            Console.WriteLine(eval1);
            Console.WriteLine(mediaQuery);
            Console.WriteLine(userQuery);

            Console.WriteLine("\nmodifier: a revoir ???)()))");
            //user1.Pseudo = "alloBOB";
            //Console.WriteLine("user1 → "+user1.Id);
            //media1.Complet = "protumanux";
            //Console.WriteLine("media1 → complet" + media1.Complet);

            Console.WriteLine("\nsupprimer: TODO 💀💀");
            /*// function removeMedia(media) {
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
            //}*/

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

            List<Favoris> a = new List<Favoris>
            {
                new Favoris("a", "b"),
                new Favoris("a", "b")
            };
            Console.WriteLine(JsonConvert.SerializeObject(a, Formatting.Indented));

            Console.WriteLine("\n\nDÉseriliser tout");
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
             */

            Catalogue catalogue = new Catalogue();
            CatalogueUtilisateur catalogueUtilisateur = new CatalogueUtilisateur();
            CatalogueEvaluation catalogueEvaluation = new CatalogueEvaluation();

            /*Utilitaire utilitaire = new Utilitaire(catalogue, catalogueUtilisateur, catalogueEvaluation);

            MediaId test = new MediaId("Smooth Criminal", Types.POP, 1001032, 10, "Micheal Jackson", "Micheal Jakson", "Path extrait", "Path full", "Path image");
            MediaId test2 = new MediaId("heart shaped box", Types.ROCK, 11032, 120, "Nirvana", "Nirvana", "Path extrait", "Path full", "Path image");
            MediaId test3 = new MediaId("Imagine", Types.CLASSIQUE, 10, 1120, "John Lennon", "John Lennon", "Path extrait", "Path full", "Path image");
            MediaId test4 = new MediaId("Smooth Criminal", Types.POP, 1001032, 10, "Micheal Jackson", "Micheal Jackson", "Path extrait", "Path full", "Path image");

            test.DateRealisation = 2198702198021980321;
            Console.WriteLine(DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Console.WriteLine(test.DateRealisation);
            

            UserId felix = new UserId("FB", "abc123", "Blanchette", "Félix", Role.TECHNICIEN);
            UserId maek = new UserId("ML", "abc123", "Lorman", "Maëk", Role.ADMIN);
            UserId lcb = new UserId("LCB", "abc123", "Biron", "Louis-charles", Role.UTILISATEUR);

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

            catalogueUtilisateur.AjouterListe(felix);
            catalogueUtilisateur.AjouterListe(lcb);
            catalogueUtilisateur.AjouterListe(maek);
            Console.WriteLine();

            Console.WriteLine("Ajout des evaluations dans la liste des evaluations...\n");

            catalogueEvaluation.AjouterEvaluation(ev1);
            catalogueEvaluation.AjouterEvaluation(ev2);
            catalogueEvaluation.AjouterEvaluation(ev3);
            catalogueEvaluation.AjouterEvaluation(ev4);
            Console.WriteLine();

            Console.WriteLine("sauvegarde/seréalisation...\n");
            catalogue.Sauvegarder(pathMedias, pathDossierSerial);
            catalogueUtilisateur.Sauvegarder(pathUtilisateurs);
            catalogueEvaluation.Sauvegarder(pathEvaluations);
            Console.WriteLine();

            Console.WriteLine("Affichage des catalogues/listes");
            Console.WriteLine($"Catalogue mediaId:\n {catalogue} \n");
            Console.WriteLine($"Catalogue utilisateurs:\n {catalogueUtilisateur} \n");
            Console.WriteLine($"Catalogue evaluations:\n {catalogueEvaluation} \n");


            Console.WriteLine("Suppression du catalogue mediaId...");

            catalogue.Supprimer();

            Console.WriteLine($"Catalogue mediaId:\n {catalogue} \n");



            Console.WriteLine("déseréalisation...\n");
            utilitaire.deserializer(pathMedias, pathUtilisateurs, pathEvaluations);

            Console.WriteLine("Affichage apres déserialisation");
            Console.WriteLine(catalogue);*/
        }
    }
}