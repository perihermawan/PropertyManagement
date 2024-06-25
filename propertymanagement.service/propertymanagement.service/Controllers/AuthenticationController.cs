using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using propertymanagement.service.Commons;
using propertymanagement.service.Hubs;
using propertymanagement.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SPA.System.Web;
using propertymanagement.service.Controllers;
using SPA.System.Data;
using propertymanagement.service.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace propertymanagement.service.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IHubContext<MessageHub> messageHubContexts;
        private readonly IMemoryCache _cache;
        public AuthenticationController(IUnitOfWork unitOfWork, IMemoryCache cache, IHubContext<MessageHub> messageHubContext) : base(unitOfWork)
        {
            messageHubContexts = messageHubContext;
            _cache = cache;
        }

        [HttpGet("authenticates/{userid}/{password}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult Authenticates([FromRoute] string userid, string password)
        {
            int total = 0;
            //dataresult
            _cache.Remove("authorizations");
            try
            {
                var dataUser = IUnitOfWorks.UnitOfUserAppRepository().GetUserAppById(userid);
                if (dataUser == null)
                {
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.BadRequest, StatusMessage.Fail, "User Name or password does not found !", total);
                    return HttpResponse(HttpResults);
                }
                var usrPwd = Encryptspa.Common.Encrypt(dataUser.Result.Password);//SecurityHelper.DecryptString(dataUser.USERPPWD);
                if (usrPwd == password)
                {
                    var menuList = IUnitOfWorks.UnitOfMenuRepository().GetMenuList();
                    var permissionList = IUnitOfWorks.UnitOfMenuRepository().GetPermissionList(dataUser.Result.Id);
                    var token = JwtManager.GenerateToken(userid, new
                    {
                        FullName = dataUser.Result.UserName,
                        EmailUser =""
                    });

                    var dataresult = new
                    {
                        ID = dataUser.Result.Id,
                        TOKEN = token,
                        EMPLOYEEBASICINFOID = dataUser.Result.EMPLOYEEBASICINFOID,
                        FULL_NAME = dataUser.Result.FullName,
                        EMAIL = dataUser.Result.Email,
                        USERPPWD = dataUser.Result.Password,
                        PHONE = "",
                        DIVISIONID = "",
                        MENULIST = menuList.Result,
                        PERMISSIONLIST = permissionList.Result
                        //BusinessGroup = "WCS Jakarta",
                        //BusinessUnitDivisi = "System Analyst Developer",
                        //BusinessUnitDepartment = ""
                    };
                    HttpResults = new ResponseData<object>("Verified", SPA.System.Web.StatusCode.OK, StatusMessage.Success, dataresult);
                }
                else
                {
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.Unauthorized, StatusMessage.Fail, "User Name or password incorect !", total);
                    return HttpResponse(HttpResults);
                }
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
    }
}