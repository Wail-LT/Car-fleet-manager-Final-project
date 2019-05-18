using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Enums;

namespace Final_Project
{
    public class Client
    {
        private readonly int nClient;
        private string nom;
        private string prenom;
        private string adresse;
        private readonly List<EPermis> permisList;
        private double totalLoc;

        private static int nbClient = 0;

        public Client(string nom, string prenom, string adresse, List<EPermis> permisList) 
        {
            this.nClient = ++nbClient;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.permisList = new List<EPermis>(permisList);
            totalLoc = 0;
        }


        /* Properties */

        public int NClient => nClient;

        public List<EPermis> PermisList => permisList;

        public double TotalLoc { get => totalLoc; set => totalLoc = value; }
        public static int NbClient { get => nbClient; set => nbClient = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }



        /* Public Methodes */


        /**
         * Ajouter  un Permis au client
         * @Params permis   EPermis : permis à ajouter
         */
        public void AjoutPermis(EPermis permis)
        {
            permisList.Add(permis);
        }

        /**
         * LibPlace un Permis au client
         * @Params permis   EPermis : permis à supprimer
         */
        public void SupPermis(EPermis permis)
        {
            permisList.Remove(permis);
        }
    }
}