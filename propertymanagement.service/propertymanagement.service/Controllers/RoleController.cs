using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using propertymanagement.service.Commons;
using propertymanagement.service.Hubs;
using propertymanagement.service.Models.Master;
using SPA.System.Data;
using SPA.System.Web;

namespace propertymanagement.service.Controllers
{
    public class RoleController : BaseController
    {
        #region Constructor
        public RoleController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Http Get
        // GET: api/GetUserAppAll
        [HttpGet("GetRoleAll")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRoleAll()
        {
            int total = 0;
            try
            {
                var listUserApp = IUnitOfWorks.UnitOfRoleRepository().GetRoleAll();
                HttpResults = new ResponseData<object>("GET ROLE ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUserApp);
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;
                if (exCode == -2147467259)
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, total);
                else
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, total);
            }
            return HttpResponse(HttpResults);
        }
        #endregion
    }
}
