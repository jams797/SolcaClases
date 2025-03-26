

using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MUsers
{
    public interface IUserRepository
    {
        public List<Userssys> GetListUsers();
        public Userssys? Login(string Username, string Pass);
        public bool ExistUserByEmailUser(string Email, string User);
        public bool RegisterUSer(Userssys UserM);
    }
}
