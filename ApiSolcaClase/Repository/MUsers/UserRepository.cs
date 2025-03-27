
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;
using ApiSolcaClase.Models.DB;
using Oracle.ManagedDataAccess.Client;

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

            //DbCommand cmd = db.Database.GetDbConnection().CreateCommand();

            //cmd.CommandText = "Login";
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add(new OracleParameter("@firstName", SqlDbType.VarChar) { Value = "Steve" });
            //cmd.Parameters.Add(new OracleParameter("@lastName", SqlDbType.VarChar) { Value = "Smith" });

            //cmd.Parameters.Add(new OracleParameter("@id", SqlDbType.BigInt) { Direction = ParameterDirection.Output });

            //cmd.ExecuteNonQuery();
        }

        public string NameUserById(int IdUSer)
        {
            string NameUSer = "";
            DbCommand cmd = db.Database.GetDbConnection().CreateCommand();

            cmd.CommandText = "GETNAMEUSER";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("@P_IDUSER", OracleDbType.Int32) { Value = IdUSer });

            OracleParameter NameUserParams = new OracleParameter("@P_NAMEUSER", OracleDbType.Varchar2, 255) { Direction = ParameterDirection.Output, Value= DBNull.Value };
            cmd.Parameters.Add(NameUserParams);

            (new ADORepository()).UtilADO(ref cmd);

            NameUSer = NameUserParams.Value.ToString();

            return NameUSer;
        }

        public bool RegisterUSer(Userssys UserM)
        {
            try
            {
                //string StringSql = $"INSERT INTO USERSSYS (USERNAME,NAMEPERSON,PASS,EMAIL,IDROL) VALUES ('{UserM.Username}', '{UserM.Nameperson}', '{UserM.Pass}', '{UserM.Email}', {UserM.Idrol})";
                //string StringSql = $"INSERT INTO USERSSYS (USERNAME,NAMEPERSON,PASS,EMAIL,IDROL) VALUES (:userName, :namePerson, :pass, :email, :idRol)";
                db.Userssys.Add(UserM);
                //db.Database.ExecuteSqlRaw(StringSql);
                //OracleParameter[] parameters = new[] {
                //    new OracleParameter(":userName", UserM.Username),
                //    new OracleParameter(":namePerson", UserM.Nameperson),
                //    new OracleParameter(":pass", UserM.Pass),
                //    new OracleParameter(":email", UserM.Email),
                //    new OracleParameter(":idRol", UserM.Idrol)
                //};
                //db.Database.ExecuteSqlRaw(StringSql, parameters);
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
