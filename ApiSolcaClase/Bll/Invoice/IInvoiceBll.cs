using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Invoice;

namespace ApiSolcaClase.Bll.Invoice
{
    public interface IInvoiceBll
    {
        public ResponseModelGeneral<object> CreatedInvoice(InvoiceRequestModel ReqModel, int IdUser);
    }
}
