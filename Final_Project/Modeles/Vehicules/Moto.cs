using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project.Vehicules
{
    public sealed class Moto : Vehicule
    {
        private readonly int cylindre;


        /**
         * Constructeur pour vehicule d'occasion
         */
     
        public Moto(string marque, string modele, int km, string couleur, int cylindre) : base(marque, modele, km, couleur)
        {
            this.cylindre = cylindre;
        }


        /* Properties */

        public int Cylindre => cylindre;

        protected override void CalculerCout()
        {
            Cout = cylindre * 0.95;
        }
        public override string ToString()
        {
            return base.ToString() + $"CYLINDRE : {cylindre}";
        }
    }
}