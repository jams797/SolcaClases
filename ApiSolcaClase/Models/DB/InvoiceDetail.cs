using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiSolcaClase.Models.DB
{
    public partial class InvoiceDetail
    {
        public decimal Idinvoicedetail { get; set; }
        public decimal Idproduct { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Idinvoice { get; set; }

        public virtual Invoice IdinvoicedetailNavigation { get; set; }
        public virtual Products IdproductNavigation { get; set; }
    }
}
