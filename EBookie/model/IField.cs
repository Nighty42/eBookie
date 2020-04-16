using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace eBookie.model
{
    public class IField
    {
        // public object IFOBJECT { get; set; }
        public Label Label { get; set; }
        public Image StatusImage { get; set; }
        public bool IsObligatory { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string[] Searchpattern { get; set; }
        public int[] MinChars { get; set; }
        public bool IsSpaceAllowed { get; set; }
        public string[] Placeholder { get; set; }
        public int Status { get; set; }

        private readonly ComboBox IfComboBox;
        private readonly TextBox IfTextBox;
        private readonly PasswordBox IfPasswordBox;
        private readonly int ObjectType = 0;

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
            Label = label;
            StatusImage = statusimg;
            IsObligatory = obligatory;
            MinLength = min_length;
            MaxLength = max_length;
            Searchpattern = searchpattern;
            MinChars = min_chars;
            IsSpaceAllowed = space_allowed;
            Placeholder = placeholder;

            Status = 0;

            ObjectType = object_type;
        }


        public IField(TextBox ifobject, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
            : this(1, label, statusimg, obligatory, min_length, max_length, searchpattern, min_chars, space_allowed, placeholder)
        {
            IfTextBox = ifobject;
        }

        public IField(ComboBox ifobject, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
            : this(2, label, statusimg, obligatory, min_length, max_length, searchpattern, min_chars, space_allowed, placeholder)
        {
            IfComboBox = ifobject;
        }

        public IField(PasswordBox ifobject, Label label, Image statusimg, bool obligatory, int min_length, int max_length, string[] searchpattern, int[] min_chars, bool space_allowed, string[] placeholder)
            : this(3, label, statusimg, obligatory, min_length, max_length, searchpattern, min_chars, space_allowed, placeholder)
        {
            IfPasswordBox = ifobject;
        }

        public string Text
        {
            get
            {
                switch (ObjectType)
                {
                    case 1:
                        return IfTextBox.Text;
                    case 2:
                        return IfComboBox.Text;
                    case 3:
                        return IfPasswordBox.Password;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (ObjectType)
                {
                    case 1:
                        IfTextBox.Text = value;
                        break;
                    case 2:
                        IfComboBox.Text = value;
                        break;
                    case 3:
                        IfPasswordBox.Password = value;
                        break;
                }
            }
        }

        public string IfName
        {
            get
            {
                switch (ObjectType)
                {
                    case 1:
                        return IfTextBox.Name;
                    case 2:
                        return IfComboBox.Name;
                    case 3:
                        return IfPasswordBox.Name;
                    default:
                        return null;
                }
            }
        }
    }
}
