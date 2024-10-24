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
using AutoMapper.Execution;
using System.Drawing;
using System.Diagnostics;
using Newtonsoft.Json;

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
        [HttpGet("GetRentRentAmount")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentRentAmount()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentRentAmountList();
                HttpResults = new ResponseData<object>("GET RENT ALL FOR RENT AMOUNT", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetRentAmountItemsById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentAmountItemsById(string rentId)
        {
            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentAmountItems(rentId);
                HttpResults = new ResponseData<object>("GET RENT AMOUNT ITEMS BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetDownPaymentListById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDownPaymentListById(string rentId)
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetDpItems(rentId);
                HttpResults = new ResponseData<object>("GET DP LIST BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetRentDetail/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentDetail(string rentId)
        {
            int total = 0;
            try
            {
                var listRentAmount = IUnitOfWorks.UnitOfMarketingRepository().GetRentDetail(rentId);
                HttpResults = new ResponseData<object>("GET RENT DETAIL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRentAmount.Result);
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
        [HttpGet("GetRentList")]
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

        [HttpGet("GetRentById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentById(Guid rentId)
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentById(rentId);
                HttpResults = new ResponseData<object>("GET RENT BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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
        
        [HttpGet("GetRentDById/{rentId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentDById(Guid rentId)
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentDById(rentId);
                HttpResults = new ResponseData<object>("GET RENT D BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetTelpByUnitId/{UnitId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetTelpByUnitId(Guid rentId)
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetRentDById(rentId);
                HttpResults = new ResponseData<object>("GET RENT D BY ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetDataChargeTypeAll")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataChargeTypeAll()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetChargeTypeList();
                HttpResults = new ResponseData<object>("GET CHANGE TYPE ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetOutletList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetOutletList()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetOutletList();
                HttpResults = new ResponseData<object>("GET OUTLET ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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
        
        [HttpGet("GetGroupList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetGroupList()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetGroupList();
                HttpResults = new ResponseData<object>("GET GROUP ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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
        
        [HttpGet("GetNextKsmPsm")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetNextKsmPsm()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetNextKsmPsm();
                HttpResults = new ResponseData<object>("GET NEXT KSM PSM", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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
        
        [HttpPost("ValidateCreate")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult ValidateCreate([FromBody] string model)
        {
            // get data from form

            int total = 0;
            try
            {
                // convert model string json to object
                var modelObj = JsonConvert.DeserializeObject<KsmPsmModel>(model);
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().ValidateCreate(modelObj.KSMNumber, modelObj.PSMNumber);
                HttpResults = new ResponseData<object>("GET VALIDATE CREATE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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
        
        [HttpGet("GetDataDueDate")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataDueDate()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetDueDate();
                HttpResults = new ResponseData<object>("GET DUE DATE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        [HttpGet("GetDataUnitList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataUnitList(string mapNumber, string floor, string block, string number, string statusDesc)
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetDataUnitList(mapNumber, floor, block, number, statusDesc);
                HttpResults = new ResponseData<object>("GET UNIT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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

        #region Deposit

        #region Http Get
        [HttpGet("GetAllDeposit")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetAllDeposit()
        {
            int total = 0;
            try
            {
                var listDeposit = IUnitOfWorks.UnitOfMarketingRepository().GetDepositList();
                HttpResults = new ResponseData<object>("GetDeposit ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listDeposit.Result);
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

        [HttpGet("GetRentForDepositDataAll")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentForDepositDataAll()
        {
            int total = 0;
            try
            {
                var list = IUnitOfWorks.UnitOfMarketingRepository().GetRentForDepositDataAll();
                HttpResults = new ResponseData<object>("GetRentForDepositData All", SPA.System.Web.StatusCode.OK, StatusMessage.Success, list.Result);
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

        [HttpGet("GetDepositByRentId")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDepositByRentId([FromQuery] string rentId)
        {
            int total = 0;
            try
            {
                var list = IUnitOfWorks.UnitOfMarketingRepository().GetDepositByRentId(rentId);
                HttpResults = new ResponseData<object>("GetDepositByReniId", SPA.System.Web.StatusCode.OK, StatusMessage.Success, list.Result);
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


        #region Pullout
        [HttpGet("GetPullOutList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetPullOutList()
        {
            int total = 0;
            try
            {
                var listPullout = IUnitOfWorks.UnitOfMarketingRepository().GetPullOutList();
                HttpResults = new ResponseData<object>("GetPullOutList", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listPullout.Result);
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

        [HttpGet("GetRentByRentId")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRentByRentId([FromQuery] Guid rentId)
        {
            int total = 0;
            try
            {
                var pullOut = IUnitOfWorks.UnitOfMarketingRepository().GetRent(rentId);
                HttpResults = new ResponseData<object>("GetRent", SPA.System.Web.StatusCode.OK, StatusMessage.Success, pullOut.Result);
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

        [HttpGet("GetPullOutDetail")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetPullOutDetail([FromQuery] Guid rentId)
        {
            int total = 0;
            try
            {
                var pullOut = IUnitOfWorks.UnitOfMarketingRepository().GetPullOutDetail(rentId);
                HttpResults = new ResponseData<object>("GetPullOutDetail", SPA.System.Web.StatusCode.OK, StatusMessage.Success, pullOut.Result);
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


        #region Payment Schedule

        [HttpGet("GetPaymentScheduleList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetPaymentScheduleList([FromQuery] string field, string op, string value, string mode)
        {
            int total = 0;
            try
            {
                var listPullout = IUnitOfWorks.UnitOfMarketingRepository().GetPaymentScheduleList(field, op, value, mode);
                HttpResults = new ResponseData<object>("GetRentPaymentScheduleList", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listPullout.Result);
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

        [HttpGet("GetCustomerInfoListByRentId")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetCustomerInfoListByRentId([FromQuery] string rentId, int ksmType)
        {
            int total = 0;
            try
            {
                var listPullout = IUnitOfWorks.UnitOfMarketingRepository().GetCustomerInfoListByRentId(rentId, ksmType);
                HttpResults = new ResponseData<object>("GetCustomerInfoByRentId", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listPullout.Result);
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


        
        [HttpGet("GetMagPortionFromProgressiveRs")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMagPortionFromProgressiveRs([FromQuery] decimal omsetAmount, string rentId)
        {
            int total = 0;
            try
            {
                var listPullout = IUnitOfWorks.UnitOfMarketingRepository().GetMagPortionFromProgressiveRs(omsetAmount, rentId);
                HttpResults = new ResponseData<object>("GetCustomerInfoByRentId", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listPullout.Result);
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
        #region Management Fee and utility
        // GET: api/GetMFActivation
        [HttpGet("GetMFActivation")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMFActivation()
        {

            int total = 0;
            try
            {
                var listMF = IUnitOfWorks.UnitOfMarketingRepository().GetMFList();
                HttpResults = new ResponseData<object>("GET MF ACTIVATION ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listMF.Result);
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

        [HttpGet("GetMFActivationBySourceId/{sourceId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMasterUnitById(string sourceId, [FromQuery] string sourceCode)
        {
            int total = 0;
            try
            {
                if (sourceCode == "Rent")
                {
                    var listMF = IUnitOfWorks.UnitOfMarketingRepository().GetMFDetailByRentId(sourceId);
                    HttpResults = new ResponseData<object>("GET MF ACTIVATION BY RENT ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listMF.Result);
                }
                else if (sourceCode == "Sales")
                {
                    var listMF = IUnitOfWorks.UnitOfMarketingRepository().GetMFDetailBySalesId(sourceId);
                    HttpResults = new ResponseData<object>("GET MF ACTIVATION BY SALES ID", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listMF.Result);
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

        // GET: api/GetMFOutlet/{mode}
        [HttpGet("GetMFOutlet/{mode}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMFOutletList(string mode)
        {
            int total = 0;
            try
            {
                if (mode == "Rent")
                {
                    var listMF = IUnitOfWorks.UnitOfMarketingRepository().GetMFRentList();
                    HttpResults = new ResponseData<object>("GET MF OUTLET RENT ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listMF.Result);
                }
                else
                {
                    var listMF = IUnitOfWorks.UnitOfMarketingRepository().GetMFSalesList();
                    HttpResults = new ResponseData<object>("GET MF OUTLET SALES ALL", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listMF.Result);
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

        // GET: api/GetMFOutlet/{mode}
        [HttpGet("GetParamTenantMgt")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetParamtenantMgtList([FromQuery] int plnNode, [FromQuery] int pamNode, [FromQuery] int gasNode, [FromQuery] Guid sourceId, [FromQuery] string sourceCode)
        {
            int total = 0;
            try
            {
                var listParam = IUnitOfWorks.UnitOfMarketingRepository().GetParamTenantMgtList(plnNode, pamNode, gasNode, sourceId, sourceCode);
                HttpResults = new ResponseData<object>("GET PARAM TENANTMGT", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listParam.Result);
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

        [HttpPost("DeleteMfByMfId/{sourceId}/{userId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult DeleteMfByMfId(Guid sourceId, string userId)
        {
            int total = 0;
            try
            {
                var Result = IUnitOfWorks.UnitOfMarketingRepository().DeleteMfByMfId(sourceId, userId);
                var resultData = Result.Result;
                if (resultData[0].STATUS.ToLower() == "success")
                    HttpResults = new ResponseData<object>("Delete mf activation data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, sourceId);
                else
                    HttpResults = new ResponseData<object>(resultData[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, sourceId);
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
        [HttpPost("DeleteMfItemByTenantMgtId/{tenantMgtId}/{userId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult DeleteMfItemByTenantMgtId(Guid tenantMgtId, string userId)
        {
            int total = 0;
            try
            {
                var Result = IUnitOfWorks.UnitOfMarketingRepository().DeleteMfItemByTenantMgtId(tenantMgtId, userId);
                var resultData = Result.Result;
                if (resultData[0].STATUS.ToLower() == "success")
                    HttpResults = new ResponseData<object>("Delete mf activation item data successfully", SPA.System.Web.StatusCode.OK, StatusMessage.Success, tenantMgtId);
                else
                    HttpResults = new ResponseData<object>(resultData[0].MESSAGE, SPA.System.Web.StatusCode.OK, StatusMessage.Fail, tenantMgtId);
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

        [HttpGet("GetDataUnitType")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataUnitType()
        {

            int total = 0;
            try
            {
                var listOutletType = IUnitOfWorks.UnitOfMarketingRepository().GetDataUnitType();
                HttpResults = new ResponseData<object>("GET UNIT TYPE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listOutletType.Result);
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
        
        [HttpGet("GetDataDepartement")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataDepartement()
        {

            int total = 0;
            try
            {
                var listOutletType = IUnitOfWorks.UnitOfMarketingRepository().GetDataDepartement();
                HttpResults = new ResponseData<object>("GET DEPARTEMENT", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listOutletType.Result);
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
        
        [HttpGet("GetDataKeterangan")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataKeterangan()
        {

            int total = 0;
            try
            {
                var listOutletType = IUnitOfWorks.UnitOfMarketingRepository().GetDataKeterangan();
                HttpResults = new ResponseData<object>("GET KETERANGAN", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listOutletType.Result);
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


        [HttpGet("GetDataPipeType")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataPipeType()
        {

            int total = 0;
            try
            {
                var listOutletType = IUnitOfWorks.UnitOfMarketingRepository().GetDataPipeType();
                HttpResults = new ResponseData<object>("GET PIPE TYPE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listOutletType.Result);
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

        [HttpGet("GetDataPressureType")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataPressureType()
        {

            int total = 0;
            try
            {
                var listOutletType = IUnitOfWorks.UnitOfMarketingRepository().GetDataPressureType();
                HttpResults = new ResponseData<object>("GET PIPE TYPE", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listOutletType.Result);
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

        [HttpGet("GetDataLob")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataLob()
        {

            int total = 0;
            try
            {
                var listLob = IUnitOfWorks.UnitOfMarketingRepository().GetDataLob();
                HttpResults = new ResponseData<object>("GET LOB", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listLob.Result);
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

        [HttpGet("GetSubLobByLobId/{lobId}")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetSubLobByLobId(Guid lobId)
        {

            int total = 0;
            try
            {
                var listSubLob = IUnitOfWorks.UnitOfMarketingRepository().GetSubLobByLobId(lobId);
                HttpResults = new ResponseData<object>("GET SUB LOB", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listSubLob.Result);
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

        [HttpGet("GetDataChargeTo")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetDataChargeTo()
        {

            int total = 0;
            try
            {
                var listLob = IUnitOfWorks.UnitOfMarketingRepository().GetDataChargeTo();
                HttpResults = new ResponseData<object>("GET CHARGE TO", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listLob.Result);
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

        [HttpGet("GetMarketingAgent")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetMarketingAgent()
        {

            int total = 0;
            try
            {
                var listLob = IUnitOfWorks.UnitOfMarketingRepository().GetMarketingAgent();
                HttpResults = new ResponseData<object>("GET USER MARKETING", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listLob.Result);
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

        [HttpGet("GetOwner")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetOwner()
        {

            int total = 0;
            try
            {
                var listLob = IUnitOfWorks.UnitOfMarketingRepository().GetOwner();
                HttpResults = new ResponseData<object>("GET OWNER", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listLob.Result);
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

        [HttpGet("GetTenant")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetTenant()
        {

            int total = 0;
            try
            {
                var listLob = IUnitOfWorks.UnitOfMarketingRepository().GetTenant();
                HttpResults = new ResponseData<object>("GET TENANT", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listLob.Result);
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

        #region Revenue Sharing

        [HttpGet("GetRevenueSharingChargeList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRevenueSharingChargeList([FromQuery] string type, string field, string op, string value)
        {
            int total = 0;
            try
            {
                var listRS = IUnitOfWorks.UnitOfMarketingRepository().GetRevenueSharingChargeList(type, field, op, value);
                HttpResults = new ResponseData<object>("GetRevenueSharingChargeList", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRS.Result);
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

        [HttpGet("GetAllDataPSM")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetAllDataPSM([FromQuery] string type)
        {
            int total = 0;
            try
            {
                if (type == "flat")
                {
                    var list = IUnitOfWorks.UnitOfMarketingRepository().GetRentForRSFlatDataAll();
                    HttpResults = new ResponseData<object>("GetRentForRSFlatDataAll", SPA.System.Web.StatusCode.OK, StatusMessage.Success, list.Result);
                }
                else
                {
                    var list = IUnitOfWorks.UnitOfMarketingRepository().GetRentForRSProgDataAll();
                    HttpResults = new ResponseData<object>("GetRentForRSProgDataAll", SPA.System.Web.StatusCode.OK, StatusMessage.Success, list.Result);
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

        [HttpGet("GetRsChargeByRentId")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetRsChargeByRentId([FromQuery] string type, string rentId)
        {
            int total = 0;
            try
            {
                if (type == "flat")
                {
                    var listRS = IUnitOfWorks.UnitOfMarketingRepository().GetRsChargeFlatByRentId(rentId);
                    HttpResults = new ResponseData<object>("GetRsChargeFlatByRentId", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRS.Result);
                }
                else
                {
                    var listRS = IUnitOfWorks.UnitOfMarketingRepository().GetRsChargeProgByRentId(rentId);
                    HttpResults = new ResponseData<object>("GetRsChargeProgByRentId", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRS.Result);
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

        #region Charge standard
        [HttpGet("GetFrmStandardList")]
        [ProducesResponseType(typeof(ResponseData<object>), 200)]
        public IActionResult GetFrmStandardList()
        {

            int total = 0;
            try
            {
                var listRent = IUnitOfWorks.UnitOfMarketingRepository().GetFrmStandardList();
                HttpResults = new ResponseData<object>("GET FORM STANDARD LIST", SPA.System.Web.StatusCode.OK, StatusMessage.Success, listRent.Result);
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
