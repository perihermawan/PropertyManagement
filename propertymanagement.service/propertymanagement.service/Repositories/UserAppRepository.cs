using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Repositories.IRepositories;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.SignalR;
using propertymanagement.service.Hubs;
using propertymanagement.service.Models;

namespace propertymanagement.service.Repositories
{
    public class UserAppRepository : DatabaseConfig, IUserAppRepository
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        #region Constructor
        public UserAppRepository() : base() { }

        public UserAppRepository(DatabaseContext context, IHubContext<NotificationHub> hubContext) : base(context)
        {
            _hubContext = hubContext;
        }

        #endregion

        #region Service to database

        #region GET
        public async Task<List<UserAppModel>> GetUserAppAll()
        {
            List<UserAppModel> listUserApp = new List<UserAppModel>();
            try
            {
                listUserApp = (from a in Context.dbset_M_UserApp
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
            return listUserApp;
        }

        public async Task<ViewUserModel> GetUserAppById(string id)
        {
            ViewUserModel UserApp = new ViewUserModel();
            try
            {

                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                        new SqlParameter("@username",(object)Convert.ToString(id) ?? DBNull.Value)
                      };
                    UserApp = await context.ExecuteStoredProcedureSingleValue<ViewUserModel>("sp_getuserdatabyusername", param);
                }

                //sementara

            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return UserApp;
        }

        public async Task<UserListModel> GetUserById(string id)
        {
            UserListModel UserApp = new UserListModel();
            try
            {

                using (var context = new DatabaseContext(ContextOption))
                {
                    var param = new SqlParameter[]
                      {
                        new SqlParameter("@userid",(object)Convert.ToInt32(id) ?? DBNull.Value)
                      };
                    UserApp = await context.ExecuteStoredProcedureSingleValue<UserListModel>("sp_getuserdatabyuserid", param);
                    //UserApp.Password = Encryptspa.Common.Encrypt(UserApp.Password);

                }

                //sementara

            }
            catch (Exception e)
            {
                throw new Exception("Error !, " + e.Message);
            }
            return UserApp;
        }


        #endregion

        #region POST
        public UserAppModel SaveUser(UserAppModel model)
        {
            try
            {
                Context.dbset_M_UserApp.Add(model);
                Context.SaveChangesAsync();
                _hubContext.Clients.All.SendAsync("ReceiveMessage", "test author", "message 1");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return model;
        }

        public async Task<List<StatusResult>> EditPassword(EditPasswordModel model)
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
                        new SqlParameter("@USERID",(int)model.UserId),
                        new SqlParameter("@PASSWORD",(string)Encryptspa.Common.Encrypt(model.Password) ?? "")

                     };
                    result = await context.ExecuteStoredProcedure<StatusResult>("sp_upd_passsword", param);
                    Console.WriteLine(result);

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //transaction.Rollback();
            }
            return result;
        }

        public UserAppModel EditUser(UserAppModel model)
        {
            throw new NotImplementedException();
        }
        #endregion

        public List<UserAppModel> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
