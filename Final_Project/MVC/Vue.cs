using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project
{
    public class Vue : IVue
    {
        private Controller controller;

        private GestionFlotte gestionFlotte;

        public Vue()
        {
            gestionFlotte = new GestionFlotte();
            controller = new Controller(gestionFlotte);
        }


        /** Public Methodes */

        /**
         * Démarre l'interface Utilisateur
         */
        public void Start()
        {

        }


        /** Private Methodes */

        /**
         * Affiche le layout Accueil
         */
        private void AfficherAccueil()
        {
            Console.WriteLine("Choisissez parmi ces choix : ");
            Console.WriteLine("1- Visualisation");
            Console.WriteLine("2- Ajout / Suppression");
            string saisie = System.Console.ReadLine();
            switch (saisie)
            {
                case "1":
                    AfficherVisu();
                    break;
                case "2":
                    AfficherAjoutSup();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }



        /****** Layout Visualisation ******/

        /**
         * Affiche le layout Visualisation
         */
        private void AfficherVisu()
        {
            Console.Clear();
            Console.WriteLine("Visualisation");
            Console.WriteLine("Choisissez parmi ces choix : ");
            Console.WriteLine("     1- List Clients");
            Console.WriteLine("     2- Client");
            Console.WriteLine("     3- List Véhicules");
            Console.WriteLine("     4- Véhicule");
            Console.WriteLine("     5- List Trajets");
            Console.WriteLine("     6- Trajet");
            Console.WriteLine("     #- Accueil");
            string saisie = System.Console.ReadLine();
            switch (saisie)
            {
                case "1":
                    AfficherClients();
                    break;
                case "2":
                    AfficherClient();
                    break;
                case "3":
                    AfficherVehicules();
                    break;
                case "4":
                    AfficherVehicule();
                    break;
                case "5":
                    AfficherTrajets();
                    break;
                case "6":
                    AfficherTrajet();
                    break;
                case "#":
                    AfficherAccueil();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        /**
        * Affiche une list de clients
        */
        private void AfficherClients()
        {
            gestionFlotte.ClientList.ForEach(li => {
                Console.Write("\t ID :{0}  NOM :{1} , PRENOM : {2} , ADRESSE :{3}, PERMIS : ", li.NClient, li.Nom, li.Prenom, li.Adresse);
                li.PermisList.ForEach(permis => Console.Write(permis + ", "));
                Console.WriteLine();
             });                    
        }

        /**
        * Affiche un Clients
        */
        private void AfficherClient()
        {
            Console.WriteLine("Quel est le numéro du client que vous voulez afficher ?");
            int numClient = int.Parse(System.Console.ReadLine());
            Client choisi =gestionFlotte.GetClient(numClient);
            Console.Write("\t ID :{0}  NOM :{1} , PRENOM : {2} , ADRESSE :{3}, PERMIS : ",choisi.NClient,choisi.Nom,choisi.Prenom,choisi.Adresse);
            choisi.PermisList.ForEach(permis => Console.Write(permis + ", "));

        }

        /**
        * Affiche une list de vehicule
        */
        private void AfficherVehicules()
        {

        }

        /**
        * Affiche un vehicule
        */
        private void AfficherVehicule()
        {

        }

        /**
        * Affiche une list de trajet
        */
        private void AfficherTrajets()
        {

        }

        /**
        * Affiche un Trajet
        */
        private void AfficherTrajet()
        {

        }

        /****** Fin Layout Visualisation ******/


        /****** Layout Ajout/Sup ******/

        /**
        * Affiche le layout Ajout/Sup
        */

        private void AfficherAjoutSup()
        {
            Console.WriteLine("Ajout / Suppression ");
            Console.WriteLine("Choisissez parmi ces choix : ");
            Console.WriteLine("     1- Ajouter client");
            Console.WriteLine("     2- Supprimer client");
            Console.WriteLine("     3- Ajouter trajet");
            Console.WriteLine("     4- Supprimer trajet");
            Console.WriteLine("     5- Ajouter véhicule");
            Console.WriteLine("     6- Supprimer véhicule");
            Console.WriteLine("     #- Accueil");
            string saisie = System.Console.ReadLine();
            switch (saisie)
            {
                case "1":
                    AjoutClient();
                    break;
                case "2":
                    SupClient();
                    break;
                case "3":
                    AjoutTrajet();
                    break;
                case "4":
                    SupTrajet();
                    break;
                case "5":
                    AjoutVehicule();
                    break;
                case "6":
                    SupVehicule();
                    break;
                case "#":
                    AfficherAccueil();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        /**
        * Ajouter un client
        */
        private void AjoutClient()
        {

        }

        /**
        * Supprimer un Clients
        */
        private void SupClient()
        {

        }

        /**
        * Ajouter un vehicule
        */
        private void AjoutVehicule()
        {

        }

        /**
        * Supprimer un vehicule
        */
        private void SupVehicule()
        {

        }

        /**
        * Ajouter un trajet
        */
        private void AjoutTrajet()
        {

        }

        /**
        * Supprimer un Trajet
        */
        private void SupTrajet()
        {

        }

        /****** Fin Layout Ajout/Sup ******/


        /****** Methodes Annexe *****/




        /****** Fin Methodes Annexe *****/
    }
}