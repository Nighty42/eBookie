using eBookie.model;
using eBookie.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace eBookie.services
{
    public class ReadWriteService
    {
        static ReadWriteService instance;

        public static ReadWriteService Instance
        {
            get { return instance ?? (instance = new ReadWriteService()); }
        }

        public void ReadSettings()
        {
            if (!File.Exists(NavigationController.Instance.PathToProgram + "settings.xml"))
            {
                // Standardwerte setzen
                Settings.Instance.Language = new Language(Settings.Instance.DefaultLanguage.Name, Settings.Instance.DefaultLanguage.Code);
            }
            else
            {
                XmlSerializer reader = new XmlSerializer(typeof(Settings));
                using (FileStream input = File.OpenRead(NavigationController.Instance.PathToSettings))
                {
                    Settings rx = reader.Deserialize(input) as Settings;

                    string name = string.Empty;
                    string code = rx.Language.Code.Trim();

                    switch (code)
                    {
                        case "en-GB":
                            name = "English";
                            break;
                        default:
                            name = "Deutsch";
                            break;
                    }

                    Settings.Instance.Language = new Language(name, code);

                    if (Settings.Instance.Language.Name.ToString().Equals(string.Empty) || (Settings.Instance.Language.Code.ToString().Equals(string.Empty)))
                    {
                        Settings.Instance.Language.Name = Settings.Instance.DefaultLanguage.Name;
                        Settings.Instance.Language.Code = Settings.Instance.DefaultLanguage.Code;
                    }
                }
            }
        }

        public void WriteSettings()
        {
            XmlSerializer writer = new XmlSerializer(typeof(Settings));

            using (FileStream output = File.OpenWrite(NavigationController.Instance.PathToSettings))
            {
                writer.Serialize(output, Settings.Instance);
            }
        }
    }
}
