using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Servicephoto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string PhotoPath { get; set; }

        public virtual Service Service { get; set; }
    }
}
