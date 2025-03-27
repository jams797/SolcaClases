using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MProduct
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModelContext db;

        public ProductRepository(ModelContext db)
        {
            this.db = db;
        }

        public Products? GetProductById(int IdProduct)
        {
            return db.Products.Where(x => x.Idproduct == IdProduct).ToList().FirstOrDefault();
        }

        public bool VerifyProductsByListIds(List<int> Ids)
        {
            //var IdProdF = db.Products.Where(x => Ids.Contains(int.Parse(x.Idproduct.ToString()))).Select(x => x.Idproduct).ToList();
            var IdProdF = db.Products.Where(x => Ids.Any(y => y == int.Parse(x.Idproduct.ToString()))).Select(x => x.Idproduct).ToList();
            return IdProdF.Count() == Ids.Count();
        }
    }
}
