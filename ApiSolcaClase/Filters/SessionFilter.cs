using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiSolcaClase.Filters
{
    public class SessionFilter : IActionFilter
    {
        private readonly ILogger<SessionFilter> _logger;

        public SessionFilter(ILogger<SessionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var tmp1 = context.Result;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            SessionModel? SessionM = null;
            GeneratorJWTReponseModel? ResponseJwt = null;
            try
            {
                string Authorization = context.HttpContext.Request.Headers.Authorization.ToString();
                ResponseJwt = (new HelperGeneral()).ReadJwtSession(Authorization, out SessionM);
            }
            catch (Exception ex)
            {
                
            }
            if(SessionM == null)
            {
                context.Result = new OkObjectResult(new ResponseModelGeneral(
                    401,
                    MessageHelper.NotAuthorized,
                    null,
                    messageDev: (ResponseJwt != null) ? ResponseJwt.error : ""
                ));
            }
            //throw new NotImplementedException();
        }
    }
}
