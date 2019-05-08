using Final_Project.Vehicules;

namespace Final_Project.Parking
{
    public class Place
    {
        private Vehicule vehicule;
        private Parking parking;

        public Place(Parking parking)
        {
            this.vehicule = null;
            this.parking = parking;
        }

        /* Properties */

        public Vehicule Vehicule { get => vehicule; set => vehicule = value; }
        public bool IsDisponible => vehicule == null;
    }
}