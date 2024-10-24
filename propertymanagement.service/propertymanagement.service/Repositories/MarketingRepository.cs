using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models;
using System.ComponentModel;
using propertymanagement.service.Models.Marketing;
using Microsoft.EntityFrameworkCore;
using propertymanagement.service.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;


namespace propertymanagement.service.Repositories
{
    public class MarketingRepository : DatabaseConfig, IMarketingRepository
    {
        #region Constructor
        public MarketingRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database

        #region RentAmount

        public async Task<List<RentAmountModel>> GetRentAmountList()
        {
            List<RentAmountModel> result = new List<RentAmountModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    result = await context.ExecuteStoredProcedure<RentAmountModel>("sp_get_RentAmountList");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<RentAmountViewModel> GetRentAmountDetail(string Param)
        {
            RentAmountViewModel RentAmountDetail = new RentAmountViewModel();
            try
            {
                Guid RentId = new Guid(Param);
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@RentId",(Guid)RentId)
                     };
                    RentAmountDetail = await context.ExecuteStoredProcedureSingleValue<RentAmountViewModel>("sp_Sel_MsRentAmountByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentAmountDetail;
        }
        
        public async Task<List<RentAmountViewModel>> GetRentAmountItems(string Param)
        {
            List<RentAmountViewModel> RentAmountItems = new List<RentAmountViewModel>();
            try
            {
                Guid RentId = new Guid(Param);
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@RentId",(Guid)RentId)
                     };
                    RentAmountItems = await context.ExecuteStoredProcedure<RentAmountViewModel>("sp_Sel_MsRentAmountByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentAmountItems;
        }

        public async Task<List<DownPaymentViewModel>> GetDownPaymentList()
        {
            List<DownPaymentViewModel> result = new List<DownPaymentViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    result = await context.ExecuteStoredProcedure<DownPaymentViewModel>("sp_get_DownPaymentList");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<DownPaymentViewModel>> GetDpItems(string Param)
        {
            List<DownPaymentViewModel> DpDetail = new List<DownPaymentViewModel>();
            try
            {
                Guid RentId = new Guid(Param);
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@RentId",(Guid)RentId)
                     };
                    DpDetail = await context.ExecuteStoredProcedure<DownPaymentViewModel>("sp_Sel_MsDownPaymentByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return DpDetail;
        }

        public async Task<List<StatusResult>> DeleteRentAmountByRentId(Guid unitId, string userId, string reason)
        {
            List<StatusResult> result = new List<StatusResult>();
            //var context = new DatabaseContext(ContextOption);
            //var transaction = context.Database.BeginTransaction();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                         new SqlParameter("@UnitID",unitId),
                        new SqlParameter("@Reason",(string)reason?? ""),
                        new SqlParameter("@DeleteUser",(string)userId ?? "")

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>("sp_del_JSONMsUnit", param);


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //transaction.Rollback();
            }
            return result;
        }

        public async Task<RentDetail> GetRentDetail(string Param)
        {
            RentDetail RentDetail = new RentDetail();
            try
            {
                Guid RentId = new Guid(Param);
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@RentId",(Guid)RentId)
                     };
                    RentDetail = await context.ExecuteStoredProcedureSingleValue<RentDetail>("sp_Sel_MsRentById", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentDetail;
        }

        #endregion

        #region MarketingRent

        #region GET
        public async Task<List<RentListModel>> GetRentList()
        {
            List<RentListModel> listRent = new List<RentListModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    listRent = await context.ExecuteStoredProcedure<RentListModel>("sp_get_rentAll", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listRent;
        }

        public async Task<List<RentPullOutListListModel>> GetRentPullOutList()
        {
            List<RentPullOutListListModel> RentPullOutDetail = new List<RentPullOutListListModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@field","PSMNumber"),
                        new SqlParameter("@param","")
                     };
                    RentPullOutDetail = await context.ExecuteStoredProcedure<RentPullOutListListModel>("sp_MsRentPullOutList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentPullOutDetail;
        }

        public async Task<List<RentRentAmountListModel>> GetRentRentAmountList()
        {
            List<RentRentAmountListModel> RentRentAmountDetail = new List<RentRentAmountListModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@field","PSMNumber"),
                        new SqlParameter("@param","")
                     };
                    RentRentAmountDetail  = await context.ExecuteStoredProcedure<RentRentAmountListModel>("sp_sel_MsRentListForRentAmount", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentRentAmountDetail;
        }

        public async Task<List<ChargeTypeListModel>> GetChargeTypeList()
        {
            List<ChargeTypeListModel> ChargeTypeDetail = new List<ChargeTypeListModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@paramcode","ChargeType")
                     };
                    ChargeTypeDetail = await context.ExecuteStoredProcedure<ChargeTypeListModel>("sp_sel_PrmOthers", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return ChargeTypeDetail;
        }

        public async Task<List<OutletListModel>> GetOutletList()
        {
            List<OutletListModel> outletLists = new List<OutletListModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                        new SqlParameter("@OutletId","00000000-0000-0000-0000-000000000000")
                      };
                    outletLists = await context.ExecuteStoredProcedure<OutletListModel>("sp_sel_MsOutlet", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletLists;
        }
        
        public async Task<List<GroupListModel>> GetGroupList()
        {
            List<GroupListModel> outletLists = new List<GroupListModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletLists = await context.ExecuteStoredProcedure<GroupListModel>("sp_get_MsGrouping", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletLists;
        }
        
        public async Task<ValidateRentModel> ValidateCreate(string KSMNumber, string PSMNumber)
        {
            ValidateRentModel outletLists = new ValidateRentModel();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@KSMNumber", KSMNumber),
                          new SqlParameter("@PSMNumber", PSMNumber)
                      };
                    outletLists = await context.ExecuteStoredProcedureSingleValue<ValidateRentModel>("sp_get_validateRentCreate", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletLists;
        }
        
        public async Task<List<NextKsmPsmModel>> GetNextKsmPsm()
        {
            List<NextKsmPsmModel> outletLists = new List<NextKsmPsmModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletLists = await context.ExecuteStoredProcedure<NextKsmPsmModel>("sp_get_NextKsmPsm", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletLists;
        }
        
        public async Task<List<DueDateModel>> GetDueDate()
        {
            List<DueDateModel> outletLists = new List<DueDateModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletLists = await context.ExecuteStoredProcedure<DueDateModel>("sp_get_MsDueDate", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletLists;
        }
        
        public async Task<List<RentUnitListModel>> GetDataUnitList(string mapNumber, string floor, string block, string number, string statusDesc)
        {
            List<RentUnitListModel> outletLists = new List<RentUnitListModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    // change mapNumber, floor, block, etc is null to empty string
                    if (mapNumber == null) mapNumber = "";
                    if (floor == null) floor = "";
                    if (block == null) block = "";
                    if (number == null) number = "";
                    if (statusDesc == null) statusDesc = "";

                    var param = new SqlParameter[]
                      {
                        new SqlParameter("@table", "MapNumber LIKE '%%'"),
                        new SqlParameter("@value", ""),
                      };
                    outletLists = await context.ExecuteStoredProcedure<RentUnitListModel>("sp_Sel_UnitForRentDetail", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletLists;
        }

        public async Task<List<DownPaymentViewModel>> GetDownPaymentList(Guid id)
        {
            List<DownPaymentViewModel> result = new List<DownPaymentViewModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId",(Guid)id)
                      };
                    result = await context.ExecuteStoredProcedure<DownPaymentViewModel>("sp_Sel_MsDownPaymentByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        public async Task<List<OutletTypeModel>> GetDataOutletType()
        {
            List<OutletTypeModel> outletTypeLists = new List<OutletTypeModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletTypeLists = await context.ExecuteStoredProcedure<OutletTypeModel>("sp_sel_OutletTypeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletTypeLists;
        }
        public async Task<List<UnitTypeModel>> GetDataUnitType()
        {
            List<UnitTypeModel> outletTypeLists = new List<UnitTypeModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletTypeLists = await context.ExecuteStoredProcedure<UnitTypeModel>("sp_sel_UnitTypeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletTypeLists;
        }
        public async Task<List<DepartementModel>> GetDataDepartement()
        {
            List<DepartementModel> outletTypeLists = new List<DepartementModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletTypeLists = await context.ExecuteStoredProcedure<DepartementModel>("sp_sel_DepartementList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletTypeLists;
        }
        public async Task<List<KeteranganModel>> GetDataKeterangan()
        {
            List<KeteranganModel> outletTypeLists = new List<KeteranganModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletTypeLists = await context.ExecuteStoredProcedure<KeteranganModel>("sp_sel_KeteranganList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletTypeLists;
        }
        #endregion
        
        public async Task<List<PipeTypeModel>> GetDataPipeType()
        {
            List<PipeTypeModel> outletTypeLists = new List<PipeTypeModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletTypeLists = await context.ExecuteStoredProcedure<PipeTypeModel>("sp_sel_PipeTypeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletTypeLists;
        }
        
        public async Task<List<PressureTypeModel>> GetDataPressureType()
        {
            List<PressureTypeModel> outletTypeLists = new List<PressureTypeModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    outletTypeLists = await context.ExecuteStoredProcedure<PressureTypeModel>("sp_sel_PressureTypeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return outletTypeLists;
        }

        public async Task<List<LobModel>> GetDataLob()
        {
            List<LobModel> lobLists = new List<LobModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    lobLists = await context.ExecuteStoredProcedure<LobModel>("sp_sel_LobList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return lobLists;
        }
        public async Task<List<SubLobModel>> GetSubLobByLobId(Guid lobId)
        {
            List<SubLobModel> subLobLists = new List<SubLobModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@LobId",(Guid)lobId)
                      };
                    subLobLists = await context.ExecuteStoredProcedure<SubLobModel>("sp_sel_SubLobByLobId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return subLobLists;
        }
        
        public async Task<List<ChargeToModel>> GetDataChargeTo()
        {
            List<ChargeToModel> chargeTo = new List<ChargeToModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    chargeTo = await context.ExecuteStoredProcedure<ChargeToModel>("sp_sel_ChargeToList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return chargeTo;
        }
        

        public async Task<List<RentAmountViewModel>> GetRentAmountList(Guid id)
        {
            List<RentAmountViewModel> result = new List<RentAmountViewModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId",(Guid)id)
                      };
                    result = await context.ExecuteStoredProcedure<RentAmountViewModel>("sp_Sel_MsRentAmountByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        
        public async Task<List<MarketingAgentModel>> GetMarketingAgent()
        {
            List<MarketingAgentModel> result = new List<MarketingAgentModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    result = await context.ExecuteStoredProcedure<MarketingAgentModel>("sp_sel_UserMarketing", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<OwnerModel>> GetOwner()
        {
            List<OwnerModel> result = new List<OwnerModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    result = await context.ExecuteStoredProcedure<OwnerModel>("sp_sel_OwnerList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<TenantModel>> GetTenant()
        {
            List<TenantModel> result = new List<TenantModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                      };
                    result = await context.ExecuteStoredProcedure<TenantModel>("sp_sel_TenantList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        #endregion

        #endregion

        #region Deposit

        public async Task<List<DepositViewModel>> GetDepositList()
        {
            List<DepositViewModel> result = new List<DepositViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]{};
                    var query = "SELECT distinct rentId,KSMNumber,LocationMap,Square,OutletName,TenantOwner,StartDate,EndDate,Editable FROM VW_FRMDEPOSITLIST";
                    result = await context.ExecuteSQLScript<DepositViewModel>(query, param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<DepositRentViewModel>> GetRentForDepositDataAll()
        {
            List<DepositRentViewModel> result = new List<DepositRentViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@field", "PSMNumber"),
                          new SqlParameter("@param", "")
                      };
                    result = await context.ExecuteStoredProcedure<DepositRentViewModel>("sp_sel_MsRentListForDeposit", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<DepositDetailViewModel>> GetDepositByRentId(string rentId)
        {
            List<DepositDetailViewModel> result = new List<DepositDetailViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[] {
                          new SqlParameter("@RentId", rentId),
                    };
                    result = await context.ExecuteStoredProcedure<DepositDetailViewModel>("sp_sel_DepositByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        #endregion


        #region Pull Out
        public async Task<List<PullOutViewModel>> GetPullOutList()
        {
            List<PullOutViewModel> result = new List<PullOutViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@field", "(CASE WHEN ISPULLOUT=1 THEN 'PullOut' WHEN ISCLOSING=1 THEN 'Closing' ELSE 'Active' END)"),
                          new SqlParameter("@param", "Active")
                      };
                    result = await context.ExecuteStoredProcedure<PullOutViewModel>("sp_sel_MsRentListForDeposit", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<PullOutRentViewModel> GetRent(Guid rentId)
        {
            PullOutRentViewModel result = new PullOutRentViewModel();
            try
            {
                List<PullOutRentViewModel> temp = new List<PullOutRentViewModel>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId)
                      };
                    temp = await context.ExecuteStoredProcedure<PullOutRentViewModel>("sp_Sel_MsRentById", param);
                    if (temp.Count > 0)
                        result = temp[0];
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        
        public async Task<RentKsmModel> GetRentById(Guid rentId)
        {
            RentKsmModel result = new RentKsmModel();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId)
                      };
                    result = await context.ExecuteStoredProcedureSingleValue<RentKsmModel>("sp_Sel_MsRentById", param);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        
        public async Task<List<ListUnitTelpModel>> GetRentDById(Guid rentId)
        {
            List<ListUnitTelpModel> finalResult = new List<ListUnitTelpModel>();
            try
            {
                List<RentUnitListEditModel> result = new List<RentUnitListEditModel>();
                List<RentTelpListEditModel> result2 = new List<RentTelpListEditModel>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId)
                      };
                    result = await context.ExecuteStoredProcedure<RentUnitListEditModel>("sp_Sel_MsRentD", param);

                    var param2 = new SqlParameter[]
                        {
                            new SqlParameter("@RentId", rentId)
                        };
                    result2 = await context.ExecuteStoredProcedure<RentTelpListEditModel>("sp_sel_MsTelpByRentId", param2);

                    finalResult.Add(new ListUnitTelpModel
                    {
                        Unit = result,
                        Telp = result2
                    });
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return finalResult;
        }

        public async Task<PullOutDetailViewModel> GetPullOutDetail(Guid rentId)
        {
            PullOutDetailViewModel result = new PullOutDetailViewModel();
            try
            {
                List<PullOutDetailViewModel> temp = new List<PullOutDetailViewModel>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId)
                      };
                    temp = await context.ExecuteStoredProcedure<PullOutDetailViewModel>("sp_Sel_PullOutDetail", param);
                    if (temp.Count > 0)
                        result = temp[0];
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        #endregion


        #region Payment Schedule
        public async Task<List<PaymentScheduleViewModel>> GetPaymentScheduleList(string _field, string _operator, string _value, string mode)
        {
            List<PaymentScheduleViewModel> result = new List<PaymentScheduleViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    string condition = "";
                    if (_operator == "Equal")
                        condition = "= '" + _value + "'";
                    else if (_operator == "LIKE")
                        condition = "LIKE '%" + _value + "%'";
                    else if (_operator == "LIKE_START")
                        condition = "LIKE '%" + _value + "'";
                    else if (_operator == "LIKE_END")
                        condition = "LIKE '" + _value + "%'";
                    var param = new SqlParameter[] { };
                    var query = "SELECT DISTINCT RentId,KSMNumber,PSMNumber,LocationMap,Square,OutletName,TenantOwner,StartDate,EndDate,Status,KSMTYPE,ChargeType FROM VW_FRMPAYMENTSCHEDULELIST where " + _field + " " + condition;
                    if (mode == "Rent")
                        query += " and (ChargeType = 'Standard' or ChargeType = 'Non Standard') and left(right(NUMBER,3),1) NOT IN ('3','5','8')";
                    else
                        query += " and (ChargeType = 'Progressive Rs' or ChargeType = 'Flat Rs') and left(right(NUMBER,3),1) NOT IN ('3','5','8')";
                    result = await context.ExecuteSQLScript<PaymentScheduleViewModel>(query, param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<PaymentScheduleCustomerInfoViewModel>> GetCustomerInfoListByRentId(string rentId, int ksmType)
        {
            List<PaymentScheduleCustomerInfoViewModel> result = new List<PaymentScheduleCustomerInfoViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId),
                          new SqlParameter("@KSMType", ksmType)
                      };
                    result = await context.ExecuteStoredProcedure<PaymentScheduleCustomerInfoViewModel>("sp_sel_CustomerInfoByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }


        private class ProgressiveRs
        {
            public decimal MagPortion { get; set; }
        }

        public async Task<decimal> GetMagPortionFromProgressiveRs(decimal omsetAmount, string rentId)
        {
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[] { };
                    var query = "select TOP 1 MAGPortion from dbo.FormProgRs where " + omsetAmount + " between OmsetFrom AND OmsetTo And RentId='" + rentId+"'";
                    List<ProgressiveRs> res = await context.ExecuteSQLScript<ProgressiveRs>(query, param);

                    if (res.Count > 0)
                        return res[0].MagPortion;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return 0;
        }
        #endregion
        #region Management Fee and utility
        public async Task<List<TenantMgtListModel>> GetMFList()
        {
            List<TenantMgtListModel> listMF = new List<TenantMgtListModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    listMF = await context.ExecuteStoredProcedure<TenantMgtListModel>("sp_get_mfAll", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listMF;
        }
        public async Task<List<ViewTenantMgtRentModel>> GetMFDetailByRentId(string sourceId)
        {
            List<ViewTenantMgtRentModel> TenantMgtDetail = new List<ViewTenantMgtRentModel>();
            try
            {
                Guid SourceId = new Guid(sourceId);
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@SOURCEID",(Guid)SourceId)
                     };
                    TenantMgtDetail = await context.ExecuteStoredProcedure<ViewTenantMgtRentModel>("sp_sel_MsTenantMgtByRentID", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return TenantMgtDetail;
        }
        public async Task<List<ViewTenantMgtSalesModel>> GetMFDetailBySalesId(string sourceId)
        {
            List<ViewTenantMgtSalesModel> TenantMgtDetail = new List<ViewTenantMgtSalesModel>();
            try
            {
                Guid SourceId = new Guid(sourceId);
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@SOURCEID",(Guid)SourceId)
                     };
                    TenantMgtDetail = await context.ExecuteStoredProcedure<ViewTenantMgtSalesModel>("sp_sel_MsTenantMgtBySalesID", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return TenantMgtDetail;
        }
        public async Task<List<TenantMgtRentListModel>> GetMFRentList()
        {
            List<TenantMgtRentListModel> listMFRent = new List<TenantMgtRentListModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@field","PSMNumber"),
                        new SqlParameter("@param",""),
                        new SqlParameter("@mode","Rent"),
                     };
                    listMFRent = await context.ExecuteStoredProcedure<TenantMgtRentListModel>("sp_sel_MsTenantMgtRentPopUp", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listMFRent;
        }
        public async Task<List<TenantMgtSalesListModel>> GetMFSalesList()
        {
            List<TenantMgtSalesListModel> listMFSales = new List<TenantMgtSalesListModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@field","OutletName"),
                        new SqlParameter("@param",""),
                     };
                    listMFSales = await context.ExecuteStoredProcedure<TenantMgtSalesListModel>("sp_sel_MsTenantMgtSalesPopUp", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listMFSales;
        }
        public async Task<List<ViewParamTenantMgt>> GetParamTenantMgtList(int plnNode, int pamNode, int gasNode, Guid sourceId, string sourceCode)
        {
            List<ViewParamTenantMgt> listMFSales = new List<ViewParamTenantMgt>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@PlnNode",plnNode),
                        new SqlParameter("@PamNode",pamNode),
                        new SqlParameter("@GasNode",gasNode),
                        new SqlParameter("@SourceId",sourceId),
                        new SqlParameter("@SourceCode",sourceCode),
                     };
                    listMFSales = await context.ExecuteStoredProcedure<ViewParamTenantMgt>("sp_sel_ParamTenantMgt", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listMFSales;
        }
        public async Task<List<StatusResult>> DeleteMfByMfId(Guid sourceId, string userId)
        {
            List<StatusResult> result = new List<StatusResult>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@SourceId",sourceId),
                        new SqlParameter("@TenantMgtCode","MF"),
                        new SqlParameter("@DeleteUser",(string)userId ?? "")

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>("sp_del_JsonMsTenantMgt", param);


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return result;
        }
        public async Task<List<StatusResult>> DeleteMfItemByTenantMgtId(Guid tenantMgtId, string userId)
        {
            List<StatusResult> result = new List<StatusResult>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@TenantMgtId",tenantMgtId),
                        new SqlParameter("@DeleteUser",(string)userId ?? "")

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>("sp_del_JsonMsTenantMgtItem", param);


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return result;
        }
        #endregion

        #region Revenue Sharing
        public async Task<List<RevenueSharingChargeViewModel>> GetRevenueSharingChargeList(string type, string _field, string _operator, string _value)
        {
            List<RevenueSharingChargeViewModel> result = new List<RevenueSharingChargeViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var query = "";
                    
                    string condition = "";
                    if (_operator == "Equal")
                        condition = "= '" + _value + "'";
                    else if (_operator == "LIKE")
                        condition = "LIKE '%" + _value + "%'";
                    else if (_operator == "LIKE_START")
                        condition = "LIKE '%" + _value + "'";
                    else if (_operator == "LIKE_END")
                        condition = "LIKE '" + _value + "%'";
                    
                    var param = new SqlParameter[] { };
                    if (type == "flat")
                        query = "SELECT DISTINCT RENTID,PSMNUMBER,KSMNUMBER,ISPULLOUT,ISCLOSING,ClosingDate,PullOutDate,LocationMap,Square,OutletName,UnitOwner,TenantOwner,StartDate,EndDate,Status,CreateUser,UpdateUser,CreateDate,StatusDate,chargetype,Editable,CHARGEDATEFROM,CHARGEDATETO FROM VW_FRMFlatRSLIST where left(right(NUMBER,3),1) NOT IN ('3','5','8')";
                    else
                        query = "SELECT DISTINCT RENTID,PSMNUMBER,KSMNUMBER,ISPULLOUT,ISCLOSING,ClosingDate,PullOutDate,LocationMap,Square,OutletName,UnitOwner,TenantOwner,StartDate,EndDate,Status,CreateUser,UpdateUser,CreateDate,StatusDate,chargetype,Editable,CHARGEDATEFROM,CHARGEDATETO FROM VW_FRMProgRsLIST where left(right(NUMBER,3),1) NOT IN ('3','5','8')";

                    if (_field != null & condition != "")
                        query += " AND " + _field + " " + condition;
                    
                    query += " ORDER BY CREATEDATE DESC";

                    result = await context.ExecuteSQLScript<RevenueSharingChargeViewModel>(query, param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        #region Flat RS
        public async Task<List<RsChargeFlatItemViewModel>> GetRentForRSFlatDataAll()
        {
            List<RsChargeFlatItemViewModel> result = new List<RsChargeFlatItemViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[] {};
                    result = await context.ExecuteStoredProcedure<RsChargeFlatItemViewModel>("sp_sel_FormFlatRsChargeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<RsChargeFlatFormViewModel>> GetRsChargeFlatByRentId(string rentId)
        {
            List<RsChargeFlatFormViewModel> result = new List<RsChargeFlatFormViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId)
                      };
                    result = await context.ExecuteStoredProcedure<RsChargeFlatFormViewModel>("sp_sel_FormFlatRsByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        #endregion

        #region Progressive RS
        public async Task<List<RsChargeProgressiveItemViewModel>> GetRentForRSProgDataAll()
        {
            List<RsChargeProgressiveItemViewModel> result = new List<RsChargeProgressiveItemViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[] { };
                    result = await context.ExecuteStoredProcedure<RsChargeProgressiveItemViewModel>("sp_sel_FormProgRsChargeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<RsChargeProgressiveFormViewModel>> GetRsChargeProgByRentId(string rentId)
        {
            List<RsChargeProgressiveFormViewModel> result = new List<RsChargeProgressiveFormViewModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          new SqlParameter("@RentId", rentId)
                      };
                    result = await context.ExecuteStoredProcedure<RsChargeProgressiveFormViewModel>("sp_sel_FormProgRsChargeByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }
        #endregion

        #endregion

        #region charge standard
        public async Task<List<RentChargeStandardListModel>> GetFrmStandardList()
        {
            List<RentChargeStandardListModel> listRent = new List<RentChargeStandardListModel>();
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UnitId",(Guid)UnitId)
                     };
                    listRent = await context.ExecuteStoredProcedure<RentChargeStandardListModel>("sp_Sel_FrmStandardList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listRent;
        }
        #endregion
    }
}
