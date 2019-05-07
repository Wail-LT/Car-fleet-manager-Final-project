using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Final_Project.Enums;

namespace Final_Project
{
    public class Trajet
    {
        private int nTrajet;
        private readonly Client client;
        private readonly Vehicule vehicule;
        private readonly int distance;
        private double cout;


        public Trajet(int nTrajet, Client client, Vehicule vehicule, int distance)
        {
            this.nTrajet = nTrajet;
            this.client = client;
            this.vehicule = vehicule;
            this.distance = distance;
            this.vehicule.Km += distance;
            CalculerCout();
        }


        /* Properties */

 

        public int NTrajet { get => nTrajet; set => nTrajet = value; }

        public int Distance => distance;
        public Client Client => client;
        public double Cout => cout;
        public Vehicule Vehicule => vehicule;


        /* Public Methodes */

        public void Supprimer()
        {
            Vehicule.Km -= distance;
        }



        /* Private Methodes */

        /**
         * VCalcule le coût total du trajet en fonction du vehicule et de la distance
         */
        private void CalculerCout()
        {
            if (vehicule is Voiture)
                cout = 0.25 * distance;
            else
                cout = 0.5 * distance;

            cout += vehicule.Cout;
        }
    }
} 
