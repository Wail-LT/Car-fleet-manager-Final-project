using System;

namespace Final_Project.Exceptions.Voiture
{
    public class ErreurNVehicule: Exception
    {
        public ErreurNVehicule() : base("ERREUR : le numéro saisie est incorrect ne correspond à aucun vehicule") { }
    }
}