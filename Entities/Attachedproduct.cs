using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Attachedproduct
    {
        public int MainProductId { get; set; }
        public int AttachedProductId { get; set; }

        public virtual Product AttachedProduct { get; set; }
        public virtual Product MainProduct { get; set; }
    }
}
