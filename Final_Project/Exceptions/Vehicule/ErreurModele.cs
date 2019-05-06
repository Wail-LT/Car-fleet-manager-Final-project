using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurModele : Exception
    {
        public ErreurModele() : base("ERREUR : le champ modele est obligatoire") { }
    }
}