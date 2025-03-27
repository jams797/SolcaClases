using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Invoice;
using ApiSolcaClase.Models.AppModels.Security;

namespace ApiSolcaClase.Bll.Invoice
{
    public interface IInvoiceBll
    {
        public ResponseModelGeneral CreatedInvoice(InvoiceRequestModel ReqModel);
    }
}
