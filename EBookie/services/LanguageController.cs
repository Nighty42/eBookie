using eBookie.model;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace eBookie.services
{
    public class LanguageController
    {
        public readonly List<Language> SupportedLanguages = new List<Language>() { 
            new Language("Deutsch", "de-DE"), 
            new Language("English", "en-GB") };

        public static LanguageController Instance { get; set; } = new LanguageController();

        public void InitLanguage()
        {
            SetAppLanguage(Settings.Instance.Language.Code);
        }

        // Sprache der Anwendung ändern
        public void ChangeLanguage()
        {
            if (i18n.Resources.Culture.Name.Equals("de-DE"))
            {
                SetAppLanguage("en-GB");
            }
            else
            {
                SetAppLanguage("de-DE");
            }
        }

        // Sprache der Anwendung setzen
        private void SetAppLanguage(string language)
        {
            CultureInfo new_culture;

            if (language.Equals("de-DE"))
            {
                new_culture = new CultureInfo("de-DE");
                Settings.Instance.Language.Name = "Deutsch";
                Settings.Instance.Language.Code = "de-DE";
            }
            else
            {
                new_culture = new CultureInfo("en-GB");
                Settings.Instance.Language.Name = "English";
                Settings.Instance.Language.Code = "en-GB";
            }

            // Culture der Anwendung ändern
            i18n.Resources.Culture = new_culture;
            Thread.CurrentThread.CurrentCulture = new_culture;
        }
    }
}
