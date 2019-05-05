using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Enums;

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
         * @Params nom             string       : Nom du client
         * @Params prénom          string       : Prénom du client
         * @Params adresse         string       : adresse du client
         * @Params srtPermisList   List<string> : list des permis du client
         */
        public void AjoutClient(string nom, string prenom, string adresse, List<string> srtPermisList)
        {
            if(string.IsNullOrWhiteSpace(nom))
                throw new NotImplementedException("ERREUR : le champ nom est obligatoire");
            if (string.IsNullOrWhiteSpace(prenom))
                throw new NotImplementedException("ERREUR : le champ prénom est obligatoire");
            if (string.IsNullOrWhiteSpace(adresse))
                throw new NotImplementedException("ERREUR : le champ adresse est obligatoire");

            List<EPermis> permisList = new List<EPermis>();

            srtPermisList.ForEach(x => StrToEPermis(x,permisList));

            gestionFlotte.AjoutClient(new Client(nom, prenom, adresse, permisList));

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
        public void AjoutVoiture(string couleur, string km, string marque, string modele, string nbPortes, string puissance)
        {
            int iKm = -1;
            int iNbPortes = -1;
            int iPuissances = -1;

            CheckVehicule(couleur, km, marque, modele, out iKm);
      
            if (!int.TryParse(nbPortes, out iNbPortes) || iNbPortes < 3 || iNbPortes > 5)
                throw new NotImplementedException("ERREUR : le nombre de porte saisie est incorrect il doit être compris entre 3 et 5");
            if (!int.TryParse(puissance, out iPuissances) || iPuissances < 70 || iPuissances > 650) 
                throw new NotImplementedException("ERREUR : la puissance saisie est incorrect elle doit être comprise entre 70 et 650ch");

            gestionFlotte.AjoutVehicule(new Voiture(marque, modele, iKm, couleur, iNbPortes, iPuissances));
        }

        /**
         * Verifie la validité des donnée et ajout un camion à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params capacite  int      : capacité en m3 du camion
         */
        public void AjoutCamion(string couleur, string km, string marque, string modele , int capacite)
        {
            int iKm = -1;

            CheckVehicule(couleur, km, marque, modele, out iKm);

            if (capacite < 2.75 || capacite > 22) 
                throw new NotImplementedException("ERREUR : la capacité saisie est incorrect elle doit être comprise entre 2.75 et 22 m3");

            gestionFlotte.AjoutVehicule(new Camion(marque, modele, iKm, couleur, capacite));
        }

        /**
         * Verifie la validité des donnée et ajout une moto à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params cylindre  int      : cylindré du véhicule en cm3
         */
        public void AjoutMoto(string couleur, string km, string marque, string modele , int cylindre)
        {
            int iKm = -1;

            CheckVehicule(couleur, km, marque, modele, out iKm);

            if (cylindre < 50 || cylindre > 1500)
                throw new NotImplementedException("ERREUR : la cylindré saisie est incorrect elle doit être comprise entre 50 et 1500 cm3");

            gestionFlotte.AjoutVehicule(new Moto(marque, modele, iKm, couleur, cylindre));
        }


        /**
         * Ajouter un trajet à la liste du gestionnaire de flotte
         * @Params strNClient    string : Numero du client
         * @Params strNVehicule  string : Numero du vehicule
         * @Params strDistance   string : distance en km
         */
        public void AjoutTrajet(string strNClient, string strNVehicule, string strDistance)
        {
            int nClient = -1;
            int nVehicule = -1;
            int distance = -1;

            if (!int.TryParse(strNClient, out nClient))
                throw new NotImplementedException("ERREUR : le numéro saisie est incorrect ou ne correspond à aucun client");
            if (!int.TryParse(strNVehicule, out nVehicule))
                throw new NotImplementedException("ERREUR : le numéro saisie est incorrect ne correspond à aucun vehicule");
            if (!int.TryParse(strDistance, out distance))
                throw new NotImplementedException("ERREUR : le distance saisie est incorrect");

            gestionFlotte.AjoutTrajet(new Trajet(gestionFlotte.NumTrajetMax, gestionFlotte.GetClient(nClient), gestionFlotte.GetVehicule(nVehicule), distance));
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
        private void CheckVehicule(string couleur, string km, string marque, string modele, out int iKm)
        {
          
            if (string.IsNullOrWhiteSpace(couleur))
                throw new NotImplementedException("ERREUR : le champ couleur est obligatoire");
            if (!int.TryParse(km, out iKm) || iKm < 0)
                throw new NotImplementedException("ERREUR : le champ km est incorrect il doit être suppèrieur à 0");
            if (string.IsNullOrWhiteSpace(marque))
                throw new NotImplementedException("ERREUR : le champ marque est obligatoire");
            if (string.IsNullOrWhiteSpace(modele))
                throw new NotImplementedException("ERREUR : le champ modele est obligatoire");
        }

        /**
         * Convertie un string en strPermis et l'ajout à une list de strPermis
         * @Params  strPermis       : string         string à convertir
         * @Params  listPermis   : List<EPermis>  list de strPermis à remplir
         */
        private void StrToEPermis(string strPermis, List<EPermis> permisList)
        {
            EPermis permis;
            if (!Enum.TryParse(strPermis, true, out permis))
                throw new NotImplementedException("ERREUR : Ce type de strPermis ne fait pas partie de la liste");

            permisList.Add(permis);    
        }

    }
}