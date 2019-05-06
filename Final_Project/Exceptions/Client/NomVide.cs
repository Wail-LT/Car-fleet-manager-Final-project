using System;

namespace Final_Project.Exceptions
{
    public class NomVide : Exception
    {
        public NomVide() : base("ERREUR : le champ nom est obligatoire") { }
    }
}