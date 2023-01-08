using Godot;
using System;

namespace LudumDare52.Saving
{
    public static class SaveLoad
    {
        private const string FILE_PATH = "user://save.dat";

        public static void Save(int bestScore)
        {
            File file = new File();
            file.Open(FILE_PATH, File.ModeFlags.Write);
            file.Store64((ulong)bestScore);
            file.Close();
        }

        public static int Load()
        {
            File file = new File();
            if (!file.FileExists(FILE_PATH))
            {
                return 0;
            }
            file.Open(FILE_PATH, File.ModeFlags.Read);
            int bestScore = (int)file.Get64();
            file.Close();
            return bestScore;
        }
    }
}