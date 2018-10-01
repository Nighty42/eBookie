namespace EBookie.model
{
    public class EBookFolder
    {
        private string _path;
        public string PATH    // obligatorisch
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        private string _device;
        public string DEVICE    // obligatorisch
        {
            get
            {
                return _device;
            }
            set
            {
                _device = value;
            }
        }

        public EBookFolder(string _path, string _device)
        {
            PATH = _path;
            DEVICE = _device;
        }
    }
}
