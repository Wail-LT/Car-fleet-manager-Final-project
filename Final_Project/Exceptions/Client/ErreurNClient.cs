using System;

namespace Final_Project.Exceptions
{
    public class ErreurNClient : Exception
    {
        public ErreurNClient() : base("ERREUR : le numéro saisie est incorrect ou ne correspond à aucun client") { }
    }
}