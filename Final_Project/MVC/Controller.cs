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

        /***** Ajouter *****/

        /**
         * Ajouter un client à la liste du gestionnaire de flotte
         * @Params à définir
         */
        public void AjoutClient()
        {

        }

        /**
         * Verifie la validité des donnée et ajout une Voiture à la liste de véhicule du gestionnaire de flotte
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
            if (puissance<70 || puissance>650)
                throw new NotImplementedException("ERREUR : la puissance saisie est incorrect elle doit être comprise entre 70 et 650ch");

            gestionFlotte.AjoutVehicule(new Voiture(marque, modele, km, couleur, nbPortes, puissance));
        }

        /**
         * Verifie la validité des donnée et ajout un camion à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params capacite  int      : capacité en m3 du camion
         */
        public void AjoutCamion(string couleur, int km, string marque, string modele , int capacite)
        {
            CheckVehicule(couleur, km, marque, modele);

            if (capacite < 2.75 || capacite > 22) 
                throw new NotImplementedException("ERREUR : la capacité saisie est incorrect elle doit être comprise entre 2.75 et 22 m3");

            gestionFlotte.AjoutVehicule(new Camion(marque, modele, km, couleur, capacite));
        }

        /**
         * Verifie la validité des donnée et ajout une moto à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params cylindre  int      : cylindré du véhicule en cm3
         */
        public void AjoutMoto(string couleur, int km, string marque, string modele , int cylindre)
        {
            CheckVehicule(couleur, km, marque, modele);

            if (cylindre < 50 || cylindre > 1500)
                throw new NotImplementedException("ERREUR : la cylindré saisie est incorrect elle doit être comprise entre 50 et 1500 cm3");

            gestionFlotte.AjoutVehicule(new Moto(marque, modele, km, couleur, cylindre));
        }


        /**
         * Ajouter un trajet à la liste du gestionnaire de flotte
         * @Params à définir
         */
        public void AjoutTrajet()
        {

        }

        /***** Fin Ajout *****/



        /***** Suppression *****/

        /**
         * Supprimer un client à la liste du gestionnaire de flotte
         * @Params nClient int : numéro du client à supprimer
         */
        public void SupClient(int nClient)
        {
            if (nClient > gestionFlotte.NumClientMax)
                throw new NotImplementedException("ERREUR : le numéro saisie ne correspond à aucun client");

            gestionFlotte.SupClient(nClient);
        }

        /**
         * Supprimer un véhicule à la liste du gestionnaire de flotte
         * @Params nVehicule int : numéro du véhicule à supprimer
         */
        public void SupVehicule(int nVehicule)
        {
            if (nVehicule > gestionFlotte.NumVehiculeMax)
                throw new NotImplementedException("ERREUR : le numéro saisie ne correspond à aucun véhicule de la flotte");

            gestionFlotte.SupVehicule(nVehicule);
        }

        /**
         * Supprimer un trajet à la liste du gestionnaire de flotte
         * @Params nTrajet int : numéro du trajet à supprimer
         */
        public void SupTrajet(int nTrajet)
        {
            if (nTrajet > gestionFlotte.NumTrajetMax)
                throw new NotImplementedException("ERREUR : le numéro saisie ne correspond à aucun trajet");

            gestionFlotte.SupTrajet(nTrajet);
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
            if (string.IsNullOrWhiteSpace(couleur))
                throw new NotImplementedException("ERREUR : le champ couleur est obligatoire");
            if (km < 0)
                throw new NotImplementedException("ERREUR : le champ km ne peut pas être negatif");
            if (string.IsNullOrWhiteSpace(marque))
                throw new NotImplementedException("ERREUR : le champ marque est obligatoire");
            if (string.IsNullOrWhiteSpace(modele))
                throw new NotImplementedException("ERREUR : le champ modele est obligatoire");
        }

    }
}