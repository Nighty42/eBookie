using System;

namespace eBookie.model
{
    [Serializable]
    public class Device
    {
        public string Name { get; set; }

        public Device(string name)
        {
            Name = name;
        }
    }
}
