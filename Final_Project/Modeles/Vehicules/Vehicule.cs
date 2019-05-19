using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Final_Project.Enums;
using Final_Project.Parking;

namespace Final_Project.Vehicules
{
    public abstract class Vehicule : ISauvegardable
    {

        private readonly int nVehicule;
        private readonly string marque;
        private readonly string modele;
        private int km;
        private string couleur;
        private bool isDisponible;
        private double cout;
        private Place place;
        private List<Intervention> interventionList;
        private int nTrajet;

        private static int lastNVehicule = 0;


        /**
         * Constructeur pour vehicule d'occasion
         */

        protected Vehicule(string marque, string modele, int km, string couleur)
        {
            this.nVehicule = ++lastNVehicule;
            this.marque = marque;
            this.modele = modele;
            this.km = km;
            this.couleur = couleur;
            this.isDisponible = true;
            this.place = null;
            nTrajet = -1;
            interventionList = new List<Intervention>();
        }

        protected Vehicule(int nVehicule, string marque, string modele, int km, string couleur, bool isDisponible, Place place, List<Intervention> interventionList, int nTrajet):this(marque,modele,km,couleur)
        {
            this.nVehicule = nVehicule;
            this.isDisponible = isDisponible;
            this.nTrajet = nTrajet;
            this.place = place;
            this.interventionList = new List<Intervention>(interventionList);
        }


        /* Properties */

        public string Marque => marque;
        public string Modele => modele;
 
        public int Km { get => km; set => km = value; }
        public string Couleur { get => couleur; set => couleur = value; }
        public bool IsDisponible { get => isDisponible; set => isDisponible = value; }
        public int NVehicule => nVehicule;
        public double Cout { get => cout; set => cout = value; }

        public Place Place
        {
            get => place;
            set
            {
                place = value;
                place.Vehicule = this;
            }
        }

        public static int LastNVehicule { get => lastNVehicule; set => lastNVehicule = value; }
        public int NTrajet { get => nTrajet; set => nTrajet = value; }

        /* Public Methodes */

        public void LibPlace()
        {
            if (place != null)
            {
                place.Vehicule = null;
                place = null;
            }
        }

        public void AddIntervention(Intervention intervention)
        {
            interventionList.Add(intervention);
        }

        public void DelLastIntervention()
        {
            interventionList.RemoveAt(interventionList.Count-1);
        }
        public override string ToString()
        {
            string disp = isDisponible ? "Oui" : "Non";
            string trajet = NTrajet == -1 ? "Auncun" : nTrajet.ToString();
            string parking = this.place != null ? this.place.Parking.Nom : "Aucun";
            string place = this.place != null ? $"A{this.place.NPlace}" : "Auncune";
            string toString = $" NUM : {NVehicule} \n MARQUE : {marque} \n MODELE : {modele} \n KM : {km}\n COULEUR : {couleur}\n DISPONIBLE : {disp}\n TRAJET ASSOCIE : {trajet}\n COUT : {cout}\n PARKING : {parking}\n PLACE : {place}\n Intervention :\n";
            interventionList.ForEach(interv =>
            {
                toString += $" \t{interv}, \n";
            });
            return toString;
             
        }
        /* Protected Methodes */

        protected abstract void CalculerCout();

        public virtual void Sauvegarder(StreamWriter fWriter, string before = "", string after = "")
        {
            string parking = this.place != null ? this.place.Parking.Nom : "null";
            string place = this.place != null ? $"A{this.place.NPlace}" : "null";
            fWriter.WriteLine(before + "{");
            fWriter.WriteLine($"{before}\t\"nVehicule\" : \"{nVehicule}\",");
            fWriter.WriteLine($"{before}\t\"marque\" : \"{marque}\",");
            fWriter.WriteLine($"{before}\t\"modele\" : \"{modele}\",");
            fWriter.WriteLine($"{before}\t\"km\" : \"{km}\",");
            fWriter.WriteLine($"{before}\t\"couleur\" : \"{couleur}\",");
            fWriter.WriteLine($"{before}\t\"isDisponible\" : \"{isDisponible}\",");
            fWriter.WriteLine($"{before}\t\"cout\" : \"{cout}\",");
            fWriter.WriteLine($"{before}\t\"parking\" : \"{parking}\",");
            fWriter.WriteLine($"{before}\t\"place\" : \"{place}\",");
            fWriter.WriteLine($"{before}\t\"interventionList\" : [");
            interventionList.ForEach(interv =>
            {
                if (interventionList.IndexOf(interv) == interventionList.Count - 1)
                   fWriter.WriteLine(before + "\t\t{ \"intervention\" : \"" + interv + "\" }");
                else
                    fWriter.WriteLine(before + "\t\t{ \"intervention\" : \"" + interv + "\" },");
            });
            fWriter.WriteLine($"{before}\t],");
            fWriter.WriteLine($"{before}\t\"nTrajet\" : {nTrajet},");
        }
    }
}