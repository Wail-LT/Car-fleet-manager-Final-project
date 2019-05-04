using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project
{
    public class GestionFlotte
    {
        private List<Vehicule> vehiculeList;
        private List<Client> clientList;
        private List<Trajet> trajetList;



        public GestionFlotte()
        {
            vehiculeList = new List<Vehicule>();
            clientList = new List<Client>();
            trajetList = new List<Trajet>();
        }


        /* Properties */

        public int NumVehiculeMax => vehiculeList.Count - 1;
        public int NumClientMax => clientList.Count - 1;
        public int NumTrajetMax => trajetList.Count - 1;


        /* Public Methodes */

        /**
         * Ajouter un vehicule à la liste de véhicule du gestionnaire de flotte
         * @Params vehicule   Vehicule : le vehicule à ajouter
         */
        public void AjoutVehicule(Vehicule vehicule)
        {
            vehicule.NVehicule = NumVehiculeMax + 1;
            vehiculeList.Add(vehicule);
        }

        /**
         * Supprime un vehicule de la liste de véhicule du gestionnaire de flotte
         * @Params nVehicule   int : numero du vehicule à supprimer
         */
        public void SupVehicule(int nVehicule)
        {
            vehiculeList.RemoveAt(nVehicule);

            for (int i = nVehicule; i < vehiculeList.Count; i++)
                vehiculeList[i].NVehicule = i;

        }

        /**
         * Supprimer un client à la liste du gestionnaire de flotte
         * @Params nClient int : numéro du client à supprimer
         */
        public void SupTrajet(int nTrajet)
        {
            throw new NotImplementedException();
        }

        /**
         * Supprimer un trajet à la liste du gestionnaire de flotte
         * @Params nTrajet int : numéro du trajet à supprimer
         */
        public void SupClient(int nClient)
        {
            clientList.RemoveAt(nClient);

            for (int i = nClient; i < clientList.Count; i++)
                clientList[i].NClient = i;
        }
    }
}