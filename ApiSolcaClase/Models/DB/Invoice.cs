using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiSolcaClase.Models.DB
{
    public partial class Invoice
    {
        public decimal Idfact { get; set; }
        public DateTime Fecha { get; set; }

        public virtual InvoiceDetail InvoiceDetail { get; set; }
    }
}
