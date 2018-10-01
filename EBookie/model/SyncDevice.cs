namespace EBookie.model
{
    public class SyncDevice
    {
        private string _name;
        public string NAME    // obligatorisch
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public SyncDevice(string _name)
        {
            NAME = _name;
        }
    }
}