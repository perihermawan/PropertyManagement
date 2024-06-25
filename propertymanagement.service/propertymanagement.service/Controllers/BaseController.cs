using System.Collections.Generic;
using SPA.System.Web;
using SPA.System.Data;
using Microsoft.AspNetCore.Mvc;
using propertymanagement.service.Commons;

namespace propertymanagement.service.Controllers
{
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseMessage), 500)]
    [ProducesResponseType(typeof(ResponseMessage), 400)]
    [ProducesResponseType(typeof(ResponseData<Dictionary<string, string>>), 422)]
    public class BaseController : Controller
    {
        protected HttpResult HttpResults;
        protected IUnitOfWork IUnitOfWorks;

        public BaseController() { }

        public BaseController(IUnitOfWork iUnitofWorks)
        {
            IUnitOfWorks = iUnitofWorks;
        }


        public ObjectResult HttpResponse(HttpResult result)
        {
            ObjectResult objectResult = new ObjectResult(result);
            objectResult.StatusCode = result.GetResponseStatusCode();
            objectResult.Value = result;
            return objectResult;
        }
        
        protected override void Dispose(bool disposing)
        {
            IUnitOfWorks.Dispose();
            base.Dispose(disposing);
        }
    }
}
