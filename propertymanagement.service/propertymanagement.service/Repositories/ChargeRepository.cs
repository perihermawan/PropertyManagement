using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models.Marketing;


namespace propertymanagement.service.Repositories
{
    public class ChargeRepository : DatabaseConfig, IChargeRepository
    {
        #region Constructor
        public ChargeRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Standard Charge

        public async Task<List<StandardChargeListViewModel>> GetStandardChargeList(string colName, string operatorQuery, string searchQuery, string mode)
        {
            List<StandardChargeListViewModel> result = new List<StandardChargeListViewModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          /*new SqlParameter("@columnName", colName),
                          new SqlParameter("@operator", operatorQuery),
                          new SqlParameter("@searchQuery", searchQuery),
                          new SqlParameter("@mode", mode)*/
                      };
                    result = await context.ExecuteStoredProcedure<StandardChargeListViewModel>("sp_get_StandardChargeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<RentStandardListModel>> GetRentStandard()
        {
            List<RentStandardListModel> RentStandardDetail = new List<RentStandardListModel>();
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
                    RentStandardDetail = await context.ExecuteStoredProcedure<RentStandardListModel>("sp_MsRentStandardList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentStandardDetail;
        }

        public async Task<List<StandardItemModel>> GetStandardItemById(String id)
        {
            List<StandardItemModel> RentStandardItemDetail = new List<StandardItemModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    Guid RentId = new Guid(id);
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@RentId", (Guid)RentId)
                     };
                    RentStandardItemDetail = await context.ExecuteStoredProcedure<StandardItemModel>("sp_sel_FormStNonStByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentStandardItemDetail;
        }

        #endregion

        #region Non Standard Charge

        public async Task<List<NonStandardChargeListViewModel>> GetNonStandardChargeList(string colName, string operatorQuery, string searchQuery, string mode)
        {
            List<NonStandardChargeListViewModel> result = new List<NonStandardChargeListViewModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                          /*new SqlParameter("@columnName", colName),
                          new SqlParameter("@operator", operatorQuery),
                          new SqlParameter("@searchQuery", searchQuery),
                          new SqlParameter("@mode", mode)*/
                      };
                    result = await context.ExecuteStoredProcedure<NonStandardChargeListViewModel>("sp_get_NonStandardChargeList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return result;
        }

        public async Task<List<RentNonStandardListModel>> GetRentNonStandard()
        {
            List<RentNonStandardListModel> RentNonStandardDetail = new List<RentNonStandardListModel>();
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
                    RentNonStandardDetail = await context.ExecuteStoredProcedure<RentNonStandardListModel>("sp_MsRentNonStandardList", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentNonStandardDetail;
        }

        public async Task<List<NonStandardItemModel>> GetNonStandardItemById(String id)
        {
            List<NonStandardItemModel> RentNonStandardItemDetail = new List<NonStandardItemModel>();
            try
            {
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    Guid RentId = new Guid(id);
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@RentId", (Guid)RentId)
                     };
                    RentNonStandardItemDetail = await context.ExecuteStoredProcedure<NonStandardItemModel>("sp_sel_FormNonStByRentId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return RentNonStandardItemDetail;
        }

        #endregion
    }
}
