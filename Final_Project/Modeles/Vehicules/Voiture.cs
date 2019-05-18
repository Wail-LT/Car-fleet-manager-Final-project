using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Enums;

namespace Final_Project.Vehicules
{
    public sealed class Voiture : Vehicule
    {
        private readonly int nbPortes;
        private readonly int puissance;
        private readonly TypeVoiture type;

        /**
        * Constructeur pour vehicule d'occasion
        */

        public Voiture(string marque, string modele, int km, string couleur, int nbPortes, int puissance, TypeVoiture type) : base(marque, modele, km, couleur)
        {
            this.nbPortes = nbPortes;
            this.puissance = puissance;
            this.type = type;
        }

        /* Properties */
        
        public int NbPortes => nbPortes;

        public int Puissance => puissance;

        public TypeVoiture Type => type;

        protected override void CalculerCout()
        {
            if (type == TypeVoiture.Break)
                Cout = Puissance;
            else if (type == TypeVoiture.Berline)
                Cout = 1.5 * Puissance;
            else if (type == TypeVoiture.Monospace)
                Cout = 1.25 * Puissance;
        }
    }
}