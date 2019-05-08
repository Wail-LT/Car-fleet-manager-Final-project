using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurType : Exception
    {
        public ErreurType() : base(
            "ERREUR : le type saisie ne fait pas partie de la liste")
        {
        }
    }
}