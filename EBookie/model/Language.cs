using System;
using System.Xml.Serialization;

namespace eBookie.model
{
    [Serializable]
    public class Language
    {
        [XmlIgnore]
        public string Name { get; set; }    // Anzeigename der Sprache
        public string Code { get; set; }    // Culture Sprachcodes - ist leer, wenn Sprache nicht von Anwendung unterstützt wird

        public Language() { }

        public Language(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
