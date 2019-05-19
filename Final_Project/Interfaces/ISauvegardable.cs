using System;
using System.IO;

namespace Final_Project
{
    public interface ISauvegardable
    {
        void Sauvegarder(StreamWriter fWriter, string before = "", string after = "");
    }
}