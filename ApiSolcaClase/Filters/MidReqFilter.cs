using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace ApiSolcaClase.Filters
{
    public class MidReqFilter : IActionFilter
    {
        private readonly ILogger<SessionFilter> _logger;

        public MidReqFilter(ILogger<SessionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var tmp1 = context.Result;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            MongoHelper MongH = new MongoHelper();
            Helpers.Models.MongoModels.LogProcesMongoModel ModelProc = new Helpers.Models.MongoModels.LogProcesMongoModel();

            context.HttpContext.Request.EnableBuffering();

            using (var reader = new StreamReader(
                context.HttpContext.Request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true
                ))
            {
                ModelProc.Message = "Request Petición";
                //MongH.InsertLogProc(ModelProc, reader);
                ModelProc.DataReq = reader.ReadToEndAsync().Result;
                context.HttpContext.Request.Body.Position = 0;
                MongH.InsertLogProc(ModelProc);
            }
        }
    }
}
