using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Enums;
using Final_Project.Exceptions;
using Final_Project.Exceptions.Parking;
using Final_Project.Exceptions.Trajet;
using Final_Project.Exceptions.Voiture;
using Final_Project.Exceptions.Voiture.Camion;
using Final_Project.Exceptions.Voiture.Moto;
using Final_Project.Vehicules;

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
                throw new NomVide();
            if (string.IsNullOrWhiteSpace(prenom))
                throw new PrenomVide();
            if (string.IsNullOrWhiteSpace(adresse))
                throw new AdresseVide();

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
        public void AjoutVoiture(string couleur, string km, string marque, string modele, string nbPortes, string puissance, string type)
        {
            int iKm = -1;
            int iNbPortes = -1;
            int iPuissances = -1;
            TypeVoiture typeV;
            CheckVehicule(couleur, km, marque, modele, out iKm);


            if (!TypeVoiture.TryParse(type, true, out typeV)) 
                throw new ErreurType();
            if (!int.TryParse(nbPortes, out iNbPortes) || iNbPortes < 3 || iNbPortes > 5)
                throw new ErreurNBPortes();
            if (!int.TryParse(puissance, out iPuissances) || iPuissances < 70 || iPuissances > 650) 
                throw new ErreurPuissance();

            gestionFlotte.AjoutVehicule(new Voiture(gestionFlotte.LastNumVehicule + 1, marque, modele, iKm, couleur, iNbPortes, iPuissances, typeV));
        }

        /**
         * Verifie la validité des donnée et ajout un camion à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params capacite  int      : capacité en m3 du camion
         */
        public void AjoutCamion(string couleur, string km, string marque, string modele , string capacite)
        {
            int iKm = -1;
            int iCapacite = -1;

            CheckVehicule(couleur, km, marque, modele, out iKm);

            if (!int.TryParse(capacite, out iCapacite) || iCapacite < 2.75 || iCapacite > 22) 
                throw new ErreurCapacite();

            gestionFlotte.AjoutVehicule(new Camion(gestionFlotte.LastNumVehicule + 1, marque, modele, iKm, couleur, iCapacite));
        }

        /**
         * Verifie la validité des donnée et ajout une moto à la liste de véhicule du gestionnaire de flotte
         * @Params couleur   string   : couleur du véhicule
         * @Params km        int      : km au compteur
         * @Params marque    string   : marque du véhicule
         * @Params modele    string   : modele du véhicule
         * @Params cylindre  int      : cylindré du véhicule en cm3
         */
        public void AjoutMoto(string couleur, string km, string marque, string modele , string cylindre)
        {
            int iKm = -1;
            int iCylindre = -1;

            CheckVehicule(couleur, km, marque, modele, out iKm);

            if (!int.TryParse(cylindre, out iCylindre) || iCylindre < 50 || iCylindre > 1500)
                throw new ErreurCylindre();

            gestionFlotte.AjoutVehicule(new Moto(gestionFlotte.LastNumVehicule + 1, marque, modele, iKm, couleur, iCylindre));
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

            nClient = CheckNClient(strNClient);
            nVehicule = CheckNVehicule(strNVehicule);
 
            if (!int.TryParse(strDistance, out distance))
                throw new ErreurDistance();

            gestionFlotte.AjoutTrajet(new Trajet(gestionFlotte.LastNumTrajet + 1, gestionFlotte.GetClient(nClient), gestionFlotte.GetVehicule(nVehicule), distance));
        }

        /***** Fin Ajout *****/



        /***** Suppression *****/

        /**
         * Supprimer un client à la liste du gestionnaire de flotte
         * @Params nClient int : numéro du client à supprimer
         */
        public void SupClient(string strnClient)
        {
            gestionFlotte.SupClient(CheckNClient(strnClient));
        }

        /**
         * Supprimer un véhicule à la liste du gestionnaire de flotte
         * @Params nVehicule int : numéro du véhicule à supprimer
         */
        public void SupVehicule(string strnVehicule)
        {
            gestionFlotte.SupVehicule(CheckNVehicule(strnVehicule));
        }

        /**
         * Supprimer un trajet à la liste du gestionnaire de flotte
         * @Params nTrajet int : numéro du trajet à supprimer
         */
        public void SupTrajet(string strnTrajet)
        {   
            gestionFlotte.SupTrajet(CheckNTrajet(strnTrajet));
        }

        /***** Fin Suppression *****/

        /***** Affichage *****/

        /**
        * Afficher un client de la liste du gestionnaire de flotte
        * @Params nClient int : numéro du client à supprimer
        * @Returns : Client
        */ 
        public Client GetClient(string strnClient)
        {
            return gestionFlotte.GetClient(CheckNClient(strnClient));
        }

        /**
         * Afficher un véhicule de la liste du gestionnaire de flotte
         * @Params nVehicule int : numéro du véhicule à supprimer
         * @Returns : Vehicule
         */
        public Vehicule GetVehicule(string strnVehicule)
        {
            return gestionFlotte.GetVehicule(CheckNVehicule(strnVehicule));
        }

        /**
         * Afficher un trajet de la liste du gestionnaire de flotte
         * @Params nTrajet int : numéro du trajet à supprimer
         * @Returns : Trajet
         */
        public Trajet GetTrajet(string strnTrajet)
        {
            return gestionFlotte.GetTrajet(CheckNTrajet(strnTrajet));
        }

        /***** Fin Affichage *****/



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
                throw new ErreurCouleur();
            if (!int.TryParse(km, out iKm) || iKm < 0)
                throw new ErreurKm();
            if (string.IsNullOrWhiteSpace(marque))
                throw new ErreurMarque();
            if (string.IsNullOrWhiteSpace(modele))
                throw new ErreurModele();
        }

        /**
         * Convertie un string en strPermis et l'ajout à une list de strPermis
         * @Params  strPermi    string : string à convertir
         * @Params  listPermis      : List<EPermis>  list de strPermis à remplir
         */
        private void StrToEPermis(string strPermis, List<EPermis> permisList)
        {
            EPermis permis;
            if (!EPermis.TryParse(strPermis, true, out permis))
                throw new ErreurPermis();

            permisList.Add(permis);    
        }

        /**
         * Convertie un string en int et vérifie que le numéro du véhicule est correct
         * @Params  strNVehicule    string : string à convertir
         * * @Returns   int : numero du véhicule
         */
        private int CheckNVehicule(string strNVehicule)
        {
            int nVehicule = -1;
            if (!int.TryParse(strNVehicule, out nVehicule) || nVehicule > gestionFlotte.LastNumVehicule ||
                nVehicule < 0) 
                throw new ErreurNVehicule();
            return nVehicule;
        }

        /**
         * Convertie un string en int et vérifie que le numéro du trajet est correct
         * @Params  strNTrajet    string : string à convertir
         * * @Returns   int : numero du trajet
         */
        private int CheckNTrajet(string strNTrajet)
        {
            int nTrajet = -1;
            if (!int.TryParse(strNTrajet, out nTrajet) || nTrajet > gestionFlotte.LastNumTrajet || nTrajet < 0)
                throw new ErreurNTrajet();
            return nTrajet;
        }

        /**
         * Convertie un string en int et vérifie que le numéro du client est correct
         * @Params  strNClient    string : string à convertir
         * * @Returns   int : numero du client
         */
        private int CheckNClient(string strNClient)
        {
            int nClient = -1;
            if (!int.TryParse(strNClient, out nClient) || nClient > gestionFlotte.LastNumClient || nClient < 0)
                throw new ErreurNClient();
            return nClient;
        }

        public Parking.Parking SelectParking(string nParking, Func<List<Parking.Parking>> getListParking)
        {
            List<Parking.Parking> list = getListParking();

            Parking.Parking result = null;

            list.ForEach(parking =>
            {
                if (!parking.IsPlein && nParking.Equals(parking.Nom))
                    result = parking;
            });

            if (result==null)
                throw new ErreurNomParking();
            return result;
        }
    }
}