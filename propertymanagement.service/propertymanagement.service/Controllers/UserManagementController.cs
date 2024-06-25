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
using propertymanagement.service.Models.ViewModel;
using SPA.System.Data;
using SPA.System.Web;

namespace propertymanagement.service.Controllers
{
    public class UserManagementController : BaseController
    {
        #region Constructor
        public UserManagementController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Http Get
        // GET: api/GetUserAppAll
        #region Menu
        [HttpGet("GetAllMenu")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetAllMenu()
        {
            int total = 0;
            try
            {
                var listMenu = IUnitOfWorks.UnitOfMenuRepository().GetMenuList();
                HttpResults = new ResponseData<object>("GET ALL MENU", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listMenu.Result);
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

        #region User
        [HttpGet("GetAllUser")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetAllUser()
        {
            int total = 0;
            try
            {
                var listUser = IUnitOfWorks.UnitOfUserManagementRepository().GetUserList();
                HttpResults = new ResponseData<object>("GET ALL USER", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUser.Result);
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

        #region Employee
        [HttpGet("GetAllEmployee")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetAllEmployee()
        {
            int total = 0;
            try
            {
                var listEmployee = IUnitOfWorks.UnitOfUserManagementRepository().GetEmployeeList();
                HttpResults = new ResponseData<object>("GET ALL Employee", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listEmployee.Result);
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


        #endregion
    }
}
