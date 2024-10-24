using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models;
using propertymanagement.service.Models.DTO;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface ICommonRepository
    {
        #region Common
        Task<List<StatusResult>> ExecuteSP(string spname, string json);
        Task<List<StatusResult>> ExecuteSP(string spname, string json, string user);
        Task<List<StatusResult>> ExecuteSPDelete(string spname, string id, string user);
        #endregion
    }
}
