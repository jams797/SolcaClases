using ApiSolcaClase.Bll.Security;
using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Validator.Security;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSolcaClase.Controllers.Security
{
    [Route("api/Security/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        UserValidate UsVald;
        private readonly ISecurityBll SecBll;

        public LoginController(ISecurityBll securityBll)
        {
            UsVald = new UserValidate();
            SecBll = securityBll;
        }

       
        // POST api/<LoginController>
        [HttpPost]
        public ResponseModelGeneral Post([FromBody]LoginRequestModel LogReq)
        {
            try
            {
                ResponseModelGeneral ValidD = UsVald.Login(LogReq);
                if (ValidD.code != 200) return ValidD;


                return SecBll.Login(LogReq);
            } catch (Exception ex)
            {
                return new ResponseModelGeneral(500, MessageHelper.ErrorGeneral);
            }
        }

    
    }
}
