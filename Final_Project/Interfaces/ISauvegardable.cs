using System.IO;

namespace Final_Project
{
    public interface ISauvegardable
    {
        void Sauvegarder(StreamWriter fWriter);
    }
}