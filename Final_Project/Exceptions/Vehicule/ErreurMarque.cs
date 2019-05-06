using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurMarque : Exception
    {
        public ErreurMarque() : base("ERREUR : le champ marque est obligatoire") { }
    }
}