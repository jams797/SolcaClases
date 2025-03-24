using PruebaAplicativo.Models.DB;

namespace PruebaAplicativo
{
    public class PruebaAplicativoMethod : InterfacesModel
    {
        private readonly ModelContext DbContext;

        public PruebaAplicativoMethod(ModelContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public List<Users> GetUsers()
        {
            return DbContext.Users.ToList();
        }
    }
}
