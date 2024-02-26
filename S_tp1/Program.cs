﻿using static S_tp1.Role;
using Newtonsoft.Json;

namespace S_tp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TP1 d'application web\n");
            

            Catalogue catalogue = new Catalogue();
            CatalogueUtilisateur catalogueUtilisateur = new CatalogueUtilisateur();
            CatalogueEvaluation catalogueEvaluation = new CatalogueEvaluation();


            Media test = new Media("testLOL", Media.Types.POP, 1001032, 10, "ads", "asddsa", "asd", new List<Evaluation>(), "apap", "1132sad");
            Media test2 = new Media("testLOL2");
            Media test3 = new Media("testLOL3");

            Utilisateur j = new Utilisateur("JohnyX", "abc123", "Test", "Johny", Utilisateur.RoleUtilisateur.TECHNICIEN);
            Utilisateur bob = new Utilisateur("bob", "bob", "bob", "bob", Utilisateur.RoleUtilisateur.ADMIN);
            Utilisateur j2 = new Utilisateur("JohnyX2", "abc123", "Test", "Johny", Utilisateur.RoleUtilisateur.UTILISATEUR);

            Evaluation ev1 = new Evaluation(bob, test2, 100);
            Evaluation ev2 = new Evaluation(j, test, 12);

            catalogue.Ajouter(test);
            catalogue.Ajouter(test2);
            catalogue.Ajouter(test3);

            catalogueUtilisateur.AjouterListe(j);
            catalogueUtilisateur.AjouterListe(j2);
            catalogueUtilisateur.AjouterListe(bob);

            catalogueEvaluation.AjouterList(ev1);
            catalogueEvaluation.AjouterList(ev2);


            catalogue.Sauvegarder("test.json");
            catalogueUtilisateur.Sauvegarder("testU.json");
            catalogueEvaluation.Sauvegarder("testE.json");


            catalogue.Ajouter("test.json");
            catalogueUtilisateur.Ajouter("testU.json");
            catalogueEvaluation.Ajouter("testE.json");

        }
    }
}