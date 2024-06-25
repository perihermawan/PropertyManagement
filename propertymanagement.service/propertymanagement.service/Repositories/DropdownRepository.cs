using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Repositories.IRepositories;

namespace propertymanagement.service.Repositories
{
    public class DropdownRepository : DatabaseConfig, IDropdownRepository
    {
        public DropdownRepository() : base() { }
        public DropdownRepository(DatabaseContext context) : base(context)
        {
        }

        //public async Task<dynamic> GetChargeCode()
        //{
        //    var result = await Context.dbset_T_ChargeCode.Select(x => new { Text = x.CHARGE_CD + "-" + x.CHARGE_NAME, Value = x.CHARGE_CD, OptionValue1 = x.CUSTOMER_NAME }).ToListAsync();
        //    return result;
        //}
        public async Task<dynamic> GetEmployee(string dateFrom, string dateTo, string timeFrom, string timeTo)
        {
            var arrayDateFrom = dateFrom.Split('-');
            var arrayDateTo = dateFrom.Split('-');
            dateFrom = arrayDateFrom[2] + "-" + arrayDateFrom[1] + "-" + arrayDateFrom[0];
            dateTo = arrayDateTo[2] + "-" + arrayDateTo[1] + "-" + arrayDateTo[0];
            try
            {
                List<ViewModelEmployeeAvailability> listEmployee = new List<ViewModelEmployeeAvailability>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                    new SqlParameter("@date_from",(object)dateFrom ?? DBNull.Value),
                    new SqlParameter("@date_to",(object)dateTo ?? DBNull.Value),
                    new SqlParameter("@time_from",(object)timeFrom ?? DBNull.Value),
                    new SqlParameter("@time_to",(object)timeTo ?? DBNull.Value)
                      };
                    listEmployee = await context.ExecuteStoredProcedure<ViewModelEmployeeAvailability>("SP_ACTIVITY_GET_AVAILABILITY", param);
                    return listEmployee.Select(x => new { Text = x.FULL_NAME, Value = x.ID, OptionValue1 = x.NIK, OptionValue2 = x.FULL_NAME, OptionValue3 = x.AVAILABLE }).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            //return listEmployee;
        }

        public async Task<dynamic> GetDDLLeaveRequest()
        {
            var result = await Context.dbset_M_LeaveType.Select(x => new { Text = x.LEAVE_TYPE_NAME, Value = x.LEAVE_TYPE_CD, OptionValue1 = x.CHARGE_CD, OptionValue2 = x.IS_LEAVE_FULLDAY }).ToListAsync();
            return result;
        }
        
        public async Task<dynamic> GetDDLCompany()
        {
            try
            {
                List<CompanyModel> listCompany = new List<CompanyModel>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    listCompany = await context.ExecuteStoredProcedure<CompanyModel>("sp_sel_MsCompany");
                    return listCompany.Select(x => new { Text = x.CompanyName, Value = x.CompId, OptionValue1 = x.CompanyCode, OptionValue2 = x.CompanyName, OptionValue3 = x.CompId }).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<dynamic> GetDDLRoles(string appName)
        {
            try
            {
                List<RoleModel> listRole = new List<RoleModel>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@ApplicationName",(object)appName ?? DBNull.Value)
                     };
                    listRole = await context.ExecuteStoredProcedure<RoleModel>("sp_GetAllRoles", param);
                    return listRole.Select(x => new { Text = x.Rolename, Value = x.RoleId, OptionValue1 = x.ApplicationName, OptionValue2 = x.Rolename, OptionValue3 = x.RoleId }).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<dynamic> GetDDLParam(string paramCode)
        {
            try
            {
                List<ParamModel> result = new List<ParamModel>();
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@paramcode", paramCode)
                     };
                    result = await context.ExecuteStoredProcedure<ParamModel>("sp_sel_PrmOthers", param);
                    return result.Select(x => new { Text = x.ParamValue, Value = x.ParamId, OptionValue1 = x.ParamCode, OptionValue2 = x.ParamValue, OptionValue3 = x.ParamValue }).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
