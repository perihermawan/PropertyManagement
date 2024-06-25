using propertymanagement.service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using propertymanagement.service.Models.Marketing;
using propertymanagement.service.Models;
using propertymanagement.service.Models.ViewModel;
using propertymanagement.service.Models;
using propertymanagement.service.Models.DTO;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IMarketingRepository
    {
        #region Rent Amount

        Task<List<RentAmountModel>> GetRentAmountList();
        Task<RentAmountViewModel> GetRentAmountDetail(string Param);
        Task<List<DownPaymentViewModel>> GetDownPaymentList();
        Task<List<StatusResult>> DeleteRentAmountByRentId(Guid unitId, string userId, string reason);

        #endregion

        #region Rent
        Task<List<RentListModel>> GetRentList();
        #endregion
    }
}
