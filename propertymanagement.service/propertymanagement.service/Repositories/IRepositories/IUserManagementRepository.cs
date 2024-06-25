using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models.Master;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IUserManagementRepository
    {
        //Task<List<ViewUserModel>> GetUserList();
        Task<List<ViewEmployeeModel>> GetEmployeeList();
        Task<List<UserListModel>> GetUserList();
        Task<UserListModel> ValidateUserByUserName(string username);
    }
}
