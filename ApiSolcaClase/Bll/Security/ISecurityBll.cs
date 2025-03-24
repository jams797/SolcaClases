using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;

namespace ApiSolcaClase.Bll.Security
{
    public interface ISecurityBll
    {
        public ResponseModelGeneral Login(LoginRequestModel LogReqMod);
        public ResponseModelGeneral GetDataUser(int IdUser);
        public ResponseModelGeneral SaveUser(RegisterRequestModel ReqM);
        public ResponseModelGeneral UpdateNameUserFromId(int IdUSer, string Name);
    }
}
