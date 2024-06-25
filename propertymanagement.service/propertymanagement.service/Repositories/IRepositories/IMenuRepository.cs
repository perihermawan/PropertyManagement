using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models.Master;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IMenuRepository
    {
        Task<List<ViewMenuModel>> GetMenuList();
    }

}
