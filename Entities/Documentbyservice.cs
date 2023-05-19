using System;
using System.Collections.Generic;

#nullable disable

namespace Learn
{
    public partial class Documentbyservice
    {
        public int Id { get; set; }
        public int ClientServiceId { get; set; }
        public string DocumentPath { get; set; }

        public virtual Clientservice ClientService { get; set; }
    }
}
