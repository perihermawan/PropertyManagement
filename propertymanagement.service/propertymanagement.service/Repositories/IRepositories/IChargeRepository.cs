using propertymanagement.service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IChargeRepository
    {
        #region Standard Charge

        Task<List<StandardChargeListViewModel>> GetStandardChargeList(string colName, string operatorQuery, string searchQuery, string mode);

        #endregion
    }
}
