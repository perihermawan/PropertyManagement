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
using Microsoft.EntityFrameworkCore;
using propertymanagement.service.Models.DTO;

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

        public async Task<List<StatusResult>> ExecuteSP(string spname, string json)
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
                        new SqlParameter("@json",(string)json?? "")

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

        #endregion

    }
}
