using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurKm : Exception
    {
        public ErreurKm() : base("ERREUR : le champ km est incorrect il doit être suppèrieur à 0") { }
    }
}