using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;

namespace ApiSolcaClase.Bll.Security
{
    public interface ISecurityBll
    {
        public Task<ResponseModelGeneral<LoginResponseModel>> Login(LoginRequestModel LogReqMod);
        public ResponseModelGeneral<GetDataUserResponseModel> GetDataUser(int IdUser);
        public ResponseModelGeneral<object> SaveUser(RegisterRequestModel ReqM);
        public ResponseModelGeneral<object> UpdateNameUserFromId(int IdUSer, string Name);
    }
}
