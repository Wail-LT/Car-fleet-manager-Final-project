using System;

namespace Final_Project.Exceptions
{
    public class ErreurPermis:Exception
    {
        public ErreurPermis() : base("ERREUR : Ce type de Permis ne fait pas partie de la liste") { }
    }
}