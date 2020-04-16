using System.IO;
using System.Text;

namespace eBookie.model
{
    public class EBookFolder
    {
        public string Path { get; set; }
        public string Device { get; set; }
        public EBookList EBookList { get; set; }

        public EBookFolder(string path, string device, EBookList eBookList)
        {
            Path = path;
            Device = device;
            EBookList = eBookList;
        }

        public void Read()
        {
            EBookList.Clear();

            if(Directory.Exists(Path))
            {
                StringBuilder formats = new StringBuilder("");
                for(int i = 0; i < EBook.Formats.Count; i++)
                {
                    formats.Append($"{EBook.Formats[i]}");
                    if(i < EBook.Formats.Count)
                    {
                        formats.Append($"|");
                    }
                }

                string[] files = Directory.GetFiles(Path, $"^+\\.({formats})$");
            }
        }
    }
}
