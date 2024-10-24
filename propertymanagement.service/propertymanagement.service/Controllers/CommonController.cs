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
    public class CommonController : BaseController
    {
        #region Constructor
        public CommonController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
        #region Http Post
        [HttpPost("ExecuteSP/{spName}/{userId}")]
        [ProducesResponseType(typeof(ResponseData<UnitModel>), 200)]
        public IActionResult ExecuteSP(string spName, string userId, [FromBody] string model)
        {
            int total = 0;
            try
            {
                // var userId = DbContextExtension.GetUserId(HttpContext);
                if (spName == "sp_ins_JsonMsUser" || spName == "sp_ins_JsonMsEmployee")
                {
                    dynamic validatedata = null;
                    string msg = "";
                    if (spName == "sp_ins_JsonMsUser")
                    {
                        UserManagement obj = JsonConvert.DeserializeObject<UserManagement>(model);
                        validatedata = IUnitOfWorks.UnitOfUserManagementRepository().ValidateUserByUserName(obj.UserName);
                        msg = "Username already exists";
                    }
                    if (spName == "sp_ins_JsonMsEmployee")
                    {
                        EmployeeModel obj = JsonConvert.DeserializeObject<EmployeeModel>(model);
                        validatedata = IUnitOfWorks.UnitOfMasterRepository().ValidateEmployeeByEmployeeNo(obj.EmployeeNo);
                        msg = "Employee Number already exists";
                    }

                    if (validatedata.Result == null)
                    {
                        //if (validatedata.Result.UserName == "")
                        //{
                            var hasil = IUnitOfWorks.UnitOfCommonRepository().ExecuteSP(spName, model, userId);
                            var resultData = hasil.Result;
                            if (resultData[0].STATUS.ToLower() == "success")
                                HttpResults = new ResponseData<object>("Execute Data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, model);
                            else
                                HttpResults = new ResponseData<object>(hasil.Result[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, model);
                        }
                        else
                        {
                            HttpResults = new ResponseData<object>(msg, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, model);
                        }
                    //}
                    

                }
                else
                {
                    var hasil = IUnitOfWorks.UnitOfCommonRepository().ExecuteSP(spName, model, userId);
                    var resultData = hasil.Result;
                    if (resultData[0].STATUS.ToLower() == "success")
                        HttpResults = new ResponseData<object>("Execute Data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, model);
                    else
                        HttpResults = new ResponseData<object>(hasil.Result[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, model);
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
        #endregion

        [HttpPost("ExecuteSP/{spName}")]
        [ProducesResponseType(typeof(ResponseData<UnitModel>), 200)]
        public IActionResult ExecuteSP(string spName, [FromBody] string model)
        {
            int total = 0;
            try
            {
                var hasil = IUnitOfWorks.UnitOfCommonRepository().ExecuteSP(spName, model);
                var resultData = hasil.Result;
                if (resultData[0].STATUS.ToLower() == "success")
                    HttpResults = new ResponseData<object>("Execute Data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, model);
                else
                    HttpResults = new ResponseData<object>(hasil.Result[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, model);

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


        #region Http Put
        [HttpPut("ExecuteSPEdit/{spName}/{userId}")]
        [ProducesResponseType(typeof(ResponseData<UnitModel>), 200)]
        public IActionResult ExecuteSPEdit(string spName, string userId, [FromBody] string model)
        {
            int total = 0;
            try
            {
                // var userId = DbContextExtension.GetUserId(HttpContext);
                var Result = IUnitOfWorks.UnitOfCommonRepository().ExecuteSP(spName, model, userId);
                var resultData = Result.Result;
                if (resultData[0].STATUS.ToLower() == "success")
                    HttpResults = new ResponseData<object>("Update master unit data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, model);
                else
                    HttpResults = new ResponseData<object>(Result.Result[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, model);
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

        [HttpPost("ExecuteSPDelete/{spname}/{id}/{user}")]
        [ProducesResponseType(typeof(ResponseData<Object>), 200)]
        public IActionResult ExecuteSPDelete(string spname, string id, string user)
        {
            int total = 0;
            try
            {
                // var userId = DbContextExtension.GetUserId(HttpContext);
                var Result = IUnitOfWorks.UnitOfCommonRepository().ExecuteSPDelete(spname, id, user);
                var resultData = Result.Result;
                if (resultData[0].STATUS.ToLower() == "success")
                    HttpResults = new ResponseData<object>("Delete data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, id);
                else
                    HttpResults = new ResponseData<object>(Result.Result[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, id);
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
