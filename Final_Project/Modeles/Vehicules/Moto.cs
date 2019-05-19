using Final_Project.Enums;
using Final_Project.Parking;
using System;
using System.Collections.Generic;
using System.IO;
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
            CalculerCout();
        }

        public Moto(int nVehicule, string marque, string modele, int km, string couleur, bool isDisponible,
            Place place, List<Intervention> interventionList, int nTrajet, int cylindre) : base(
            nVehicule, marque, modele, km, couleur, isDisponible, place, interventionList, nTrajet)
        {
            this.cylindre = cylindre;
            CalculerCout();
        }


        /* Properties */

        public int Cylindre => cylindre;

        /* Methodes*/

        protected override void CalculerCout()
        {
            Cout = cylindre * 0.20;
        }

        public override string ToString()
        {
            return base.ToString() + $" CYLINDRE : {cylindre}";
        }

        public override void Sauvegarder(StreamWriter fWriter, string before = "", string after = "")
        {
            base.Sauvegarder(fWriter, before);
            fWriter.WriteLine($"{before}\t\"vehicule\" : \"moto\",");
            fWriter.WriteLine($"{before}\t\"cylindre\" : \"{cylindre}\"");
            fWriter.WriteLine(before + "}"+after);
        }
    }
}