using Final_Project.Vehicules;

namespace Final_Project.Parking
{
    public class Place
    {
        private Vehicule vehicule;
        private Parking parking;
        private readonly int nPlace;

        public Place(Parking parking, int nPlace)
        {
            this.vehicule = null;
            this.parking = parking;
            this.nPlace = nPlace;
        }

        /* Properties */

        public Vehicule Vehicule { get => vehicule; set => vehicule = value; }
        public bool IsDisponible => vehicule == null;

        public Parking Parking => parking;

        public int NPlace => nPlace;
    }
}