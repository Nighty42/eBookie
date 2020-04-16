using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace eBookie.model
{
    [Serializable]
    public class EBook
    {
        public static readonly ReadOnlyCollection<string> Formats = new ReadOnlyCollection<string>(new string[] {
            "azw", "azw3", 
            "cb7", "cba", "cbr", "cbt", "cbz", 
            "epub", 
            "kf8", 
            "mobi", 
            "pdf", "prc" });

        public string Title { get; set; }
        public string Author { get; set; }

        public EBook(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
