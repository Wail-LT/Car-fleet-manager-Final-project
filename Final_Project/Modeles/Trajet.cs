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
        private Vehicule vehicule;
        private int distance;
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

        public int Distance
        {
            get => distance;
            set
            {
                distance = value;
                CalculerCout();
            }
        }

        public int NTrajet { get => nTrajet; set => nTrajet = value; }

        public Client Client => client;

        public Vehicule Vehicule
        {
            get => vehicule;
            set
            {
                vehicule = value;
                CalculerCout();
            }
        }

        public double Cout { get => cout;}


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
            {
                cout = 0.25 * distance;
                if (((Voiture) vehicule).Type == TypeVoiture.Break) 
                    cout += ((Voiture)vehicule).Puissance;
                else if (((Voiture) vehicule).Type == TypeVoiture.Berline) 
                    cout += 1.5 * ((Voiture)vehicule).Puissance;
                else if (((Voiture) vehicule).Type == TypeVoiture.Monospace) 
                    cout += 1.25 * ((Voiture)vehicule).Puissance;
            }else if (vehicule is Moto)
            {
                cout = 0.5 * distance;
                cout += ((Moto) vehicule).Cylindre * 0.95;
            }else if (vehicule is Camion)
            {
                cout = 0.5 * distance;
                cout += ((Camion)vehicule).Capacite * 37.5;
            }
        }
    }
} 
