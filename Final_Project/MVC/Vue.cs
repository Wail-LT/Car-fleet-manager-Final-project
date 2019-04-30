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

        }



        /****** Layout Visualisation ******/

        /**
         * Affiche le layout Visualisation
         */
        private void AfficherVisu()
        {

        }

        /**
        * Affiche une list de clients
        */
        private void AfficherClients()
        {

        }

        /**
        * Affiche un Clients
        */
        private void AfficherClient()
        {

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