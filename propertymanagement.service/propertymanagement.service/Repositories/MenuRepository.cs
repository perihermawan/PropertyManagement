using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Repositories
{
    public class MenuRepository : DatabaseConfig, IMenuRepository
    {
        #region Constructor
        public MenuRepository() : base() { }
        public MenuRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database

        #region GET
        public async Task<List<ViewMenuModel>> GetMenuList()
        {
            List<ViewMenuModel> listMenu = new List<ViewMenuModel>();
            try
            {
                
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        //new SqlParameter("@UserId",(object)UserId ?? DBNull.Value)
                     };
                    listMenu = await context.ExecuteStoredProcedure<ViewMenuModel>("sp_get_MenuAll", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listMenu;
        }

        public async Task<List<UserFormAccessModel>> GetPermissionList(int UserId)
        {
            List<UserFormAccessModel> listPermission = new List<UserFormAccessModel>();
            
            try
            {
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@UserId",(object)UserId ?? DBNull.Value)
                     };
                    listPermission = await context.ExecuteStoredProcedure<UserFormAccessModel>("sp_sel_AccessUserForm", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listPermission;
        }
        #endregion

        #endregion
    }
}
