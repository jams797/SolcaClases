using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MInvoiceDetail
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly ModelContext db;

        public InvoiceDetailRepository(ModelContext db)
        {
            this.db = db;
        }
        public bool CreatedInvoiceDetail(InvoiceDetail InvDet)
        {
            try
            {
                db.InvoiceDetail.Add(InvDet);
                db.SaveChanges();
                return true;
            } catch ( Exception ex)
            {
                return false;
            }
        }

        public bool CreatedListInvoiceDetail(List<InvoiceDetail> ListInvDet)
        {
            try
            {
                db.InvoiceDetail.AddRange(ListInvDet);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
