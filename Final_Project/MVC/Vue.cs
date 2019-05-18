using Final_Project.Enums;
using Final_Project.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Parking;

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
            Console.Clear();
            Console.WriteLine("Choisissez parmi ces choix : ");
            Console.WriteLine("1- Visualisation");
            Console.WriteLine("2- Ajout / Suppression");
            Console.WriteLine("3- Rendre Véhicule");

            switch (Console.ReadLine())
            {
                case "1":
                    AfficherVisu();
                    break;
                case "2":
                    AfficherAjoutSup();
                    break;
                case "3":
                    AfficherRendreVehicule();
                    break;
                default:
                    EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherAccueil, "Erreur choix invalide");
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

            switch (Console.ReadLine())
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
                    EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherAccueil,
                        "Erreur choix invalide");
                    break;
            }
        }

        /**
        * Affiche les stats du gestionnaire de flotte
        */
        private void AfficherStats()
        {
            Console.Clear();
            Console.WriteLine("Stats");
            Console.WriteLine("     Nombre de Vehicules : {0}", Vehicule.NbVehicule);
            Console.WriteLine("     Nombre de Clients   : {0}", Client.NbClient);
            Console.WriteLine("     Nombre de Trajets   : {0}", Trajet.NbTrajet);

            EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
        }

        /**
        * Affiche une list de clients
        */
        private void AfficherClients()
        {
            Console.Clear();
            gestionFlotte.ClientList.ForEach(li =>
            {
                AfficherClient(li);
            });

            EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
        }

        /**
        * Affiche un Client
        */
        private void AfficherClient()
        {
            Client choisi = null;

            Console.Clear();
            Console.WriteLine("Saisir le numéro du client que vous voulez afficher parmis la list suivante :");
            gestionFlotte.ClientList.ForEach(client=>Console.Write($" {client.NClient} |"));

            Console.Write("\n Numéro Client : ");
            try
            {
                choisi = controller.GetClient(Console.ReadLine());

                AfficherClient(choisi);

                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherClient, e.Message);
            }
        }

        public void AfficherClient(Client client)
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.Write($" ID : {client.NClient} \n NOM : {client.Nom} \n PRENOM : {client.Prenom} \n ADRESSE : {client.Adresse} \n PERMIS : ");

            client.PermisList.ForEach(permis => Console.Write(permis + ", "));

            Console.WriteLine($"\n COÛT TOTAL DES LOCATIONS : {client.TotalLoc}");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }


        /**
        * Affiche une list de vehicule
        */
        private void AfficherVehicules()
        {
            Console.Clear();
            gestionFlotte.VehiculeList.ForEach(li => {
                AfficherVehicule(li);
            });

            EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
        }

        /**
        * Affiche un vehicule
        */
        private void AfficherVehicule()
        {
            Console.Clear();
            Vehicule choisi = null;
            Console.WriteLine("Saisir le numéro du véhicule que vous voulez afficher parmis la list suivante : ");
            gestionFlotte.VehiculeList.ForEach(vehicule => Console.Write($" {vehicule.NVehicule} |"));
            Console.Write("\n Numéro Véhicule : ");
            try
            {
                choisi = controller.GetVehicule(Console.ReadLine());
           
                AfficherVehicule(choisi);

                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherVehicule, e.Message);
            }
        }

        public void AfficherVehicule(Vehicule vehicule)
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            if (vehicule is Voiture)

            {
                Console.WriteLine(((Voiture)vehicule).ToString());
            }
            if (vehicule is Moto)

            {
                Console.WriteLine(((Moto)vehicule).ToString());
            }
            if (vehicule is Camion)

            {
                Console.WriteLine(((Camion)vehicule).ToString());
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        /**
        * Affiche une list de trajet
        */
        private void AfficherTrajets()
        {
            Console.Clear();
            gestionFlotte.TrajetList.ForEach(li => {
                AfficherTrajet(li);
            });

            EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
        }

        /**
        * Affiche un Trajet
        */
        private void AfficherTrajet()
        {
            Console.Clear();
            Trajet choisi = null;
            Console.WriteLine("Saisir le numéro de trajet que vous voulez afficher parmis la list suivante :");
            gestionFlotte.TrajetList.ForEach(trajet => Console.Write($" {trajet.NTrajet} |"));
            Console.Write("\n Numéro Trajet : ");
            try
            {
                choisi = controller.GetTrajet(Console.ReadLine());

                AfficherTrajet(choisi);

                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherTrajet, e.Message);
            }
        }

        private void AfficherTrajet(Trajet trajet)
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine(
                $" N° TRAJET :{trajet.NTrajet} \n N° CLIENT {trajet.Client.NClient} \n N° VEHICULE: {trajet.Vehicule.NVehicule} \n DISTANCE: {trajet.Distance} \n COUT: {trajet.Cout}");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }
        /****** Fin Layout Visualisation ******/


        /****** Layout Ajout/Sup ******/

        /**
        * Affiche le layout Ajout/Sup
        */

        private void AfficherAjoutSup()
        {
            Console.Clear();
            Console.WriteLine("Ajout / Suppression ");
            Console.WriteLine("Choisissez parmi ces choix : ");
            Console.WriteLine("     1- Ajouter client");
            Console.WriteLine("     2- Supprimer client");
            Console.WriteLine("     3- Ajouter trajet");
            Console.WriteLine("     4- Supprimer trajet");
            Console.WriteLine("     5- Ajouter véhicule");
            Console.WriteLine("     6- Supprimer véhicule");
            Console.WriteLine("     #- Accueil");
            string saisie = Console.ReadLine();
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
                    EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherAjoutSup, "ERREUR : Saisie invalide");
                    break;
            }
        }

        /**
        * Ajouter un client
        */
        private void AjoutClient()
        {
            Console.Clear();

            Console.WriteLine("Saisir le nom du Client que vous voulez ajouter");
            string nom = Console.ReadLine();
            Console.WriteLine("Saisir le prénom du client");
            string prenom = Console.ReadLine();
            Console.WriteLine("Saisir l'adresse du client");
            string adresse = Console.ReadLine();
            Console.Write("Saisir les permis parmi cette liste (séparé chaque permis par une virgule) { ");

            AfficherEnum<EPermis>();

            Console.WriteLine(" } :");
            string permis = Console.ReadLine();
            List<string> resultP = permis.Split(',').ToList();
            try
            {
                controller.AjoutClient(nom, prenom, adresse, resultP);
                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AjoutClient, e.Message);
            }
        }

        /**
        * Supprimer un Clients
        */
        private void SupClient()
        {
            Console.Clear();
            Console.WriteLine("Saisir le numéro de Client que vous voulez supprimer");
            try
            {
                controller.SupClient(Console.ReadLine());

                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", SupClient, e.Message);
            }
        }

        /**
        * Ajouter un vehicule
        */
        private void AjoutVehicule()
        {
            Console.Clear();

            Console.WriteLine("Saisir la marque de Véhicule que vous voulez ajouter");
            string marque = Console.ReadLine();
            Console.WriteLine("Saisir le modèle de la voiture");
            string modele = Console.ReadLine();
            Console.WriteLine("Saisir le nombre de km du vehicule");
            string km = Console.ReadLine();
            Console.WriteLine("Saisir la couleur du véhicule");
            string couleur = Console.ReadLine();

            Console.WriteLine("Saisir le type de Véhicule que voulez vous ajouter");
            Console.WriteLine("     1- Voiture");
            Console.WriteLine("     2- Moto");
            Console.WriteLine("     3- Camion");
            string choix = Console.ReadLine();
            try
            {
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Saisir le nombre de portes de la voiture");
                        string nbPorte = Console.ReadLine();
                        Console.WriteLine("Saisir la puissance de la voiture");
                        string puissance = Console.ReadLine();
                        Console.WriteLine("Saisir le type de la voiture parmi cette liste");
                        AfficherEnum<TypeVoiture>();
                        string type = Console.ReadLine();
                        controller.AjoutVoiture(couleur, km, marque, modele, nbPorte, puissance, type);
                        break;
                    case "2":
                        Console.WriteLine("Saisir le cylindre de la moto");
                        string cylindre = Console.ReadLine();
                        controller.AjoutMoto(couleur, km, marque, modele, cylindre);
                        break;
                    case "3":
                        Console.WriteLine("Saisir la capacité du camion");
                        string cap = Console.ReadLine();
                        controller.AjoutCamion(couleur, km, marque, modele, cap);
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AjoutVehicule, e.Message);
            }
        }

        /**
        * Supprimer un vehicule
        */
        private void SupVehicule()
        {
            Console.Clear();
            Console.WriteLine("Saisir le numéro de Vehicule que vous voulez supprimer");
            try
            {
                controller.SupVehicule(Console.ReadLine());
                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", SupVehicule, e.Message);
            }
        }

        /**
        * Ajouter un trajet
        */
        private void AjoutTrajet()
        {
            Console.WriteLine("Saisir le numéro de client associé au trajet que vous voulez ajouter");
            string numClient = Console.ReadLine();
            Console.WriteLine("Saisir le numéro de véhicule associé au trajet");
            string numVehi = Console.ReadLine();
            Console.WriteLine("Saisir la distance de ce trajet");
            string dist = Console.ReadLine();
            try
            {
                controller.AjoutTrajet(numClient, numVehi, dist);

                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil, null);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AjoutTrajet, e.Message);
            }
        }

        /**
        * Supprimer un Trajet
        */
        private void SupTrajet()
        {
            Console.Clear();
            Console.WriteLine("Saisir le numéro de Trajet que vous voulez supprimer");
            try
            {
                controller.SupTrajet(Console.ReadLine());
                EndFunction("Veuillez appuyez sur une touche pour retourner à l'accueil ...", AfficherAccueil);
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", SupTrajet, e.Message);
            }
        }

        /****** Fin Layout Ajout/Sup ******/


        /****** Layout Rendre Vehicule ******/

        /**
        * Retourner un vehicule  fin de location
        */

        private void AfficherRendreVehicule()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Saisir le numero de trajet concernée");
                string nTrajet = Console.ReadLine();
                Parking.Parking parking = SaisirParking();
                Console.Clear();
                Place place = SaisirPlace(parking);

                controller.RendreVehicule(nTrajet, place);

            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", AfficherRendreVehicule, e.Message);
            }
        }


        private Parking.Parking SaisirParking()
        {
            List<Parking.Parking> lParking = gestionFlotte.GetParkingsDisp();
            if (lParking.Count == 0)
                Console.WriteLine("aucune place de libre");
            else
            {
                Console.WriteLine("Selectionnez un parking parmis la liste suivante :");
                lParking.ForEach(parking =>
                {
                    Console.WriteLine($"\t-{parking.Nom}");
                });

                string nParking = Console.ReadLine();
                try
                {
                    return controller.SelectParking(nParking, lParking);
                }
                catch (Exception e)
                {
                    EndFunction("Veuillez appuyez sur une touche pour continuer ...", null, e.Message);
                    return SaisirParking();
                }
            }

            return null;
        }

        private Place SaisirPlace(Parking.Parking p)
        {
            Console.WriteLine("Selectionnez une place parmis la liste suivante :");
            for (int i = 0; i < p.Places.Length; i++)
            {
                if (p.Places[i].IsDisponible)
                    Console.WriteLine($"\t-A{i}");
            }

            string nPlace = Console.ReadLine();

            try
            {
                return controller.SelectPlace(nPlace, p.GetPlacesDisp());
            }
            catch (Exception e)
            {
                EndFunction("Veuillez appuyez sur une touche pour continuer ...", null, e.Message);
                return SaisirPlace(p);
            }
        }


        /****** Fin Layout Rendre Vehicule ******/






        /****** Methodes Annexe *****/

        private void AfficherEnum<T>()
        {
            foreach (string i in Enum.GetNames(typeof(T)))
            {
                Console.Write("{0}, ", i);
            }
        }


        private void EndFunction(string msg, Action After = null, string before = null)
        {
            if (before != null)
                Console.WriteLine(before);
            Console.WriteLine(msg);
            Console.ReadKey();

            After?.Invoke();
        }


        private void AfficherPlacesDisp(Parking.Parking parking)
        {
            List<Place> placesDisp = parking.GetPlacesDisp();

            if (placesDisp.Count == 0)
                Console.WriteLine("Aucune Place Disponible dans ce parking");
            else
            {
                placesDisp.ForEach(num =>
                {
                    Console.WriteLine($"{num}- A{num}");
                });
            }
        }
        /****** Fin Methodes Annexe *****/
    }
}