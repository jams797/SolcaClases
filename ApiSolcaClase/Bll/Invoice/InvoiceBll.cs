using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Invoice;
using ApiSolcaClase.Models.DB;
using ApiSolcaClase.Repository.MInvoice;
using ApiSolcaClase.Repository.MInvoiceDetail;
using ApiSolcaClase.Repository.MProduct;
using ApiSolcaClase.Repository.MUsers;

namespace ApiSolcaClase.Bll.Invoice
{
    public class InvoiceBll : IInvoiceBll
    {
        private readonly IProductRepository ProdRep;
        private readonly IUserRepository UsRep;
        private readonly IInvoiceRepository InvRep;
        private readonly IInvoiceDetailRepository InvDetRep;

        private readonly ModelContext db;
        public InvoiceBll(ModelContext db, IProductRepository ProdRep, IUserRepository UsRep, IInvoiceRepository InvRep, IInvoiceDetailRepository InvDetRep)
        {
            this.db = db;
            this.ProdRep = ProdRep;
            this.UsRep = UsRep;
            this.InvRep = InvRep;
            this.InvDetRep = InvDetRep;
        }
        public ResponseModelGeneral<object> CreatedInvoice(InvoiceRequestModel ReqModel, int IdUser)
        {
            db.Database.BeginTransaction();

            try
            {

                List<InvoiceDetail> ListInvoiceD = new List<InvoiceDetail>();

                Models.DB.Invoice InvModel = new Models.DB.Invoice();
                InvModel.Fecha = DateTime.Now;
                decimal? IdInvoice = InvRep.CreatedInvoice(InvModel);

                foreach (InvoiceRequestModelProduct Item in ReqModel.Products)
                {
                    Products? ExistProduct = ProdRep.GetProductById(Item.IdProduct);
                    if (ExistProduct == null) return new ResponseModelGeneral<object>(400, MessageHelper.ProductNotFound, db: db, ExecuteRollback: true);

                    if (ExistProduct.Qty < Item.Qty) return new ResponseModelGeneral<object>(400, MessageHelper.ProductOutRangeByQty, db: db, ExecuteRollback: true);

                    InvoiceDetail InvDetail = new InvoiceDetail();
                    InvDetail.Qty = Item.Qty;
                    InvDetail.Idproduct = Item.IdProduct;
                    InvDetail.Price = ExistProduct.Price;
                    InvDetail.Idinvoice = IdInvoice ?? 0;

                    ListInvoiceD.Add(InvDetail);
                }

                Userssys UserSes = UsRep.FindUserExistById(IdUser);

                decimal NewBal = UserSes.Balance - ListInvoiceD.Sum(x => x.Price * x.Qty);

                UsRep.UpdateBalancePerson(IdUser, NewBal);

                InvDetRep.CreatedListInvoiceDetail(ListInvoiceD);

                //
                //bool ExistListProd = ProdRep.VerifyProductsByListIds(ListIdsProd);
                //if (!ExistListProd) return new ResponseModelGeneral(400, MessageHelper.ProductNotFound);


                db.Database.CommitTransaction();


                return new ResponseModelGeneral<object>(200, "");
            } catch (Exception ex)
            {
                db.Database.RollbackTransaction();
                return new ResponseModelGeneral<object>(500, MessageHelper.ErrorGeneral);
            }
        }
    }
}
