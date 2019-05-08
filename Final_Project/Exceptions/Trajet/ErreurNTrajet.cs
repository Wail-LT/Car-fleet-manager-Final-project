using System;

namespace Final_Project.Exceptions.Trajet
{
    public class ErreurNTrajet : Exception
    {
        public ErreurNTrajet() : base("ERREUR : le numéro saisie est incorrect ou ne correspond à aucun trajet") { }
    }
}