using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MUsers
{
    public interface IUserRepository
    {
        public List<Users> GetListUsers();
        public Users? Login(string Username, string Pass);
        public bool ExistUserByEmailUser(string Email, string User);
        public bool RegisterUSer(Users UserM);
    }
}
