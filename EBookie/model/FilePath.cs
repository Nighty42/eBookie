using System;

namespace EBookie.model
{
    [Serializable]
    public class FilePath
    {
        public string FILENAME { get; set; }
        public string PATH { get; set; }

        public FilePath(string filename, string path)
        {
            FILENAME = filename;
            PATH = path;
        }

        public FilePath() { }
    }
}
