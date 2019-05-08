using System;

namespace Final_Project.Exceptions.Parking
{
    public class ErreurPlaceIndisp : Exception
    {
        public ErreurPlaceIndisp() : base("Erreur : Aucune place disponible dans les parking")
        {
        }
    }
}