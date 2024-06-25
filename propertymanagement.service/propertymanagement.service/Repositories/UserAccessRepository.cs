using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Repositories
{
    public class UserAccessRepository : DatabaseConfig, IUserAccessRepository
    {
        #region Constructor
        public UserAccessRepository() : base() { }
        public UserAccessRepository(DatabaseContext context) : base(context) { }
        #endregion

        #region Service to database

        public async Task<List<ViewAccessMenuModel>> GetUserAccessAll(string id)
        {
            List<ViewAccessMenuModel> listuseraccess = new List<ViewAccessMenuModel>();
            try
            {
                //listUnit = (from a in Context.dbset_VW_MsUnit
                //            orderby a.UpdateDate descending, a.CreateDate descending
                //            select a).ToList();
                //Context.Database.Comm
                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                     {
                        new SqlParameter("@UserId",(object)Convert.ToInt32(id) ?? DBNull.Value)
                     };
                    listuseraccess = await context.ExecuteStoredProcedure<ViewAccessMenuModel>("sp_getMenuPermissionByUserId", param);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return listuseraccess;
        }
        //public async Task<List<ViewAccessMenuModel>>GetUserAccessAll(int id)
        //{
        //    List<ViewAccessMenuModel> listUserAccess= new List<ViewAccessMenuModel>();
        //    try
        //    {
        //        using (var context = new DatabaseContext(ContextOption))
        //        {
        //            var param = new SqlParameter[]
        //              {
        //                new SqlParameter("@UserId",(object)Convert.ToInt32(id) ?? DBNull.Value)
        //              };
        //            listUserAccess = await context.ExecuteStoredProcedure<ViewAccessMenuModel>("sp_getMenuPermissionByUserId", param);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error !, " + e.Message);
        //    }
        //    return listUserAccess;
        //}


        #endregion

    }
}
