using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurNBPortes : Exception
    {
        public ErreurNBPortes() : base(
            "ERREUR : le nombre de porte saisie est incorrect il doit être compris entre 3 et 5")
        {
        }
    }
}