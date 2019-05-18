using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project.Vehicules
{
    public sealed class Camion : Vehicule
    {
        private readonly int capacite;

        /**
        * Constructeur pour vehicule d'occasion
        */

        public Camion(string marque, string modele, int km, string couleur, int capacite) : base(marque, modele, km, couleur)
        {
            this.capacite = capacite;
        }

        /* Properties */

        public int Capacite => capacite;

        protected override void CalculerCout()
        {
            Cout = capacite * 37.5;
        }
    }
}