

using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Repository.MUsers
{
    public interface IUserRepository
    {
        public Userssys FindUserExistById(int id);
        public List<Userssys> GetListUsers();
        public Userssys? Login(string Username, string Pass);
        public string NameUserById(int IdUSer);
        public bool ExistUserByEmailUser(string Email, string User);
        public bool RegisterUSer(Userssys UserM);
        public bool UpdateBalancePerson(int idUser, decimal NewBal);
    }
}
