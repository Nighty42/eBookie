using System.Collections.ObjectModel;

namespace eBookie.model
{
    class EBookFolderList : ObservableCollection<EBookFolder>
    {
        private static EBookFolderList instance;
        public static EBookFolderList Instance
        {
            get
            {
                if (instance == null)
                {
                    EBookFolder[] eBookFolders = new EBookFolder[] {
                                    new EBookFolder("[Alle E-Books anzeigen...]", "---", new EBookList()),
                                    new EBookFolder("D:/E-Books/", "TEST", new EBookList()),
                                    new EBookFolder("X:/Privat/Freizeit/eBooks/", "KOBO GLO HD", new EBookList()) };

                    instance = new EBookFolderList(eBookFolders);
                }

                return instance;
            }
        }

        private EBookFolderList(EBookFolder[] eBookFolder)
        {
            for (int i = 0; i < eBookFolder.Length; i++)
            {
                Add(eBookFolder[i]);
            }
        }
    }
}
