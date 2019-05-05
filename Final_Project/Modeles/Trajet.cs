using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Final_Project
{
    public class Trajet
    {
        private int nTrajet;
        private Client client;
        private Vehicule vehicule;
        private int distance;


        public Trajet(int nTrajet, Client client, Vehicule vehicule, int distance)
        {
            this.nTrajet = nTrajet;
            this.client = client;
            this.vehicule = vehicule;
            this.distance = distance;
            this.vehicule.Km += distance;
        }


        /* Properties */

        public int Distance { get => distance; set => distance = value; }
        public int NTrajet { get => nTrajet; set => nTrajet = value; }


        /* Public Methodes */

        public void Supprimer()
        {
            vehicule.Km -= distance;
        }
    }
} 
