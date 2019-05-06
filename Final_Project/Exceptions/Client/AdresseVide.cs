using System;

namespace Final_Project.Exceptions
{
    public class AdresseVide : Exception
    {
        public AdresseVide() : base("ERREUR : le champ adresse est obligatoire") { }
    }
}