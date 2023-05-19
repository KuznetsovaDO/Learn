using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Clientservice
    {
        public Clientservice()
        {
            Documentbyservices = new HashSet<Documentbyservice>();
            Productsales = new HashSet<Productsale>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public string Comment { get; set; }

        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<Documentbyservice> Documentbyservices { get; set; }
        public virtual ICollection<Productsale> Productsales { get; set; }
    }
}
