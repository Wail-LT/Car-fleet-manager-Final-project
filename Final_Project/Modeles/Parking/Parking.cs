
using System;
using System.Collections.Generic;
using Final_Project.Exceptions;

namespace Final_Project.Parking
{
    public class Parking
    {
        private readonly Place[] places;
        public  int NbPlaces = 10;
        private string nom;

        public Parking(Action<Place[], Parking> remplirTab, string nom)
        {
            places = new Place[NbPlaces];
            remplirTab(places, this);
            this.nom = nom;
        }

        /* Properties */

        public Place[] Places => places;
        public bool IsPlein
        {
            get
            {
                int i = 0;
                while (i < NbPlaces && !places[i].IsDisponible) { i++; }

                return i == NbPlaces && !places[NbPlaces - 1].IsDisponible;
            }
        }

        public string Nom { get => nom; set => nom = value; }

        /* Public Methodes */

        public Place GetPlace(int numPlace)
        {
            return places[numPlace];
        }

        public Place GetPlaceDisp()
        {
            int i = 0;
            while (!places[i].IsDisponible && i < NbPlaces) { i++; }

            if (i == NbPlaces && !places[i - 1].IsDisponible)
                return null;
            if (i == NbPlaces)
                return places[i - 1];
            return places[i];
        }

        public List<Place> GetPlacesDisp()
        {
            List<Place> lPlaces = new List<Place>();
            for (int i = 0; i < places.Length; i++)
            {
                if (places[i].IsDisponible)
                    lPlaces.Add(places[i]);
            }

            return lPlaces.Count == 0 ? null : lPlaces;
        }

    }
}