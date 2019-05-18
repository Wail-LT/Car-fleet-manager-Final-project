using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Final_Project.Enums;
using Final_Project.Vehicules;

namespace Final_Project
{
    public class Trajet
    {
        private readonly int nTrajet;
        private readonly Client client;
        private readonly Vehicule vehicule;
        private int distance;
        private double cout;

        private static int nbTrajet = 0;

        public Trajet(Client client, Vehicule vehicule, int distance)
        {
            this.nTrajet = ++nbTrajet;
            this.client = client;
            this.vehicule = vehicule;
            this.distance = distance;
            CalculerCout();
            this.client.TotalLoc += cout;
            this.vehicule.IsDisponible = false;
            this.vehicule.NTrajet = nTrajet;
            this.vehicule.LibPlace();
        }


        /* Properties */

        public int NTrajet => nTrajet;

        public Client Client => client;
        public double Cout => cout;
        public Vehicule Vehicule => vehicule;

        public static int NbTrajet { get => nbTrajet; set => nbTrajet = value; }
        public int Distance
        {
            get => distance;
            set
            {
                distance = value;
                CalculerCout();
            }
        }


        /* Public Methodes */

        public void Supprimer()
        {
            Vehicule.Km -= distance;
            client.TotalLoc -= cout;
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
