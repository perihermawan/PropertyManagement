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
using propertymanagement.service.Models.DTO;
using propertymanagement.service.Models.ViewModel;
using SPA.System.Data;
using SPA.System.Web;
using Newtonsoft.Json;

namespace propertymanagement.service.Controllers
{
    public class MasterController : BaseController
    {
        #region Constructor
        public MasterController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Master Cbo
        #region Http Get
        [HttpGet("GetCboNameByCode/{code}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetCboNameByCode(string code)
        {

            int total = 0;
            try
            {
                var listCbo = IUnitOfWorks.UnitOfMasterRepository().GetMasterCBOByCode(code);
                HttpResults = new ResponseData<object>("GET MASTER CBO BY CODE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listCbo.Result);
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
        
        #region Master Unit
        #region Http Get
        // GET: api/GetUserAppAll
        [HttpGet("GetMasterUnit")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMasterUnit()
        {

            int total = 0;
            try
            {
                    var listUnit = IUnitOfWorks.UnitOfMasterRepository().GetMasterUnitList();
                HttpResults = new ResponseData<object>("GET MASTER UNIT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUnit.Result);
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

        [HttpGet("GetMasterUnitById/{unitId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMasterUnitById(string unitId)
        {

            int total = 0;
            try
            {
                var listUnit = IUnitOfWorks.UnitOfMasterRepository().GetMasterUnitDetail(unitId);
                HttpResults = new ResponseData<object>("GET MASTER UNIT BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUnit.Result);
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

        #region Http PUT
        [HttpPost("DeleteUnitByUnitId/{unitId}/{userId}")]
        [ProducesResponseType(typeof(ResponseData<UnitModel>), 200)]
        public IActionResult deleteunitbyunitid(Guid unitId, string userId,[FromBody]string reason)
        {
            int total = 0;
            try
            {
                // var userId = DbContextExtension.GetUserId(HttpContext);
                var Result = IUnitOfWorks.UnitOfMasterRepository().DeleteUnitByUnitId(unitId, userId, reason);
                var resultData = Result.Result;
                if (resultData[0].STATUS.ToLower() == "success")
                    HttpResults = new ResponseData<object>("Delete master unit data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, unitId);
                else
                    HttpResults = new ResponseData<object>(resultData[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, unitId);
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

        #region Master Employee

        #region Http Get
        // GET: api/GetUserAppAll
        [HttpGet("GetMasterEmployee")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMasterEmployee()
        {

            int total = 0;
            try
            {
                var listUnit = IUnitOfWorks.UnitOfMasterRepository().GetMasterEmployeeList();
                HttpResults = new ResponseData<object>("GET MASTER UNIT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUnit.Result);
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

        [HttpGet("GetEmployeeById/{employeeid}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetEmployeeById(int employeeid)
        {

            int total = 0;
            try
            {
                var listUnit = IUnitOfWorks.UnitOfMasterRepository().GetMasterEmployeeById(employeeid);
                HttpResults = new ResponseData<object>("GET MASTER UNIT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUnit.Result);
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

        [HttpPost("DeleteEmployeeById/{employeeid}/{user}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult DeleteEmployeeById(int employeeid, string user)
        {

            int total = 0;
            try
            {
                var listUnit = IUnitOfWorks.UnitOfMasterRepository().DeleteEmployeeById(employeeid, user);
                HttpResults = new ResponseData<object>("DELETE EMPLOYEE DATA ", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUnit.Result);
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

        #region Master Building
        #region Http Get
        // GET: api/GetUserAppAll
        [HttpGet("GetBuilding")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetBuilding()
        {

            int total = 0;
            try
            {
                var listData = IUnitOfWorks.UnitOfMasterRepository().GetBuilding();
                HttpResults = new ResponseData<object>("GET BUILDING ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listData.Result);
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

        #region Master Outlet
        [HttpGet("GetMasterOutlet")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMasterOutlet()
        {

            int total = 0;
            try
            {
                var listUnit = IUnitOfWorks.UnitOfMasterRepository().GetMasterOutletList();
                HttpResults = new ResponseData<object>("GET MASTER OUTLET ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listUnit.Result);
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

        #region Master PrmOthers
        #region Http Get
        // GET: api/GetUserAppAll
        [HttpGet("GetPrmOthers/{paramCode}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetPrmOthers(string paramCode)
        {

            int total = 0;
            try
            {
                var listData = IUnitOfWorks.UnitOfMasterRepository().GetPrmOthers(paramCode);
                HttpResults = new ResponseData<object>("GET PARAM ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listData.Result);
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

        #region Master Tenant Owner
        #region Http Get
        [HttpGet("GetTenantOwner")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetTenantOwner([FromQuery] string type, [FromQuery] Guid tenantOwnerId)
        {
            int total = 0;
            try
            {
                var listTenantOwner = IUnitOfWorks.UnitOfMasterRepository().GetTenantOwnerList(type ?? string.Empty, tenantOwnerId);
                HttpResults = new ResponseData<object>("GetTenantOwner ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listTenantOwner.Result);
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

        [HttpGet("GetTenantOwnerInvoiceTo")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetTenantOwnerInvoiceTo([FromQuery] Guid tenantOwnerId)
        {
            int total = 0;
            try
            {
                var result = IUnitOfWorks.UnitOfMasterRepository().GetTenantOwnerInvoiceTo(tenantOwnerId);
                HttpResults = new ResponseData<object>("GetTenantOwnerInvoiceTo By Id", SPA.System.Web.StatusCode.OK, StatusMessage.Success, result.Result);
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

        [HttpGet("GetTenantOwnerPIC")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetTenantOwnerPIC([FromQuery] Guid tenantOwnerId)
        {
            int total = 0;
            try
            {
                var result = IUnitOfWorks.UnitOfMasterRepository().GetTenantOwnerPersonInCharge(tenantOwnerId);
                HttpResults = new ResponseData<object>("GetTenantOwnerPIC By Id", SPA.System.Web.StatusCode.OK, StatusMessage.Success, result.Result);
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

        [HttpGet("GetTenantOwnerCor")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetTenantOwnerCor([FromQuery] Guid tenantOwnerId)
        {
            int total = 0;
            try
            {
                var result = IUnitOfWorks.UnitOfMasterRepository().GetTenantOwnerCorrespondence(tenantOwnerId);
                HttpResults = new ResponseData<object>("GetTenantOwnerCor By Id", SPA.System.Web.StatusCode.OK, StatusMessage.Success, result.Result);
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

        [HttpGet("GetOutletByOutletId/{outletid}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetOutletByOutletId(Guid outletid)
        {

            int total = 0;
            try
            {
                var Data = IUnitOfWorks.UnitOfMasterRepository().GetMasterOutletByOutletId(outletid);
                HttpResults = new ResponseData<object>("GET MASTER OUTLET DETAIL ", SPA.System.Web.StatusCode.OK, StatusMessage.Success, Data.Result);
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
