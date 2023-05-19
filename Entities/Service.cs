using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Service
    {
        public Service()
        {
            Clientservices = new HashSet<Clientservice>();
            Servicephotos = new HashSet<Servicephoto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int DurationInSeconds { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public string MainImagePath { get; set; }

        public virtual ICollection<Clientservice> Clientservices { get; set; }
        public virtual ICollection<Servicephoto> Servicephotos { get; set; }
    }
}
