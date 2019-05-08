using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Parking;

namespace Final_Project.Vehicules
{
    public abstract class Vehicule
    {

        private int nVehicule;
        private readonly string marque;
        private readonly string modele;
        private int km;
        private string couleur;
        private bool isDisponible;
        private double cout;
        private Place place;

        /**
         * Constructeur pour vehicule d'occasion
         */

        protected Vehicule(int nVehicule, string marque, string modele, int km, string couleur)
        {
            this.nVehicule = nVehicule;
            this.marque = marque;
            this.modele = modele;
            this.km = km;
            this.couleur = couleur;
            this.isDisponible = true;
            this.place = null;
            CalculerCout();
        }

        
        /* Properties */

        public string Marque => marque;
        public string Modele => modele;
 
        public int Km { get => km; set => km = value; }
        public string Couleur { get => couleur; set => couleur = value; }
        public bool IsDisponible { get => isDisponible; set => isDisponible = value; }
        public int NVehicule { get => nVehicule; set => nVehicule = value; }
        public double Cout { get => cout; set => cout = value; }

        public Place Place
        {
            get => place;
            set
            {
                place = value;
                place.Vehicule = this;
            }
        }

        /* Public Methodes */

        public void Supprimer()
        {
            nVehicule = -1;
            place.Vehicule = null;
            place = null;
        }

        /* Protected Methodes */

        protected abstract void CalculerCout();
    }
}