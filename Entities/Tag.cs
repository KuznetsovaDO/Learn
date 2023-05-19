using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Tag
    {
        public Tag()
        {
            Tagofclients = new HashSet<Tagofclient>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Tagofclient> Tagofclients { get; set; }
    }
}
