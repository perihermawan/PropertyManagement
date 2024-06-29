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
using propertymanagement.service.Models.Marketing;
using propertymanagement.service.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using propertymanagement.service.Models.DTO;





using Microsoft.AspNetCore.Http;

using propertymanagement.service.Hubs;


using SPA.System.Data;
using SPA.System.Web;
using Newtonsoft.Json;


namespace propertymanagement.service.Repositories
{
    public class CommonRepository : DatabaseConfig, ICommonRepository
    {

        #region Constructor
        public CommonRepository() : base() { }
        public CommonRepository(DatabaseContext context) : base(context) { }
        #endregion
        #region Common
        public async Task<List<StatusResult>> ExecuteSP(string spname, string json, string user)
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
                        new SqlParameter("@json",(string)json?? ""),
                        new SqlParameter("@CreateUser",(string)user ?? ""),

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>(spname, param);

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //transaction.Rollback();
            }
            return result;
        }

        public async Task<List<StatusResult>> ExecuteSPDelete(string spname, string id, string user)
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
                        new SqlParameter("@id",(string)id?? ""),
                        new SqlParameter("@DeleteUser",(string)user ?? ""),

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>(spname, param);

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //transaction.Rollback();
            }
            return result;
        }
public async Task<List<StatusResult>> ExecuteSPNonStandardDetail(NonStandardItem item, string user, string remark)
{
    List<StatusResult> result = new List<StatusResult>();
    try
    {
        using (var context = new DatabaseContext(ContextOption))
        {
            var param = new SqlParameter[]
            {
                new SqlParameter("@FormId", Guid.Parse("1b1112a4-ac3d-4754-85bf-1f40f0a34ca2")),
                new SqlParameter("@RentId", Guid.Parse("1b1112a4-ac3d-4754-85bf-1f40f0a34ca2")),
                new SqlParameter("@PeriodFrom", DateTime.TryParse("2024-06-30", out DateTime periodFrom) ? (object)periodFrom : DBNull.Value),
                new SqlParameter("@PeriodTo", DateTime.TryParse("2024-06-30", out DateTime periodTo) ? (object)periodTo : DBNull.Value),
                new SqlParameter("@FormDescription", (string)"hallo"),
                new SqlParameter("@BasicAmount", 5678.90),
                new SqlParameter("@AdditionalAmount", 5678.90),
                new SqlParameter("@ChargeAmountInPeriod", 5678.90),
                new SqlParameter("@CreateUser", string.IsNullOrEmpty(user) ? (object)DBNull.Value : user),
                new SqlParameter("@Remark", string.IsNullOrEmpty(remark) ? (object)DBNull.Value : remark)
            };

            result = await context.ExecuteStoredProcedure<StatusResult>("sp_ins_FormNonStandard", param);
        }
    }
    catch (Exception ex)
    {
        // Log the exception
        string str = ex.Message;
        // Handle the exception
    }
    return result;
}



        #endregion

    }
}
