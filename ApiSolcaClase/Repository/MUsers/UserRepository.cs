
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;
using ApiSolcaClase.Models.DB;

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
            return db.Userssys.Any(x => x.Username == User || x.Email == Email);
        }

        public List<Userssys> GetListUsers()
        {
            return db.Userssys.ToList();
        }

        public Userssys? Login(string Username, string Pass)
        {
            return db.Userssys.Where(x => x.Username == Username && x.Pass == Pass).ToList().FirstOrDefault();
            //return db.Query<Users>().AsNoTracking().FromSql("").FirstOrDefault();

            //    DbCommand cmd = db.Database.GetDbConnection().CreateCommand();

            //    cmd.CommandText = "Login";
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar) { Value = "Steve" });
            //    cmd.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar) { Value = "Smith" });

            //    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt) { Direction = ParameterDirection.Output });
        }

        public bool RegisterUSer(Userssys UserM)
        {
            try
            {
                //string StringSql = $"INSERT INTO USERSSYS (USERNAME,NAMEPERSON,PASS,EMAIL,IDROL) VALUES ('{UserM.Username}', '{UserM.Name}', '{UserM.Pass}', '{UserM.Email}', {UserM.Idrol})";
                db.Userssys.Add(UserM);
                //db.Database.ExecuteSqlCommand(StringSql);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {               
                return false;
            }
        }
    }
}
