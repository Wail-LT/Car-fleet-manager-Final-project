
using System;

namespace Final_Project.Parking
{
    public class Parking
    {
        private readonly Place[] places;

        public Parking(Action<Place[], Parking> remplirTab)
        {
            places = new Place[10];
            remplirTab(places, this);
        }

        /* Properties */

        public Place[] Places => places;

        /* Public Methodes */

        public Place GetPlace(int numPlace)
        {
            return places[numPlace];
        }
    }
}