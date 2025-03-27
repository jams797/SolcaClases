using ApiSolcaClase.Bll.Invoice;
using ApiSolcaClase.Filters;
using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Invoice;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSolcaClase.Controllers.Invoice
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SessionFilter))]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceBll InvBll;

        public InvoiceController(IInvoiceBll invBll)
        {
            InvBll = invBll;
        }


        // GET: api/<InvoiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public ResponseModelGeneral Post([FromBody] InvoiceRequestModel ReqModel)
        {
            try
            {
                string Authorization = HttpContext.Request.Headers["Authorization"].ToString();
                SessionModel? SessionM = null;
                GeneratorJWTReponseModel DatU = (new HelperGeneral()).ReadJwtSession(Authorization, out SessionM);

                return InvBll.CreatedInvoice(ReqModel, int.Parse(SessionM.Id));
            }
            catch (Exception ex)
            {
                return new ResponseModelGeneral(500, MessageHelper.ErrorGeneral, ex.StackTrace.ToString());
            }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
