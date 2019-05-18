using System;
using Final_Project.Enums;
using Final_Project.Vehicules;

namespace Final_Project.Controleurs
{
    public class Controleur : IControleur
    {
        private Random random;
        private GestionFlotte gestionFlotte;

        public Controleur(GestionFlotte gestionFlotte)
        {
            this.gestionFlotte = gestionFlotte;
            random = new Random();
        }

        public void Verifier(Vehicule v)
        {
            int temps = random.Next(1, 4);
            for (int i = 0; i < temps; i++)
            {
            }

            Trajet trajetAssocie = gestionFlotte.TrajetList.Find(trajet => trajet.NTrajet == v.NTrajet);

            Intervention intervention;
            Intervention.TryParse(random.Next(1, 4).ToString(), out intervention);

            v.AddIntervention(intervention);
            v.IsDisponible = true;
            v.Km += trajetAssocie.Distance;
            v.NTrajet = -1;
            v.Place = gestionFlotte.GetPlaceDisp();
        }
    }
}