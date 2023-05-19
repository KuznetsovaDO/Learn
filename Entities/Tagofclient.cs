using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Tagofclient
    {
        public int ClientId { get; set; }
        public int TagId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
