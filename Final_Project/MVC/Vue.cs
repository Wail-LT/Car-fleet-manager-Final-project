using Final_Project.Vehicules;
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
            AfficherAccueil();
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
            Console.WriteLine("     1- Stats");
            Console.WriteLine("     2- List Clients");
            Console.WriteLine("     3- Client");
            Console.WriteLine("     4- List Véhicules");
            Console.WriteLine("     5- Véhicule");
            Console.WriteLine("     6- List Trajets");
            Console.WriteLine("     7- Trajet");
            Console.WriteLine("     #- Accueil");
            string saisie = Console.ReadLine();
            switch (saisie)
            {
                case "1":
                    AfficherStats();
                    break;
                case "2":
                    AfficherClients();
                    break;
                case "3":
                    AfficherClient();
                    break;
                case "4":
                    AfficherVehicules();
                    break;
                case "5":
                    AfficherVehicule();
                    break;
                case "6":
                    AfficherTrajets();
                    break;
                case "7":
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
        * Affiche les stats du gestionnaire de flotte
        */
        private void AfficherStats()
        {
            Console.WriteLine("Stats");
            Console.WriteLine("     Nombre de Vehicules : {0}", gestionFlotte.LastNumVehicule+1);
            Console.WriteLine("     Nombre de Clients   : {0}", gestionFlotte.LastNumClient + 1);
            Console.WriteLine("     Nombre de Trajets   : {0}", gestionFlotte.LastNumTrajet + 1);
        }

        /**
        * Affiche une list de clients
        */
        private void AfficherClients()
        {
            gestionFlotte.ClientList.ForEach(li => {
                Console.Write("\t ID :{0}  NOM :{1} , PRENOM : {2} , ADRESSE :{3}, PERMIS : ", li.NClient, li.Nom, li.Prenom, li.Adresse);
                li.PermisList.ForEach(permis => Console.Write(permis + ", "));
                Console.Write(" TOTAL LOC :{0}",li.TotalLoc);
                Console.WriteLine();
             });                    
        }

        /**
        * Affiche un Client
        */
        private void AfficherClient()
        {
            Console.WriteLine("Quel est le numéro du client que vous voulez afficher ?");
            int numClient = int.Parse(System.Console.ReadLine());
            Client choisi =gestionFlotte.GetClient(numClient);
            Console.Write("\t ID :{0}  NOM :{1} , PRENOM : {2} , ADRESSE :{3}, PERMIS : ",choisi.NClient,choisi.Nom,choisi.Prenom,choisi.Adresse);
            choisi.PermisList.ForEach(permis => Console.Write(permis + ", "));
            Console.Write(" TOTAL LOC :{0}", choisi.TotalLoc);

        }

        /**
        * Affiche une list de vehicule
        */
        private void AfficherVehicules()
        {
            gestionFlotte.VehiculeList.ForEach(li => {
                Console.Write("\t NUM :{0}  MARQUE :{1} , MODELE : {2} , KM :{3}, COULEUR : {4}, DISPONIBLE :{5},COUT :{6}", li.NVehicule, li.Marque, li.Modele, li.Km,li.Couleur,li.IsDisponible,li.Cout);
                Console.WriteLine();
            });

        }

        /**
        * Affiche un vehicule
        */
        private void AfficherVehicule()
        {
            Console.WriteLine("Quel est le numéro du véhicule que vous voulez afficher ?");
            int numVehicule = int.Parse(System.Console.ReadLine());
            Vehicule choisi = gestionFlotte.GetVehicule(numVehicule);
            Console.Write("\t NUM :{0}  MARQUE :{1} , MODELE : {2} , KM :{3}, COULEUR : {4}, DISPONIBLE :{5},COUT :{6}", choisi.NVehicule, choisi.Marque, choisi.Modele, choisi.Km, choisi.Couleur, choisi.IsDisponible,choisi.Cout);
            Console.WriteLine();
        }

        /**
        * Affiche une list de trajet
        */
        private void AfficherTrajets()
        {
            gestionFlotte.TrajetList.ForEach(li => {
                Console.Write("\t N° TRAJET :{0}  N° CLIENT {1} , N° VEHICULE: {2} , DISTANCE: {3}, COUT: {4}", li.NTrajet,li.Client.NClient,li.Vehicule.NVehicule,li.Distance,li.Cout); 
                Console.WriteLine();
            });          
        }

        /**
        * Affiche un Trajet
        */
        private void AfficherTrajet()
        {
            Console.WriteLine("Quel est le numéro de trajet que vous voulez afficher ?");
            int numTrajet = int.Parse(System.Console.ReadLine());
            Trajet choisi = gestionFlotte.GetTrajet(numTrajet);
            Console.Write("\t N° TRAJET :{0}  N° CLIENT {1} , N° VEHICULE: {2} , DISTANCE: {3}, COUT: {4}", choisi.NTrajet, choisi.Client.NClient, choisi.Vehicule.NVehicule, choisi.Distance, choisi.Cout);
            Console.WriteLine();
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
            Console.WriteLine("Quel est le nom de Client que vous voulez ajouter ?");
            string nom = System.Console.ReadLine();
            Console.WriteLine("Quelle est son prenom ?");
            string prenom = System.Console.ReadLine();
            Console.WriteLine("Quelle est son adresse  ?");
            string adresse = System.Console.ReadLine();
            Console.WriteLine("Quels sont ces permis(séparé chaque permis par une virgule)  ?");
            string permis = System.Console.ReadLine();
            List<string> resultP = permis.Split(',').ToList();
            controller.AjoutClient(nom,prenom,adresse,resultP);
        }

        /**
        * Supprimer un Clients
        */
        private void SupClient()
        {
            Console.WriteLine("Quel est le numéro de Client que vous voulez supprimer ?");
            int numClient = int.Parse(System.Console.ReadLine());
            controller.SupClient(numClient);
        }

        /**
        * Ajouter un vehicule
        */
        private void AjoutVehicule()
        {
           
            Console.WriteLine("Quelle est la marque de Véhicule que vous voulez ajouter ?");
            string marque = System.Console.ReadLine();
            Console.WriteLine("Quel est son modèle?");
            string modele = System.Console.ReadLine();
            Console.WriteLine("Quel est le nombre de km du vehicule  ?");
            string km = System.Console.ReadLine();
            Console.WriteLine("Quelle est sa couleur?");
            string couleur = System.Console.ReadLine();

            Console.WriteLine("Quel type de Véhicule voulez vous ajouter ?");
            Console.WriteLine("     1- Voiture");
            Console.WriteLine("     2- Moto");
            Console.WriteLine("     3- Camion");
            string choix = System.Console.ReadLine();
            switch (choix)
            {
                case "1":
                    Console.WriteLine("Quel est le nombre de portes de la voiture  ?");
                    string nbPorte = System.Console.ReadLine();
                    Console.WriteLine("Quelle est sa puissance?");
                    string puissance = System.Console.ReadLine();
                    controller.AjoutVoiture(couleur, km, marque, modele, nbPorte, puissance);
                    break;
                case "2":
                    Console.WriteLine("Quel est le cylindre de la moto  ?");
                    string cylindre = System.Console.ReadLine();
                    controller.AjoutMoto(couleur, km, marque, modele, cylindre);
                    break;
                case "3":
                    Console.WriteLine("Quelle est la capacité du camion  ?");
                    string cap = System.Console.ReadLine();
                    controller.AjoutCamion(couleur, km, marque, modele, cap);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }                  
        }

        /**
        * Supprimer un vehicule
        */
        private void SupVehicule()
        {
            Console.WriteLine("Quel est le numéro de Vehicule que vous voulez supprimer ?");
            int numVehicule = int.Parse(System.Console.ReadLine());
            controller.SupVehicule(numVehicule);
        }

        /**
        * Ajouter un trajet
        */
        private void AjoutTrajet()
        {
            Console.WriteLine("Quel est le numéro de client associé au trajet que vous voulez ajouter ?");
            string numClient = System.Console.ReadLine();
            Console.WriteLine("Quel est le numéro de véhicule associé au trajet ?");
            string numVehi = System.Console.ReadLine();
            Console.WriteLine("Quelle est la distance de ce trajet ?");
            string dist = System.Console.ReadLine();
            controller.AjoutTrajet(numClient, numVehi, dist);
        }

        /**
        * Supprimer un Trajet
        */
        private void SupTrajet()
        {
            Console.WriteLine("Quel est le numéro de Trajet que vous voulez supprimer ?");
            int numTrajet = int.Parse(System.Console.ReadLine());
            controller.SupTrajet(numTrajet);
        }

        /****** Fin Layout Ajout/Sup ******/


        /****** Methodes Annexe *****/




        /****** Fin Methodes Annexe *****/
    }
}