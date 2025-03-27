using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MInvoice
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ModelContext db;

        public InvoiceRepository(ModelContext db)
        {
            this.db = db;
        }
        public decimal? CreatedInvoice(Invoice Inv)
        {
            try
            {
                db.Invoice.Add(Inv);
                db.SaveChanges();
                return Inv.Idfact;
            } catch ( Exception ex)
            {
                return null;
            }
        }
    }
}
