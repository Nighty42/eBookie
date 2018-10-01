using EBookie.model;
using EBookie.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EBookie.services
{
    public class ReadWriteService
    {
        static ReadWriteService instance;

        public static ReadWriteService Instance
        {
            get { return instance ?? (instance = new ReadWriteService()); }
        }

        private bool check_string(string s)
        {
            if (s.Trim().ToLower().Equals(string.Empty))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //*****************************************************************************************//
        //*************************** Methoden zum Einlesen von Dateien ***************************//
        //*****************************************************************************************//

        public void read_out_settings_xml()
        {
            if (!File.Exists(AppController.Instance.PATH_TO_PROGRAM + "settings.xml"))
            {
                // Standardwerte setzen
                AppController.Instance.SETTINGS.LANGUAGE = new Language(AppController.Instance.SETTINGS.STD_LANGUAGE.NAME, AppController.Instance.SETTINGS.STD_LANGUAGE.CODE);
            }
            else
            {
                XmlSerializer reader = new XmlSerializer(typeof(Settings));
                using (FileStream input = File.OpenRead(AppController.Instance.PATH_TO_SETTINGS))
                {
                    Settings rx = reader.Deserialize(input) as Settings;

                    string name = string.Empty;
                    string code = rx.LANGUAGE.CODE.Trim();

                    switch (code)
                    {
                        case "en-GB":
                            name = "English";
                            break;
                        default:
                            name = "Deutsch";
                            break;
                    }

                    AppController.Instance.SETTINGS.LANGUAGE = new Language(name, code);

                    if (AppController.Instance.SETTINGS.LANGUAGE.NAME.ToString().Equals(string.Empty) || (AppController.Instance.SETTINGS.LANGUAGE.CODE.ToString().Equals(string.Empty)))
                    {
                        AppController.Instance.SETTINGS.LANGUAGE.NAME = AppController.Instance.SETTINGS.STD_LANGUAGE.NAME;
                        AppController.Instance.SETTINGS.LANGUAGE.CODE = AppController.Instance.SETTINGS.STD_LANGUAGE.CODE;
                    }
                }
            }
        }

        //*****************************************************************************************//
        //************************** Methoden zum Schreiben von Dateien ***************************//
        //*****************************************************************************************//

        public void write_settings_to_xml()
        {
            XmlSerializer writer = new XmlSerializer(typeof(Settings));

            using (FileStream output = File.OpenWrite(AppController.Instance.PATH_TO_SETTINGS))
            {
                writer.Serialize(output, AppController.Instance.SETTINGS);
            }
        }
    }
}
