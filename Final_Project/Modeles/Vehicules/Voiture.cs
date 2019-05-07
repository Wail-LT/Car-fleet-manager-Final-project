﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Enums;

namespace Final_Project
{
    public sealed class Voiture : Vehicule
    {
        private readonly int nbPortes;
        private readonly int puissance;
        private readonly TypeVoiture type;

        /**
        * Constructeur pour vehicule d'occasion
        */

        public Voiture(int nVehicule, string marque, string modele, int km, string couleur, int nbPortes, int puissance, TypeVoiture type) : base(nVehicule, marque, modele, km, couleur)
        {
            this.nbPortes = nbPortes;
            this.puissance = puissance;
            this.type = type;
        }

        /* Properties */
        
        public int NbPortes => nbPortes;

        public int Puissance => puissance;

        public TypeVoiture Type => type;
    }
}