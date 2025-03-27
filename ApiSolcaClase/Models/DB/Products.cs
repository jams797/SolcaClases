using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiSolcaClase.Models.DB
{
    public partial class Products
    {
        public Products()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        public decimal Idproduct { get; set; }
        public string Nameproduct { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
