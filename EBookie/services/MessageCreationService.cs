using EBookie.model;
using EBookie.view;
using System.Resources;
using System.Windows.Media;

namespace EBookie.services
{
    public class MessageCreationService
    {
        public static string create_message(string stringname, object[] args, int status)
        {
            ResourceManager resManager = languages.Resources.ResourceManager;
            string message = string.Empty;

            if (args == null)
            {
                message = resManager.GetString(stringname);
            }
            else
            {
                message = string.Format(resManager.GetString(stringname), args);
            }

            if (status > -1)
            {
                show_message(message, status);
            }

            return message;
        }

        private static void show_message(string message, int status)
        {
            // Schriftfarbe ändern
            switch (status)
            {
                case 0:
                    AppWindow.Instance.tb_status.Foreground = Brushes.Black;
                    break;
                case 1:
                    AppWindow.Instance.tb_status.Foreground = Brushes.Red;
                    break;
                case 2:
                    AppWindow.Instance.tb_status.Foreground = Brushes.Green;
                    break;
            }

            AppWindow.Instance.tb_status.Text = message;
        }

        public static string create_message_from_ifield_status(IField ifield, bool show)
        {
            int status = -1;
            string message = string.Empty;

            if(show)
            {
                status = 1;
            }

            // Error-Nachricht ausgeben
            switch (ifield.STATUS)
            {
                case 0:
                    message = create_message("waiting_for_input", null, 0);
                    break;
                // Status: 1 (leer)
                case 1:
                    message = create_message("e_missing_input", new object[] { ifield.LABEL.Content.ToString() }, status);
                    break;
                // Status: 2 (> max_length)
                case 2:
                    message = create_message("e_above_max_length", new object[] { ifield.MAX_LENGTH, ifield.LABEL.Content.ToString() }, status);
                    break;
                // Status: 3 (< min_length)
                case 3:
                    message = create_message("e_under_min_length", new object[] { ifield.MIN_LENGTH, ifield.LABEL.Content.ToString() }, status);
                    break;
                // Status: 4 (ungültiger Wert)
                case 4:
                    message = create_message("msg_ecode_04", null, status);
                    break;
                // Status: 5 (zu wenig Großbuchstaben)
                case 5:
                    message = create_message("msg_ecode_05", new object[] { ifield.MIN_CHARS[0].ToString() }, status);
                    break;
                // Status: 6 (zu wenig Kleinbuchstaben)
                case 6:
                    message = create_message("msg_ecode_06", new object[] { ifield.MIN_CHARS[1].ToString() }, status);
                    break;
                // Status: 7 (zu wenig Zahlen)
                case 7:
                    message = create_message("msg_ecode_07", new object[] { ifield.MIN_CHARS[2].ToString() }, status);
                    break;
                // Status: 8 (zu wenig Sonderzeichen)
                case 8:
                    message = create_message("msg_ecode_08", new object[] { ifield.MIN_CHARS[3].ToString() }, status);
                    break;
                // Status: 9 (ungültige Leerzeichen)
                case 9:
                    message = create_message("msg_ecode_09", new object[] { ifield.LABEL.Content.ToString() }, status);
                    break;
            }

            return message;
        }
    }
}
