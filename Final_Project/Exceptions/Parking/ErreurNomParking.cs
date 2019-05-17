using System;

namespace Final_Project.Exceptions.Parking
{
    public class ErreurNomParking : Exception
    {
        public ErreurNomParking() : base("Erreur : Nom du parking erronée")
        {
        }
    }
}