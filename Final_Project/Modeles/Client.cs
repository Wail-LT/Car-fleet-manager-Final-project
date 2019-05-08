using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_Project.Enums;

namespace Final_Project
{
    public class Client
    {
        private int nClient;
        private readonly string nom;
        private readonly string prenom;
        private readonly string adresse;
        private readonly List<EPermis> permisList;
        private double totalLoc;

        public Client(string nom, string prenom, string adresse, List<EPermis> permisList)
        {
            this.nClient = -1;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.permisList = new List<EPermis>(permisList);
            totalLoc = 0;
        }


        /* Properties */

        public string Nom => nom;
        public string Prenom => prenom;
        public string Adresse => adresse;

        public int NClient { get => nClient; set => nClient = value; }

        public List<EPermis> PermisList => permisList;

        public double TotalLoc { get => totalLoc; set => totalLoc = value; }

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
         * Supprimer un Permis au client
         * @Params permis   EPermis : permis à supprimer
         */
        public void SupPermis(EPermis permis)
        {
            permisList.Remove(permis);
        }
    }
}