using System;
using Final_Project.Enums;
using Final_Project.Vehicules;

namespace Final_Project.Controleurs
{
    public class Controleur : IController
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

            Intervention intervention;
            Intervention.TryParse(random.Next(1, 4).ToString(), out intervention);
            v.AddIntervention(intervention);
            v.IsDisponible = true;
            v.Km += gestionFlotte.TrajetList.Find(trajet => trajet.NTrajet == v.NTrajet).Distance;
            v.NTrajet = -1;
            
        }
    }
}