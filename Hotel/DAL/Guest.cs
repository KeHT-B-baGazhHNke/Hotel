using System;

namespace Hotel.DAL
{
    internal class Guest
    {
        public int id { get; internal set; }
        public string Name { get; internal set; }
        public string Status { get; internal set; }
        public string DateIn { get; internal set; }
        public string DateOut { get; internal set; }
    }
}