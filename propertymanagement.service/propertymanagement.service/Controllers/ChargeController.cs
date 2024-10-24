using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using propertymanagement.service.Commons;
using propertymanagement.service.Models.Marketing;
using SPA.System.Data;
using SPA.System.Web;

namespace propertymanagement.service.Controllers
{
    public class ChargeController : BaseController
    {
        #region Constructor
        public ChargeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Standard Charge

        #region HTTP GET
        [HttpGet("GetStandardChargeList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetStandardChargeList([FromQuery] string colName, string operatorQuery, string searchQuery, string mode)
        {
            int total = 0;
            try
            {
                var listStandardCharge = IUnitOfWorks.UnitOfChargeRepository().GetStandardChargeList(colName, operatorQuery, searchQuery, mode);
                HttpResults = new ResponseData<object>("GetStandardChargeList", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listStandardCharge.Result);
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

        [HttpGet("GetRentStandard")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentStandard()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfChargeRepository().GetRentStandard();
                HttpResults = new ResponseData<object>("GET RENT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetstandardItemById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetstandardItemById(string rentId)
        {
            int total = 0;
            try
            {
                var listItems = IUnitOfWorks.UnitOfChargeRepository().GetStandardItemById(rentId);
                HttpResults = new ResponseData<object>("GET  STANDARD ITEM ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listItems.Result);
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

        #region Non Standard Charge

        #region HTTP GET
        [HttpGet("GetNonStandardChargeList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetNonStandardChargeList([FromQuery] string colName, string operatorQuery, string searchQuery, string mode)
        {
            int total = 0;
            try
            {
                var listStandardCharge = IUnitOfWorks.UnitOfChargeRepository().GetNonStandardChargeList(colName, operatorQuery, searchQuery, mode);
                HttpResults = new ResponseData<object>("GetNonStandardChargeList", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listStandardCharge.Result);
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

        [HttpGet("GetRentNonStandard")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentNonStandard()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfChargeRepository().GetRentNonStandard();
                HttpResults = new ResponseData<object>("GET RENT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetNonstandardItemById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetNonstandardItemById(string rentId)
        {
            int total = 0;
            try
            {
                var listItems = IUnitOfWorks.UnitOfChargeRepository().GetNonStandardItemById(rentId);
                HttpResults = new ResponseData<object>("GET NON STANDARD ITEM ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listItems.Result);
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
