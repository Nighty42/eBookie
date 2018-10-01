using System;
using System.Xml.Serialization;

namespace EBookie.model
{
    [Serializable]
    public class Language
    {
        [XmlIgnore]
        public string NAME { get; set; }    // Anzeigename der Sprache
        public string CODE { get; set; }    // Culture Sprachcodes - ist leer, wenn Sprache nicht von Anwendung unterstützt wird

        public Language() { }

        public Language(string name, string code)
        {
            NAME = name;
            CODE = code;
        }
    }
}
