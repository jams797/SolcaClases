using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MInvoice
{
    public interface IInvoiceRepository
    {
        public decimal? CreatedInvoice(Invoice Inv);
    }
}
