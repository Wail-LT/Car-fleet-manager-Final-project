using System;

namespace Final_Project.Exceptions.Voiture.Moto
{
    public class ErreurCylindre :Exception
    {
        public ErreurCylindre() : base("ERREUR : la cylindré saisie est incorrect elle doit être comprise entre 50 et 1500 cm3") { }
    }
}