using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Productphoto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string PhotoPath { get; set; }

        public virtual Product Product { get; set; }
    }
}
