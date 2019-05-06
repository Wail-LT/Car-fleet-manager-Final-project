using System;

namespace Final_Project.Exceptions
{
    public class PrenomVide : Exception
    {
        public PrenomVide() : base("ERREUR : le champ prénom est obligatoire") { }

    }
}