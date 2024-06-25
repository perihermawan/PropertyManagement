using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IUserAppRepository
    {
        Task<List<UserAppModel>> GetUserAppAll();
        Task<ViewUserModel> GetUserAppById(string id);
        UserAppModel SaveUser(UserAppModel model);
        UserAppModel EditUser(UserAppModel model);
        List<UserAppModel> DeleteUser(string id);
        Task<UserListModel> GetUserById(string id);
        Task<List<StatusResult>> EditPassword(EditPasswordModel model);
    }
}
