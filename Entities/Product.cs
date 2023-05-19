using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Product
    {
        public Product()
        {
            AttachedproductAttachedProducts = new HashSet<Attachedproduct>();
            AttachedproductMainProducts = new HashSet<Attachedproduct>();
            Productphotos = new HashSet<Productphoto>();
            Productsales = new HashSet<Productsale>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string MainImagePath { get; set; }
        public bool IsActive { get; set; }
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Attachedproduct> AttachedproductAttachedProducts { get; set; }
        public virtual ICollection<Attachedproduct> AttachedproductMainProducts { get; set; }
        public virtual ICollection<Productphoto> Productphotos { get; set; }
        public virtual ICollection<Productsale> Productsales { get; set; }
    }
}
