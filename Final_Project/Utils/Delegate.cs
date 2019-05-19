using Final_Project.Parking;

namespace Final_Project.Utils
{
    public class Delegate
    {
        /**
         * Remplit un tableau de places avec des places vides
         */
        public static void RemplirTabPlaceDisp(Place[] tab, Parking.Parking parking)
        {
            for (int i = 0; i < tab.Length; i++) 
                tab[i] = new Place(parking, i);
        }
    }
}