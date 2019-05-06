using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurCouleur : Exception
    {
        public ErreurCouleur() : base("ERREUR : le champ couleur est obligatoire") { }
    }
}