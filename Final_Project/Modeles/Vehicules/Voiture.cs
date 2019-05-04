using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project
{
    public sealed class Voiture : Vehicule
    {
        private readonly int nbPortes;
        private readonly int puissance;

        /**
        * Constructeur pour vehicule d'occasion
        */

        public Voiture(string marque, string modele, int km, string couleur, int nbPortes, int puissance) : base(marque, modele, km, couleur)
        {
            this.nbPortes = nbPortes;
            this.puissance = puissance;
        }

        /* Properties */
        
        public int NbPortes => nbPortes;

        public int Puissance => puissance;
    }
}