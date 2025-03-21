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
    public class RegisterController : ControllerBase
    {

        public static List<UserModelDB> ListUsers = new List<UserModelDB>()
        {
            new UserModelDB(
                id: 1,
                userName: "jmoran",
                passWord: "456578",
                name: "Jose",
                email: "jmoran@viamatica.com"
            ),
        };

        UserValidate UsVald;

        public RegisterController()
        {
            UsVald = new UserValidate();
        }

       
        // POST api/<LoginController>
        [HttpPost]
        public ResponseModelGeneral Post([FromBody]RegisterRequestModel ReqModel)
        {
            ResponseModelGeneral ValidD = UsVald.Register(ReqModel);
            if (ValidD.code != 200) return ValidD;


            return ValidD;
        }

    
    }
}
