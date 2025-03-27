using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MInvoiceDetail
{
    public interface IInvoiceDetailRepository
    {
        public bool CreatedInvoiceDetail(InvoiceDetail InvDet);
        public bool CreatedListInvoiceDetail(List<InvoiceDetail> ListInvDet);
    }
}
