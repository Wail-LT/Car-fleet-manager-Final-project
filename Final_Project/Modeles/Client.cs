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
        private string nom;
        private string prenom;
        private string adresse;
        private List<EPermis> permis;

        public Client(int nClient, string nom, string prenom, string adresse, List<EPermis> permis)
        {
            this.nClient = nClient;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.permis = new List<EPermis>(permis);
        }
    }
}