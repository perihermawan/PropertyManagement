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
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserAppController : BaseController
    {
        #region Constructor
        public UserAppController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Http Get
        // GET: api/GetUserAppAll
        [HttpGet("GetUserAppAll")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetUserAppAll()
        {
            int total = 0;
            try
            {
                var listUserApp = IUnitOfWorks.UnitOfUserAppRepository().GetUserAppAll();
                HttpResults = new ResponseData<object>("GET USER APP ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUserApp);
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

        [HttpGet("GetUserAccessAll/{userid}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetUserAccessAll(string userid)
        {
            int total = 0;
            try
            {
                var listUserApp = IUnitOfWorks.UnitOfUserAccessRepository().GetUserAccessAll(userid);
                HttpResults = new ResponseData<object>("GET USER ACCESS ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUserApp.Result);
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

        //GET: api/GetUserAppById
        [HttpGet("GetUserAppById/{id}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetByIdAllEmployeeAccount(string id)
        {
            int total = 0;
            try
            {
                var listEmployeeAccount = IUnitOfWorks.UnitOfUserAppRepository().GetUserAppById(id);
                HttpResults = new ResponseData<object>("GET USER APP BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listEmployeeAccount);
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

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(string id)
        {
            int total = 0;
            try
            {
                var listEmployeeAccount = IUnitOfWorks.UnitOfUserAppRepository().GetUserById(id);
                HttpResults = new ResponseData<object>("GET USER BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listEmployeeAccount.Result);
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

        [HttpPost("AddUser")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult Create([FromBody]UserAppModel model)
        {
            try
            {
                if (model == null)
                {
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.BadRequest, StatusMessage.Fail, "No Data Inserted !", 0);
                    return HttpResponse(HttpResults);
                }
                else
                {
                    var data = IUnitOfWorks.UnitOfUserAppRepository().SaveUser(model);
                    HttpResults = new ResponseData<UserAppModel>("Success Add User", SPA.System.Web.StatusCode.OK, StatusMessage.Success, model, 0, 0);
                    //_hubContext.Clients.All.SendAsync("ReceiveMessage", "authorss", "msg");
                }
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;
                if (exCode == -2147467259)
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, 0);
                else
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, 0);
            }
            return HttpResponse(HttpResults);
        }

        [HttpPut("EditUser")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult EditUser([FromBody]UserAppModel model)
        {
            try
            {
                if (model == null)
                {
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.BadRequest, StatusMessage.Fail, "No Data Edited !", 0);
                    return HttpResponse(HttpResults);
                }
                else
                {
                    var data = IUnitOfWorks.UnitOfUserAppRepository().EditUser(model);
                    HttpResults = new ResponseData<object>("Success Edit User", SPA.System.Web.StatusCode.OK, StatusMessage.Success, data, 0, 0);
                }
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;
                if (exCode == -2147467259)
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, 0);
                else
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, 0);
            }
            return HttpResponse(HttpResults);
        }

        [HttpPost("EditPassword")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult EditPassword([FromBody] EditPasswordModel model)
        {
            try
            {
                if (model == null)
                {
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.BadRequest, StatusMessage.Fail, "No Data Edited !", 0);
                    return HttpResponse(HttpResults);
                }
                else
                {
                    var Result = IUnitOfWorks.UnitOfUserAppRepository().EditPassword(model);
                    var resultData = Result.Result;
                    if (resultData[0].STATUS.ToLower() == "success")
                        HttpResults = new ResponseData<object>("Execute Data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, model);
                    else
                        HttpResults = new ResponseData<object>(Result.Result[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, model);
                }
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;
                if (exCode == -2147467259)
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, 0);
                else
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, 0);
            }
            return HttpResponse(HttpResults);
        }

        [HttpDelete("DeleteUser/{id}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.BadRequest, StatusMessage.Fail, "No Data Edited !", 0);
                    return HttpResponse(HttpResults);
                }
                else
                {
                    var data = IUnitOfWorks.UnitOfUserAppRepository().DeleteUser(id);
                    HttpResults = new ResponseData<object>("Succee Delete User", SPA.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
            }
            catch (Exception ex)
            {
                int exCode = ex.HResult;
                if (exCode == -2147467259)
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, 0);
                else
                    HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, 0);
            }
            return HttpResponse(HttpResults);
        }
        #endregion

    }
}


