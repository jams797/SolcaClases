using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MProduct
{
    public interface IProductRepository
    {
        public Products? GetProductById(int IdProduct);

        public bool VerifyProductsByListIds(List<int> Ids);
    }
}
