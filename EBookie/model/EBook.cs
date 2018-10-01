using System;

namespace EBookie.model
{
    [Serializable]
    public class EBook
    {
        private string _title;
        public string TITLE    // obligatorisch
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private string _author;
        public string AUTHOR
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public EBook(string _title, string _author)
        {
            TITLE = _title;
            AUTHOR = _author;
        }
    }
}