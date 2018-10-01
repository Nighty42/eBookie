using EBookie.model;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Collections.Generic;

/* ToDo:
    - Duplikate abfangen, wenn entsprechender Boolean gesetzt (nur in check_input())
    - 
*/

namespace EBookie.services
{
    public static class CheckInput
    {
        // Einzelnes Eingabefeld nach Änderung prüfen und Meldung ausgeben
        public static bool check_single_ifield(IField ifield)
        {
            string message = string.Empty;

            check_if_ok(ifield);

            message = MessageCreationService.create_message_from_ifield_status(ifield, true);

            if (ifield.STATUS == 0)
            {
                ifield.LABEL.Foreground = Brushes.Black;

                if (ifield.STATUSIMG != null)
                {
                    ifield.STATUSIMG.ToolTip = null;
                }

                return true;
            }
            else
            {
                ifield.LABEL.Foreground = Brushes.Red;

                if (ifield.STATUSIMG != null)
                {
                    ifield.STATUSIMG.ToolTip = message;
                }

                return false;
            }
        }

        // Initialisierung der jeweiligen Page, Überprüfung aller Eingabefelder, Ausgabe 1. Meldung
        public static bool check_every_ifield(List<IField> IFIELDS)
        {
            IField err_candidate = null;

            // Alle Eingabefelder überprüfen
            foreach (IField ifield in IFIELDS)
            {
                check_if_ok(ifield);

                // Status: 0 (ok)
                if (ifield.STATUS == 0)
                {
                    ifield.LABEL.Foreground = Brushes.Black;

                    // Tooltip für Status-Image des Eingabefeldes setzen
                    if (ifield.STATUSIMG != null)
                    {
                        // Tooltip des Status-Images entfernen
                        ifield.STATUSIMG.ToolTip = null;
                    }
                }
                else
                {
                    ifield.LABEL.Foreground = Brushes.Red;

                    // Tooltip für Status-Image des Eingabefeldes setzen
                    if (ifield.STATUSIMG != null)
                    {
                        // Error-Nachricht für Tooltip des Status-Images
                        ifield.STATUSIMG.ToolTip = MessageCreationService.create_message_from_ifield_status(ifield, false);
                    }

                    if (err_candidate == null)
                    {
                        err_candidate = ifield;
                    }
                }
            }

            // Status: 0 (alles ok)
            if (err_candidate == null)
            {
                MessageCreationService.create_message("waiting_for_input", null, 0);

                return true;
            }
            // Status: 1-.. Fehler aufgetaucht
            else
            {
                MessageCreationService.create_message_from_ifield_status(err_candidate, true);

                return false;
            }
        }

        // Einzelnes IField überprüfen
        /// <param name="Rückgabewert">(Integer) - Errorcodes: 0 = ok, 1 = leer, 2 = Maximale Länge überschritten, 3 = Minimale Länge unterschritten, 4 = Ungültiger Wert, 5 = Nicht genug upper, 6 = Nicht genug lower, 7 = Nicht genug digits, 8 = Nicht genug specials, 9 = unerlaubte Leerzeichen gefunden</param>
        public static void check_if_ok(IField ifield)
        {
            ifield.STATUS = 0;

            // Nur obligatorische Felder
            if (check_if_empty(ifield) && ifield.OBLIGATORY)
            {
                ifield.STATUS = 1;
                return;
            }

            // Nur obligatorische Felder
            if (check_if_placeholder(ifield) && ifield.OBLIGATORY)
            {
                ifield.STATUS = 1;
                return;
            }

            if (check_if_over_max_length(ifield))
            {
                ifield.STATUS = 2;

                if (ifield.OBLIGATORY)
                {
                    return;
                }
            }

            if (check_if_under_min_length(ifield))
            {
                ifield.STATUS = 3;
                return;
            }

            if (check_if_invalid_value(ifield))
            {
                ifield.STATUS = 4;
                return;
            }

            // Status 5 - 8
            if (ifield.MIN_CHARS != null)
            {
                check_if_min_valid_chars(ifield);
                return;
            }

            if (!ifield.SPACE_ALLOWED && check_if_contains_space(ifield))
            {
                ifield.STATUS = 9;
                return;
            }

            return;
        }

        // Inhalt leer?
        private static bool check_if_empty(IField ifield)
        {
            // Nur prüfen, wenn obligatorisch
            if (ifield.TEXT.Trim().Equals(string.Empty))
            {
                return true;
            }

            return false;
        }

        private static bool check_if_placeholder(IField ifield)
        {
            if (ifield.PLACEHOLDER != null)
            {
                foreach (string ph in ifield.PLACEHOLDER)
                {
                    if (ifield.TEXT.Equals(ph))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Höchstlänge überschritten?
        private static bool check_if_over_max_length(IField ifield)
        {
            if (ifield.MAX_LENGTH == -1)
            {
                return false;
            }
            else if (ifield.TEXT.Length > ifield.MAX_LENGTH)
            {
                return true;
            }

            return false;
        }

        // Mindestlänge unterschritten?
        private static bool check_if_under_min_length(IField ifield)
        {
            // Nur prüfen, wenn obligatorisch
            if (ifield.OBLIGATORY)
            {
                if (ifield.MIN_LENGTH == -1)
                {
                    return false;
                }
                else if (ifield.TEXT.Length < ifield.MIN_LENGTH)
                {
                    return true;
                }
            }

            return false;
        }

        // Ungültiger Wert?
        private static bool check_if_invalid_value(IField ifield)
        {
            if (ifield.SEARCHPATTERN != null)
            {
                foreach (string search_pattern in ifield.SEARCHPATTERN)
                {
                    Match m = Regex.Match(ifield.TEXT, search_pattern);
                    if (m.Success)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        // Minimale Anzahl Zeichen eingegeben?
        private static void check_if_min_valid_chars(IField ifield)
        {
            int no_upper = 0;
            int no_lower = 0;
            int no_digit = 0;
            int no_sz = 0;

            foreach (char c in ifield.TEXT)
            {
                if (char.IsUpper(c))
                {
                    no_upper += 1;
                }
                else if (char.IsLower(c))
                {
                    no_lower += 1;
                }
                else if (char.IsDigit(c))
                {
                    no_digit += 1;
                }
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    no_sz += 1;
                }
            }

            if (no_upper < ifield.MIN_CHARS[0])
            {
                ifield.STATUS = 5;
            }
            else if (no_lower < ifield.MIN_CHARS[1])
            {
                ifield.STATUS = 6;
            }
            else if (no_digit < ifield.MIN_CHARS[2])
            {
                ifield.STATUS = 7;
            }
            else if (no_sz < ifield.MIN_CHARS[3])
            {
                ifield.STATUS = 8;
            }
        }

        // Enthält die Eingabe Leerzeichen?
        private static bool check_if_contains_space(IField ifield)
        {
            if (Regex.IsMatch(ifield.TEXT, @"\s"))
            {
                return true;
            }

            return false;
        }
    }
}
