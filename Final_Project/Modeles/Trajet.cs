using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Final_Project.Enums;
using Final_Project.Vehicules;

namespace Final_Project
{
    public class Trajet : ISauvegardable
    {
        private readonly int nTrajet;
        private readonly Client client;
        private readonly Vehicule vehicule;
        private int distance;
        private DateTime date;
        private double cout;

        private static int _lastNTrajet = 0;

        public Trajet(Client client, Vehicule vehicule, int distance, DateTime date)
        {
            this.nTrajet = ++_lastNTrajet;
            this.client = client;
            this.vehicule = vehicule;
            this.distance = distance;
            CalculerCout();
            this.client.TotalLoc += cout;
            this.vehicule.IsDisponible = false;
            this.vehicule.NTrajet = nTrajet;
            this.vehicule.LibPlace();
            this.date = date;
        }

        public Trajet(int nTrajet, Client client, Vehicule vehicule, DateTime date, int distance) : this(client,vehicule,distance,date)
        {
            this.nTrajet = nTrajet;
        }


        /* Properties */

        public int NTrajet => nTrajet;

        public Client Client => client;
        public double Cout => cout;
        public Vehicule Vehicule => vehicule;

        public static int LastNTrajet { get => _lastNTrajet; set => _lastNTrajet = value; }
        public int Distance
        {
            get => distance;
            set
            {
                distance = value;
                CalculerCout();
            }
        }

        public DateTime Date { get => date; set => date = value; }


        /* Public Methodes */

        public void Supprimer()
        {
            Vehicule.Km -= distance;
            client.TotalLoc -= cout;
        }



        /* Private Methodes */


        /**
         * VCalcule le coût total du trajet en fonction du vehicule et de la distance
         */
        private void CalculerCout()
        {
            if (vehicule is Voiture)
                cout = 0.25 * distance;
            else
                cout = 0.5 * distance;

            cout += vehicule.Cout;
        }

        public void Sauvegarder(StreamWriter fWriter, string before = "", string after = "")
        {
            fWriter.WriteLine(before + "{");
            fWriter.WriteLine($"{before}\t\"nTrajet\" : \"{nTrajet}\",");
            fWriter.WriteLine($"{before}\t\"NClient\" : \"{client.NClient}\",");
            fWriter.WriteLine($"{before}\t\"NVehicule\" : \"{vehicule.NVehicule}\",");
            fWriter.WriteLine($"{before}\t\"date\" : \"{date.ToString("dd/MM/yyyy")}\",");
            fWriter.WriteLine($"{before}\t\"distance\" : \"{distance}\",");
            fWriter.WriteLine($"{before}\t\"cout\" : \"{cout}\"");
            fWriter.WriteLine(before + "}"+after);
        }
    }
} 
