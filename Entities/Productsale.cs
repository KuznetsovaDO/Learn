using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Productsale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? ClientServiceId { get; set; }

        public virtual Clientservice ClientService { get; set; }
        public virtual Product Product { get; set; }
    }
}
