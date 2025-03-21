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
                    id: UserDB.Id,
                    userName: UserDB.UserName
                );
                string Token = (new HelperGeneral()).GenerateJwt(SessionM);
                return new ResponseModelGeneral(200, "", new LoginResponseModel(
                    id: UserDB.Id,
                    name: UserDB.Name,
                    token: Token
                ));
            }

            return new ResponseModelGeneral(500, MessageHelper.AuthenticationFailed);

        }
    }
}
