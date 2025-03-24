using ApiSolcaClase.Models.DB;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiSolcaClase.Repository.MUsers
{
    public class UserRepository : IUserRepository
    {
        private readonly ModelContext db;
        public UserRepository(ModelContext dbModel)
        {
            db = dbModel;
        }

        public bool ExistUserByEmailUser(string Email, string User)
        {
            return db.Users.Any(x => x.Username == User || x.Email == Email);
        }

        public List<Users> GetListUsers()
        {
            return db.Users.ToList();
        }

        public Users? Login(string Username, string Pass)
        {
            return db.Users.Where(x => x.Username == Username && x.Pass == Pass).ToList().FirstOrDefault();
        }

        public bool RegisterUSer(Users UserM)
        {
            try
            {
                db.Users.Add(UserM);
                db.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
