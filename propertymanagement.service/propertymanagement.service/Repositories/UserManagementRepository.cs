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
    public class UserManagementRepository : DatabaseConfig, IUserManagementRepository
    {
        #region Constructor
        public UserManagementRepository() : base() { }
        public UserManagementRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database
        #region GET
        public async Task<List<UserListModel>> GetUserList()
        {
            List<UserListModel> listUser = new List<UserListModel>();
            try
            {
                //listUser = (from a in Context.dbset_VW_MsUser
                //            select new ViewUserModel { Id =  a.UserId, UserName = a.UserName, EMPLOYEEBASICINFOID = a.EmployeeNo, FullName = a.EmployeeName, Sex = a.Sex, Address = "", Email = a.Email, Password = a.Password, CompId = a.CompId, IsActive = a.IsActive}).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    listUser = await context.ExecuteStoredProcedure<UserListModel>("sp_sel_UserAll");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listUser;
        }

        public async Task<UserListModel> ValidateUserByUserName(string username)
        {
            UserListModel listUser = new UserListModel();
            try
            {
                //listUser = (from a in Context.dbset_VW_MsUser
                //            select new ViewUserModel { Id =  a.UserId, UserName = a.UserName, EMPLOYEEBASICINFOID = a.EmployeeNo, FullName = a.EmployeeName, Sex = a.Sex, Address = "", Email = a.Email, Password = a.Password, CompId = a.CompId, IsActive = a.IsActive}).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@USERNAME",(string)username)

                     };
                    listUser = await context.ExecuteStoredProcedureSingleValue<UserListModel>("sp_ValidateUserByUserName", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listUser;
        }

        public async Task<List<ViewEmployeeModel>> GetEmployeeList()
        {
            List<ViewEmployeeModel> listEmployee = new List<ViewEmployeeModel>();
            try
            {
                listEmployee = (from a in Context.dbset_VW_MsEmployee
                            orderby a.EmployeeName ascending
                            select a).ToList();
                //Context.Database.Comm
                //using (var context = new DatabaseContext(ContextOption))
                //{
                //    listUserApp = await context.ExecuteStoredProcedure<UserAppModel>("sp_activity_get_all");
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listEmployee;
        }
        #endregion

        #region put
        #endregion
        #endregion
    }
}
