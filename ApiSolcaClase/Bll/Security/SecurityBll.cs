using ApiSolcaClase.Controllers.Security;
using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Models.DB;
using ApiSolcaClase.Repository.MUsers;

namespace ApiSolcaClase.Bll.Security
{
    public class SecurityBll : ISecurityBll
    {
        public readonly IUserRepository UserRep;

        public SecurityBll(IUserRepository userRep)
        {
            UserRep = userRep;
        }

        public ResponseModelGeneral Login(LoginRequestModel LogReqMod)
        {
            string PasswordEncr = (new HelperGeneral()).EncryptPassWord(LogReqMod.Pass);

            Users? UserDB = UserRep.Login(LogReqMod.User, PasswordEncr);

            if(UserDB != null)
            {
                SessionModel SessionM = new SessionModel(
                    id: UserDB.Id.ToString(),
                    userName: UserDB.Username
                );
                string Token = (new HelperGeneral()).GenerateJwtSession(SessionM);
                return new ResponseModelGeneral(200, "", new LoginResponseModel(
                    id: int.Parse(UserDB.Id.ToString()),
                    name: UserDB.Name,
                    token: Token
                ));
            }

            return new ResponseModelGeneral(500, MessageHelper.AuthenticationFailed);

        }

        public ResponseModelGeneral GetDataUser(int IdUser)
        {
            UserModelDB? UserDB = RegisterController.ListUsers.FirstOrDefault(x => x.Id == IdUser);

            if (UserDB != null)
            {
                GetDataUserResponseModel DataU = new GetDataUserResponseModel(
                    name: UserDB.Name,
                    email: UserDB.Email
                );
                return new ResponseModelGeneral(200, "", DataU);
            }

            return new ResponseModelGeneral(500, MessageHelper.ErrorGeneral);
        }

        public ResponseModelGeneral SaveUser(RegisterRequestModel ReqM)
        {
            bool ExistUser = UserRep.ExistUserByEmailUser(ReqM.Email, ReqM.User);

            if (ExistUser) return new ResponseModelGeneral(500, MessageHelper.UserExistAndNotCreated);

            Users UserDB = new Users();

            string? PasswordEncr = (new HelperGeneral()).EncryptPassWord(ReqM.Pass);

            UserDB.Username = ReqM.User;
            UserDB.Name = ReqM.Name;
            UserDB.Pass = PasswordEncr;
            UserDB.Email = ReqM.Email;

            bool CreatedUser = UserRep.RegisterUSer(UserDB);

            if(!CreatedUser)
            {
                return new ResponseModelGeneral(500, MessageHelper.UserErrorCreated);
            }

            return new ResponseModelGeneral(200, MessageHelper.UserCreated);
        }

        public ResponseModelGeneral UpdateNameUserFromId(int IdUSer, string Name)
        {
            UserModelDB UserDB = RegisterController.ListUsers.First(x => x.Id == IdUSer);

            UserDB.Name = Name;

            return new ResponseModelGeneral(200, MessageHelper.UserUpdateName);
        }
    }
}
