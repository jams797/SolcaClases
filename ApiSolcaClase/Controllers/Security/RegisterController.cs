using ApiSolcaClase.Bll.Security;
using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Validator.Security;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSolcaClase.Controllers.Security
{

    [Route("api/Security/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly ISecurityBll SecBll;

        public static List<UserModelDB> ListUsers = new List<UserModelDB>()
        {
            new UserModelDB(
                id: 1,
                userName: "jmoran",
                passWord: "456578",
                name: "Jose",
                email: "jmoran@viamatica.com"
            ),
            new UserModelDB(
                id: 2,
                userName: "pepe",
                passWord: "1234",
                name: "Pepe",
                email: "pepe@viamatica.com"
            ),
        };

        UserValidate UsVald;

        public RegisterController(ISecurityBll SecBll)
        {
            UsVald = new UserValidate();
            this.SecBll = SecBll;
        }

       
        // POST api/<LoginController>
        [HttpPost]
        public ResponseModelGeneral Post([FromBody]RegisterRequestModel ReqModel)
        {
            try
            {
                ResponseModelGeneral ValidD = UsVald.Register(ReqModel);
                if (ValidD.code != 200) return ValidD;

                return SecBll.SaveUser(ReqModel);
            }
            catch (Exception ex)
            {
                return new ResponseModelGeneral(500, MessageHelper.ErrorGeneral);
            }
        }

    
    }
}
