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
        #endregion

        #endregion

        #endregion
    }
}
