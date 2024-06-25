using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using propertymanagement.service.Commons;
using propertymanagement.service.Hubs;
using SPA.System.Data;
using SPA.System.Web;

namespace propertymanagement.service.Controllers
{
    public class DropdownController : BaseController
    {
        private readonly IHubContext<MessageHub> messageHubContexts;
        public DropdownController(IUnitOfWork unitOfWork, IHubContext<MessageHub> messageHubContext) : base(unitOfWork)
        {
            messageHubContexts = messageHubContext;
        }

        [HttpGet("getddlchargecode")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        //public IActionResult GetDDLChargeCode()
        //{
        //    int total = 0;
        //    try
        //    {
        //        var dataUser = IUnitOfWorks.UnitOfDropdownRepository().GetChargeCode();
        //        HttpResults = new ResponseData<object>("Get DDL Charge Code", SPA.System.Web.StatusCode.OK, StatusMessage.Success, dataUser.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        int exCode = ex.HResult;
        //        if (exCode == -2147467259)
        //            HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, ex.Message, total);
        //        else
        //            HttpResults = new ResponseMessage(SPA.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, ex.Message, total);
        //    }
        //    return HttpResponse(HttpResults);
        //}

        [HttpGet("getddlemployee/{dateFrom}/{dateTo}/{timeFrom}/{timeTo}")]
        [ProducesResponseType(typeof(ResponseData<object>),200)]
        public IActionResult GetDDLEmployee(string dateFrom, string dateTo, string timeFrom, string timeTo)
        {
            int total = 0;
            try
            {
                var dataEmployees= IUnitOfWorks.UnitOfDropdownRepository().GetEmployee(dateFrom, dateTo, timeFrom, timeTo);
                HttpResults = new ResponseData<object>("Get DDL Employee", SPA.System.Web.StatusCode.OK, StatusMessage.Success, dataEmployees.Result);
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

        [HttpGet("getddlleaverequest")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDDLLeaveRequest()
        {
            int total = 0;
            try
            {
                var dataLeaveRequest = IUnitOfWorks.UnitOfDropdownRepository().GetDDLLeaveRequest();
                HttpResults = new ResponseData<object>("Get DDL LEave Request", SPA.System.Web.StatusCode.OK, StatusMessage.Success, dataLeaveRequest.Result);
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
        [HttpGet("getddlcompany")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDDLCompany()
        {
            int total = 0;
            try
            {
                var dataLeaveRequest = IUnitOfWorks.UnitOfDropdownRepository().GetDDLCompany();
                HttpResults = new ResponseData<object>("GetDDLCompany", SPA.System.Web.StatusCode.OK, StatusMessage.Success, dataLeaveRequest.Result);
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

        [HttpGet("getddlroles")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDDLRoles(string appName)
        {
            int total = 0;
            try
            {
                var dataLeaveRequest = IUnitOfWorks.UnitOfDropdownRepository().GetDDLRoles(appName);
                HttpResults = new ResponseData<object>("GetDDLRoles", SPA.System.Web.StatusCode.OK, StatusMessage.Success, dataLeaveRequest.Result);
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

        [HttpGet("getddlparam")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDDLParam([FromQuery] string paramCode)
        {
            int total = 0;
            try
            {
                var result = IUnitOfWorks.UnitOfDropdownRepository().GetDDLParam(paramCode);
                HttpResults = new ResponseData<object>("GetDDLParam", SPA.System.Web.StatusCode.OK, StatusMessage.Success, result.Result);
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