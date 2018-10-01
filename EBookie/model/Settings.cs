using System;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;

namespace EBookie.model
{
    [Serializable]
    public class Settings
    {
        public Language LANGUAGE { get; set; }

        [XmlIgnore]
        public Language STD_LANGUAGE { get; set; }

        public Settings()
        {
            LANGUAGE = new Language();
        }

        public void change_language(string language_code)
        {
            LANGUAGE.CODE = language_code;
            CultureInfo newCulture = new CultureInfo(language_code);

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;
            languages.Resources.Culture = newCulture;
        }
    }
}
