using ApiSolcaClase.Controllers.Security;
using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;

namespace ApiSolcaClase.Bll.Security
{
    public class SecurityBll
    {
        public ResponseModelGeneral Login(LoginRequestModel LogReqMod)
        {
            UserModelDB? UserDB = RegisterController.ListUsers.FirstOrDefault(x => x.UserName == LogReqMod.User && x.PassWord == LogReqMod.Pass);

            if(UserDB != null)
            {
                SessionModel SessionM = new SessionModel(
                    id: UserDB.Id.ToString(),
                    userName: UserDB.UserName
                );
                string Token = (new HelperGeneral()).GenerateJwtSession(SessionM);
                return new ResponseModelGeneral(200, "", new LoginResponseModel(
                    id: UserDB.Id,
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
            bool ExistUser = RegisterController.ListUsers.Exists(x => x.UserName == ReqM.User || x.Email == ReqM.Email);

            if (ExistUser) return new ResponseModelGeneral(500, MessageHelper.UserExistAndNotCreated);

            int IdUserNew = (RegisterController.ListUsers.Count() == 0 ? 0 : RegisterController.ListUsers.Max(x => x.Id)) + 1;

            UserModelDB UserDB = new UserModelDB(
                id: IdUserNew,
                userName: ReqM.User,
                passWord: ReqM.Pass,
                name: ReqM.Name,
                email: ReqM.Email
            );

            RegisterController.ListUsers.Add(UserDB);

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
