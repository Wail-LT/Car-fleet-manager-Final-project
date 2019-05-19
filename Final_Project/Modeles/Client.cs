using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Final_Project.Enums;

namespace Final_Project
{
    public class Client : ISauvegardable
    {
        private readonly int nClient;
        private int nbAnneePermis;
        private string nom;
        private string prenom;
        private string adresse;
        private readonly List<EPermis> permisList;
        private double totalLoc;

        private static int lastNClient = 0;

        public Client(string nom, string prenom, string adresse, int nbAnneePermis, List<EPermis> permisList) 
        {
            this.nClient = ++lastNClient;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.nbAnneePermis = nbAnneePermis;
            this.permisList = new List<EPermis>(permisList);
            totalLoc = 0;
        }

        public Client(int nClient, string nom, string prenom, string adresse, int nbAnneePermis, int totalLoc,
            List<EPermis> permisList) : this(nom, prenom, adresse, nbAnneePermis, permisList)
        {
            this.nClient = nClient;
            this.totalLoc = totalLoc;
        }


        /* Properties */

        public int NClient => nClient;

        public List<EPermis> PermisList => permisList;

        public double TotalLoc { get => totalLoc; set => totalLoc = value; }
        public static int LastNClient { get => lastNClient; set => lastNClient = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public int NbAnneePermis { get => nbAnneePermis; set => nbAnneePermis = value; }



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

        public void Sauvegarder(StreamWriter fWriter, string before = "", string after = "")
        {
            fWriter.WriteLine(before + "{");
            fWriter.WriteLine($"{before}\t\"nClient\" : \"{nClient}\",");
            fWriter.WriteLine($"{before}\t\"nom\" : \"{nom}\",");
            fWriter.WriteLine($"{before}\t\"prenom\" : \"{prenom}\",");
            fWriter.WriteLine($"{before}\t\"adresse\" : \"{adresse}\",");
            fWriter.WriteLine($"{before}\t\"nbAnneePermis\" : \"{nbAnneePermis}\",");
            fWriter.WriteLine($"{before}\t\"totalLoc\" : \"{totalLoc}\",");
            fWriter.WriteLine($"{before}\t\"permisList\" : [");
            permisList.ForEach(permis =>
            {
                if(permisList.IndexOf(permis) == permisList.Count-1)
                    fWriter.WriteLine(before + "\t\t{ \"permis\" : \"" + permis + "\" }");
                else
                    fWriter.WriteLine(before + "\t\t{ \"permis\" : \"" + permis + "\" },");
            });
            fWriter.WriteLine(before + "\t]");
            fWriter.WriteLine(before + "}" + after);
        }
    }
}