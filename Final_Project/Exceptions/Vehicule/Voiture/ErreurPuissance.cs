using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurPuissance : Exception
    {
        public ErreurPuissance() : base("ERREUR : la puissance saisie est incorrect elle doit être comprise entre 70 et 650ch") { }
    }
}