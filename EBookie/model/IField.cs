using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace EBookie.model
{
    public class IField
    {
        // public object IFOBJECT { get; set; }
        public Label LABEL { get; set; }
        public Image STATUSIMG { get; set; }
        public bool OBLIGATORY { get; set; }
        public int MIN_LENGTH { get; set; }
        public int MAX_LENGTH { get; set; }
        public string[] SEARCHPATTERN { get; set; }
        public int[] MIN_CHARS { get; set; }
        public bool SPACE_ALLOWED { get; set; }
        public string[] PLACEHOLDER { get; set; }
        public int STATUS { get; set; }

        private ComboBox ifobject_cb;
        private TextBox ifobject_tb;
        private PasswordBox ifobject_pb;

        private int object_type = 0;

        public IField() { }

        /// <param name="label">(Label) - Label zu dem Eingabefeld</param>
        /// <param name="statusimg">(Image) - Status-Image zu dem Eingabefeld für Tooltip-Manipulation</param>
        /// <param name="obligatory">(Boolean) - Obgligatorisches oder optionales Eingabefeld</param>
        /// <param name="min_length">(Integer) - Minimale Länge des Inhalts</param>
        /// <param name="max_length">(Integer) - Maximale Länge des Inhalts</param>
        /// <param name="searchpattern">(String-Array) - Suchmuster für gültige Werte</param>
        /// <param name="min_chars">(Int-Array) - Gibt an, ob zu wenig Großbuchstaben, Kleinbuchstaben, Ziffern und/oder Sonderzeichen</param>
        /// <param name="space_allowed">(bool) - Gibt an, ob Leerzeichen erlaubt sind</param>
        /// <param name="placeholder">(String-Array) - Platzhalter für Eingabefeld (z.B. "<Hinzufügen...>"), Platzhalter werden wie leere Inhalte behandelt</param>
        /// <param name="status">(Integer) - Status, Errorcode</param>
        /// <param name="status">Errorcodes: 0 = ok, 1 = leer, 2 = Maximale Länge überschritten, 3 = Minimale Länge unterschritten, 4 = Ungültiger Wert</param>

        private IField(int object_type, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
        {
            LABEL = label;
            STATUSIMG = statusimg;
            OBLIGATORY = obligatory;
            MIN_LENGTH = min_length;
            MAX_LENGTH = max_length;
            SEARCHPATTERN = searchpattern;
            MIN_CHARS = min_chars;
            SPACE_ALLOWED = space_allowed;
            PLACEHOLDER = placeholder;

            STATUS = 0;

            this.object_type = object_type;
        }


        public IField(TextBox ifobject, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
            : this(1, label, statusimg, obligatory, min_length, max_length, searchpattern, min_chars, space_allowed, placeholder)
        {
            ifobject_tb = ifobject;
        }

        public IField(ComboBox ifobject, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
            : this(2, label, statusimg, obligatory, min_length, max_length, searchpattern, min_chars, space_allowed, placeholder)
        {
            ifobject_cb = ifobject;
        }

        public IField(PasswordBox ifobject, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
            : this(3, label, statusimg, obligatory, min_length, max_length, searchpattern, min_chars, space_allowed, placeholder)
        {
            ifobject_pb = ifobject;
        }

        public string TEXT
        {
            get
            {
                switch (object_type)
                {
                    case 1:
                        return ifobject_tb.Text;
                    case 2:
                        return ifobject_cb.Text;
                    case 3:
                        return ifobject_pb.Password;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (object_type)
                {
                    case 1:
                        ifobject_tb.Text = value;
                        break;
                    case 2:
                        ifobject_cb.Text = value;
                        break;
                    case 3:
                        ifobject_pb.Password = value;
                        break;
                }
            }
        }

        public string IFNAME
        {
            get
            {
                switch (object_type)
                {
                    case 1:
                        return ifobject_tb.Name;
                    case 2:
                        return ifobject_cb.Name;
                    case 3:
                        return ifobject_pb.Name;
                    default:
                        return null;
                }
            }
        }
    }
}
