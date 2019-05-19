using Final_Project.Parking;
using Final_Project.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Controleurs;
using Final_Project.Enums;
using Final_Project.Exceptions.Parking;

namespace Final_Project
{
    public class GestionFlotte
    {
        private readonly List<Vehicule> vehiculeList;
        private readonly List<Client> clientList;
        private readonly List<Trajet> trajetList;
        private readonly List<Parking.Parking> parkingList;
        private readonly Controleurs.IControleur controleurV;
        private readonly Controleurs.IControleur controleurC;
        private readonly Controleurs.IControleur controleurM;

        public GestionFlotte()
        {
            vehiculeList = new List<Vehicule>();
            clientList = new List<Client>();
            trajetList = new List<Trajet>();
            parkingList = new List<Parking.Parking>();
            controleurC = new Controleur(this);
            controleurM = new Controleur(this);
            controleurV = new Controleur(this);
            InitParkings();
            init();
        }

        public void init()
        {
            /*AjoutVehicule(new Voiture("Peugeot", "407", 45000,"rouge", 5, 250, TypeVoiture.Berline));
            AjoutVehicule(new Voiture("Renault", "clio", 5000, "rouge", 3, 150, TypeVoiture.Break));
            AjoutVehicule(new Voiture("Renault", "Megane", 0, "bleu", 3, 90, TypeVoiture.Break));
            AjoutVehicule(new Voiture("Peugeot", "208", 0, "bleu nuit", 3, 90, TypeVoiture.Break));
            AjoutVehicule(new Voiture("Peugeot", "807", 0, "violet", 5, 150, TypeVoiture.Monospace));
            AjoutVehicule(new Moto("Kawazaki", "Z650", 0, "Gris", 649));
            AjoutVehicule(new Camion("Citroeine", "Berlingo", 0, "Gris", 17));
            List<EPermis> permis = new List<EPermis>();
            permis.Add(EPermis.A);
            permis.Add(EPermis.B);
            clientList.Add(new Client("Latif", "Waïl", "18 square jules cesar 95120", 3, permis));
            permis.Remove(EPermis.B);
            clientList.Add(new Client("Dechane", "Sanaâ", "15 rue feulifeu argentueil", 3, permis));
            clientList.Add(new Client("Schaub", "Yannis", "Pierrefitte", 3, permis));
            clientList.Add(new Client("El-Haddad", "Imrane", "Creil", 3, permis));
            clientList.Add(new Client("famille test", "test", "test ville", 3, permis));

            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "Latif"), vehiculeList.Find(vehicule => vehicule.Modele == "407"), 500, new DateTime(2019,12,3)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "407"));
            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "Dechane"), vehiculeList.Find(vehicule => vehicule.Modele == "clio"), 1500, new DateTime(2019, 2, 3)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "clio"));
            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "Schaub"), vehiculeList.Find(vehicule => vehicule.Modele == "208"),8500, new DateTime(2019, 12, 24)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "208"));
            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "El-Haddad"), vehiculeList.Find(vehicule => vehicule.Modele == "807"), 250, new DateTime(2015, 12, 3)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "807"));
            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "famille test"), vehiculeList.Find(vehicule => vehicule.Modele == "Megane"), 5000, new DateTime(2019, 5, 3)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "Megane"));
            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "Latif"), vehiculeList.Find(vehicule => vehicule.Modele == "407"), 500, new DateTime(2019, 12, 5)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "407"));
            trajetList.Add(new Trajet(clientList.Find(client => client.Nom == "Latif"), vehiculeList.Find(vehicule => vehicule.Modele == "407"), 500, new DateTime(2019, 1, 3)));
            ControleurV.Verifier(vehiculeList.Find(vehicule => vehicule.Modele == "407"));*/
        }

        /* Properties */

        public List<Vehicule> VehiculeList => vehiculeList;
        public List<Client> ClientList => clientList;
        public List<Trajet> TrajetList => trajetList;

        public List<Parking.Parking> ParkingList => parkingList;

        public IControleur ControleurV => controleurV;

        public IControleur ControleurC => controleurC;

        public IControleur ControleurM => controleurM;

        /* Public Methodes */

        /**
         * Ajouter un vehicule à la liste de véhicule du gestionnaire de flotte
         * @Params vehicule   Vehicule : le vehicule à ajouter
         */
        public void AjoutVehicule(Vehicule vehicule)
        {
            vehicule.Place = GetPlaceDisp();
            vehiculeList.Add(vehicule);
        }

        public List<Parking.Parking> GetParkingsDisp()
        {
            List<Parking.Parking> list = new List<Parking.Parking>();

            parkingList.ForEach(parking =>
            {
                if (!parking.IsPlein)
                    list.Add(parking);
            });

            return list;
        }

        public Place GetPlaceDisp()
        {
            int i = 0;
            while (i < parkingList.Count && parkingList[i].IsPlein) { i++; }

            if (i == parkingList.Count && parkingList[i - 1].IsPlein)
                throw new ErreurPlaceIndisp();

            return i == parkingList.Count ? parkingList[i - 1].GetPlaceDisp() : parkingList[i].GetPlaceDisp();
        }


        /* Private Methodes */

        private void InitParkings()
        {
            parkingList.Add(new Parking.Parking(Utils.Delegate.RemplirTabPlaceDisp, "Roissy"));
            for (int i = 1; i < 21; i++)
            {
                parkingList.Add(new Parking.Parking(Utils.Delegate.RemplirTabPlaceDisp, $"Paris {i}"));
            }
            parkingList.Add(new Parking.Parking(Utils.Delegate.RemplirTabPlaceDisp, "Orly"));
        }

    }
}