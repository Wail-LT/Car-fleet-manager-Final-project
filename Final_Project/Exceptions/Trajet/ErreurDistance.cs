using System;

namespace Final_Project.Exceptions.Trajet
{
    public class ErreurDistance : Exception
    {
        public ErreurDistance() : base("ERREUR : le distance saisie est incorrect") { }
    }
}