using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
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
    public class MarketingController : BaseController
    {
        #region Constructor
        public MarketingController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Rent Amount
        #region HTTP GET
        [HttpGet("GetRentAmountList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentAmountList()
        {
            int total = 0;
            try
            {
                var listRentAmount = IUnitOfWorks.UnitOfMarketingRepository().GetRentAmountList();
                HttpResults = new ResponseData<object>("GET RENT AMOUNT LIST ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRentAmount.Result);
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

        [HttpGet("GetRentAmountById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentAmountById(string rentId)
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentAmountDetail(rentId);
                HttpResults = new ResponseData<object>("GET RENT AMOUNT BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetDownPayment")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDownPayment()
        {
            int total = 0;
            try
            {
                var listDownPayment = IUnitOfWorks.UnitOfMarketingRepository().GetDownPaymentList();
                HttpResults = new ResponseData<object>("GET DOWN PAYMENT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listDownPayment.Result);
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

        #region Rent
        #region Http Get
        [HttpGet("GetRent")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRent()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentList();
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

        [HttpGet("GetRentPullOut")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentPullOut()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentPullOutList();
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
        #endregion
        #endregion


        [HttpGet("GetDataOutletType")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataOutletType()
        {

            int total = 0;
            try
            {
                var listOutletType = IUnitOfWorks.UnitOfMarketingRepository().GetDataOutletType();
                HttpResults = new ResponseData<object>("GET OUTLET TYPE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listOutletType.Result);
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

        #region Non Standard
        #region HTTP GET
        [HttpGet("GetNonStandardList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetNonStandardList()
        {
            int total = 0;
            try
            {
                var listNonStandard = IUnitOfWorks.UnitOfMarketingRepository().GetNonStandardList();
                HttpResults = new ResponseData<object>("GET NON STANDARD LIST ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listNonStandard.Result);
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
