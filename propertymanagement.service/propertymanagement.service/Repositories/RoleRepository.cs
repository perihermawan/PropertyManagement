using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.Master;

namespace propertymanagement.service.Repositories
{
    public class RoleRepository : DatabaseConfig, IRoleRepository
    {
        #region Constructor
        public RoleRepository() : base() { }
        public RoleRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database

        #region GET
        public async Task<List<RoleModel>> GetRoleAll()
        {
            List<RoleModel> listRole = new List<RoleModel>();
            try
            {
                listRole = (from a in Context.dbset_Role
                               select a).ToList();
                //using (var context = new DatabaseContext(ContextOption))
                //{
                //    listUserApp = await context.ExecuteStoredProcedure<UserAppModel>("sp_activity_get_all");
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listRole;
        }
        #endregion

        #endregion
    }
}
