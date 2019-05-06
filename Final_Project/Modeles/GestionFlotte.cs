using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project
{
    public class GestionFlotte
    {
        private readonly List<Vehicule> vehiculeList;
        private readonly List<Client> clientList;
        private readonly List<Trajet> trajetList;



        public GestionFlotte()
        {
            vehiculeList = new List<Vehicule>();
            clientList = new List<Client>();
            trajetList = new List<Trajet>();
        }


        /* Properties */

        public int LastNumVehicule => vehiculeList.Count - 1;
        public int LastNumClient => clientList.Count - 1;
        public int LastNumTrajet => trajetList.Count - 1;

        public List<Vehicule> VehiculeList => vehiculeList;
        public List<Client> ClientList => clientList;
        public List<Trajet> TrajetList => trajetList;


        /* Public Methodes */

        /**
         * recupérer un vehicule de la liste de véhicules du gestionnaire de flotte
         * @Params  nVehicule   int     : Numéro du vehicule à récupérer
         * @Returns Vehicule : Véhicule recherché
         */
        public Vehicule GetVehicule(int nVehicule)
        {
            return vehiculeList[nVehicule];
        }

        /**
         * recupérer un trajet de la liste de trajets
         * @Params  nTrajet   int     : Numéro du trajet à récupérer
         * @Returns Trajet  : Trajet recherché
         */
        public Trajet GetTrajet(int nTrajet)
        {
            return trajetList[nTrajet];
        }

        /**
         * recupérer un client de la liste de clients
         * @Params  nClient   int     : Numéro du client à récupérer
         * @Returns Client  : Client recherché
         */
        public Client GetClient(int nClient)
        {
            return clientList[nClient];
        }

        /**
         * Ajouter un vehicule à la liste de véhicule du gestionnaire de flotte
         * @Params vehicule   Vehicule : le vehicule à ajouter
         */
        public void AjoutVehicule(Vehicule vehicule)
        {
            vehiculeList.Add(vehicule);
        }

        /**
         * Ajouter un client à la liste de client
         * @Params client   Client : le client à ajouter
         */
        public void AjoutClient(Client client)
        {
            clientList.Add(client);
        }

        /**
         * Ajouter un trajet à la liste de client
         * @Params trajet   Trajet : le trajet à ajouter
         */
        public void AjoutTrajet(Trajet trajet)
        {
            trajetList.Add(trajet);
        }


        /**
         * Supprime un vehicule de la liste de véhicule du gestionnaire de flotte
         * @Params nVehicule   int : numero du vehicule à supprimer
         */
        public void SupVehicule(int nVehicule)
        {
            Vehicule v = vehiculeList[nVehicule];
            List<int> listNTrajet = new List<int>();

            trajetList.ForEach(x =>
            {
                if (x.Vehicule == v) 
                    listNTrajet.Add(x.NTrajet);
            });

            listNTrajet.ForEach(x => SupTrajet(trajetList[x].NTrajet));

            vehiculeList.Remove(v);

            for (int i = nVehicule; i < vehiculeList.Count; i++)
                vehiculeList[i].NVehicule = i;
        }

        /**
         * Supprimer un client à la liste du gestionnaire de flotte
         * @Params nClient int : numéro du client à supprimer
         */
        public void SupClient(int nClient)
        {
            Client c = clientList[nClient];
            List<int> listNTrajet = new List<int>();

            trajetList.ForEach(x =>
            {
                if (x.Client == c)
                    listNTrajet.Add(x.NTrajet);
            });

            listNTrajet.ForEach(x => SupTrajet(trajetList[x].NTrajet));

            clientList.Remove(c);

            for (int i = nClient; i < clientList.Count; i++)
                clientList[i].NClient = i;
        }

        /**
         * Supprimer un trajet à la liste du gestionnaire de flotte
         * @Params nTrajet int : numéro du trajet à supprimer
         */
        public void SupTrajet(int nTrajet)
        {
            trajetList[nTrajet].Supprimer();

            trajetList.RemoveAt(nTrajet);

            for (int i = nTrajet; i < trajetList.Count; i++)
                trajetList[i].NTrajet = i;
        }

    }
}