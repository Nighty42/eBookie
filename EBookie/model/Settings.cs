using eBookie.services;
using System;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;

namespace eBookie.model
{
    [Serializable]
    public class Settings
    {
        public Language Language { get; set; }

        [XmlIgnore]
        public Language DefaultLanguage { get; set; }

        public static Settings Instance { get; set; } = new Settings();
        private Settings()
        {
            Language = new Language();

            DefaultLanguage = LanguageController.Instance.SupportedLanguages.Find(x => x.Code == CultureInfo.CurrentCulture.Name);

            if (DefaultLanguage == null)
            {
                DefaultLanguage = LanguageController.Instance.SupportedLanguages.Find(x => x.Code == "en-GB");
            }
        }

        public void ChangeLanguage(string language_code)
        {
            Language.Code = language_code;
            CultureInfo newCulture = new CultureInfo(language_code);

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;
            i18n.Resources.Culture = newCulture;
        }
    }
}
