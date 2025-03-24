using ApiSolcaClase.Bll.Security;
using ApiSolcaClase.Filters;
using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Validator.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSolcaClase.Controllers.Security
{
    [Route("api/Security/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(SessionFilter))]
    public class DataUserController : ControllerBase
    {
        private readonly ISecurityBll SecBll;
        private UserValidate UsVald;

        public DataUserController(ISecurityBll SecBll)
        {
            this.SecBll = SecBll;
            UsVald = new UserValidate();
        }

        // GET: api/<DataUserController>
        [HttpGet]
        public ResponseModelGeneral Get()
        {
            try {
                string Authorization = HttpContext.Request.Headers["Authorization"].ToString();
                SessionModel? SessionM = null;
                GeneratorJWTReponseModel DatU = (new HelperGeneral()).ReadJwtSession(Authorization, out SessionM);

                return SecBll.GetDataUser(int.Parse(SessionM.Id));
            }
            catch (Exception ex)
            {
                return new ResponseModelGeneral(500, MessageHelper.ErrorGeneral);
            }
        }

        // GET api/<DataUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataUserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataUserController>/5
        [HttpPut("{id}/{name}")]
        public string Put(int id, string name, [FromBody] UpdateNameFromUserModelRequest ReqModel)
        {
            return "Name: " + name + " Id: " + id + " NameP: " + ReqModel.Name;
        }

        [HttpPut]
        public ResponseModelGeneral Put([FromBody] UpdateNameFromUserModelRequest ReqModel)
        {
            try
            {
                string Authorization = HttpContext.Request.Headers["Authorization"].ToString();
                SessionModel? SessionM = null;
                GeneratorJWTReponseModel DatU = (new HelperGeneral()).ReadJwtSession(Authorization, out SessionM);

                ResponseModelGeneral ValidD = UsVald.UpdateNameUSer(ReqModel);
                if (ValidD.code != 200) return ValidD;

                return SecBll.UpdateNameUserFromId(int.Parse(SessionM.Id), ReqModel.Name);
            }
            catch (Exception ex)
            {
                return new ResponseModelGeneral(500, MessageHelper.ErrorGeneral);
            }
        }

        // DELETE api/<DataUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
