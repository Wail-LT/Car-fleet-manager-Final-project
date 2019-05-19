using Final_Project.Enums;
using Final_Project.Parking;
using System;
using System.Collections.Generic;
using System.IO;
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
            CalculerCout();
        }

        public Camion(int nVehicule, string marque, string modele, int km, string couleur, bool isDisponible,
            Place place, List<Intervention> interventionList, int nTrajet, int capacite) : base(
            nVehicule, marque, modele, km, couleur, isDisponible, place, interventionList, nTrajet)
        {
            this.capacite = capacite;
            CalculerCout();
        }

        /* Properties */

        public int Capacite => capacite;

        protected override void CalculerCout()
        {
            Cout = capacite * 37.5;
        }
        public override string ToString()
        {
            return base.ToString() + $" CAPACITE : {capacite}";
        }

        public override void Sauvegarder(StreamWriter fWriter, string before = "", string after = "")
        {
            base.Sauvegarder(fWriter, before);
            fWriter.WriteLine($"{before}\t\"vehicule\" : \"camion\",");
            fWriter.WriteLine($"{before}\t\"capacite\" : \"{capacite}\"");
            fWriter.WriteLine(before + "}"+after);
        }
    }
}