using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IUserAccessRepository
    {
        Task<List<ViewAccessMenuModel>> GetUserAccessAll(string id);



    }
}
