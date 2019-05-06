using System;

namespace Final_Project.Exceptions.Voiture.Camion
{
    public class ErreurCapacite : Exception
    {
        public ErreurCapacite() : base("ERREUR : la capacité saisie est incorrect elle doit être comprise entre 2.75 et 22 m3") { }
    }
}