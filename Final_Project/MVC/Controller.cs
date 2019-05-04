using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project
{
    public class Controller
    {
        private GestionFlotte gestionFlotte;

        public Controller(GestionFlotte gestionFlotte)
        {
            this.gestionFlotte = gestionFlotte;
        }

        /* Public Methodes */

        /***** Ajout *****/

        /**
         * Ajout un client à la liste du gestionnaire de flotte
         * @Params à définir
         */
        public void AjoutClient()
        {

        }

        /**
         * Ajout une Voiture à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params nbPortes  int      : nombre de portes
         * @Params puissance int      : puissance moteur (nombre de chevaux)
         */
        public void AjoutVoiture(string couleur, int km, string marque, string modele, int nbPortes, int puissance)
        {
            CheckVehicule(couleur, km, marque, modele);

            if (nbPortes < 3 || nbPortes > 5)
                throw new NotImplementedException("ERREUR : le nombre de porte saisie est incorrect il doit être compris entre 3 et 5");
            if (puissance<70 && puissance>650)
                throw new NotImplementedException("ERREUR : la puissance saisie est incorrect elle doit être comprise entre 70 et 650ch");
            gestionFlotte.AjoutVehicule();
        }

        /**
         * Ajout un camion à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params à définir
         */
        public void AjoutCamion(string couleur, int km, string marque, string modele /*, a definir*/)
        {
            CheckVehicule(couleur, km, marque, modele);
        }

        /**
         * Ajout une moto à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params à définir
         */
        public void AjoutMoto(string couleur, int km, string marque, string modele /*, a definir*/)
        {
            CheckVehicule(couleur, km, marque, modele);
        }


        /**
         * Ajout un trajet à la liste du gestionnaire de flotte
         * @Params à définir
         */
        public void AjoutTrajet()
        {

        }

        /***** Fin Ajout *****/



        /***** Suppression *****/

        /**
         * Supprimer un client à la liste du gestionnaire de flotte
         * @Params reference int : référence du client
         */
        public void SupClient(int reference)
        {

        }

        /**
         * Supprimer un véhicule à la liste du gestionnaire de flotte
         * @Params reference int : référence du véhicule
         */
        public void SupVehicule(int reference)
        {

        }

        /**
         * Supprimer un trajet à la liste du gestionnaire de flotte
         * @Params reference int : référence du trajet
         */
        public void SupTrajet(int reference)
        {

        }

        /***** Fin Suppression *****/





        /* Private Methodes */


        /**
         * Verifie les attribues commun au types de véhicules
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         */
        private void CheckVehicule(string couleur, int km, string marque, string modele)
        {
       
        }

    }
}