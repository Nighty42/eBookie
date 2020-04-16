using System;

namespace eBookie.model
{
    [Serializable]
    public class FilePath
    {
        public string Filename { get; set; }
        public string Path { get; set; }

        public FilePath(string filename, string path)
        {
            Filename = filename;
            Path = path;
        }

        public FilePath() { }
    }
}
