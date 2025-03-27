using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Invoice;
using ApiSolcaClase.Models.DB;
using ApiSolcaClase.Repository.MProduct;

namespace ApiSolcaClase.Bll.Invoice
{
    public class InvoiceBll : IInvoiceBll
    {
        private readonly IProductRepository ProdRep;
        public InvoiceBll(IProductRepository ProdRep)
        {
            this.ProdRep = ProdRep;
        }
        public ResponseModelGeneral CreatedInvoice(InvoiceRequestModel ReqModel)
        {
            List<int> ListIdsProd = ReqModel.Products.Select(x => x.IdProduct).ToList();
            bool ExistListProd = ProdRep.VerifyProductsByListIds(ListIdsProd);
            if (!ExistListProd) return new ResponseModelGeneral(400, MessageHelper.ProductNotFound);

            return new ResponseModelGeneral(200, "");
        }
    }
}
