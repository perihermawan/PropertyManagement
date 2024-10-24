using propertymanagement.service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.Marketing;
using propertymanagement.service.Models;

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

        #region Deposit
        Task<List<DepositViewModel>> GetDepositList();
        Task<List<DepositRentViewModel>> GetRentForDepositDataAll();
        Task<List<DepositDetailViewModel>> GetDepositByRentId(string rentId);

        #endregion


        #region Pull Out
        Task<List<PullOutViewModel>> GetPullOutList();
        Task<PullOutRentViewModel> GetRent(Guid rentId);
        Task<PullOutDetailViewModel> GetPullOutDetail(Guid rentId);
        #endregion

        #region Payment Schedule
        Task<List<PaymentScheduleViewModel>> GetPaymentScheduleList(string _field, string _operator, string _value, string _mode);
        Task<List<PaymentScheduleCustomerInfoViewModel>> GetCustomerInfoListByRentId(string rentId, int ksmType);
        #endregion

        #region Management Fee and utility
        Task<List<TenantMgtListModel>> GetMFList();
        Task<List<ViewTenantMgtRentModel>> GetMFDetailByRentId(string sourceId);
        Task<List<ViewTenantMgtSalesModel>> GetMFDetailBySalesId(string sourceId);
        Task<List<TenantMgtRentListModel>> GetMFRentList();
        Task<List<TenantMgtSalesListModel>> GetMFSalesList();
        Task<List<ViewParamTenantMgt>> GetParamTenantMgtList(int plnNode, int pamNode, int gasNode, Guid sourceId, string sourceCode);
        Task<List<StatusResult>> DeleteMfByMfId(Guid sourceId, string userId);
        Task<List<StatusResult>> DeleteMfItemByTenantMgtId(Guid tenantMgtId, string userId);

        #endregion

        #region Revenue Sharing
        Task<List<RevenueSharingChargeViewModel>> GetRevenueSharingChargeList(string type, string _field, string _operator, string _value);
        Task<List<RsChargeFlatItemViewModel>> GetRentForRSFlatDataAll();
        Task<List<RsChargeProgressiveItemViewModel>> GetRentForRSProgDataAll();
        Task<List<RsChargeFlatFormViewModel>> GetRsChargeFlatByRentId(string rentId);
        Task<List<RsChargeProgressiveFormViewModel>> GetRsChargeProgByRentId(string rentId);

        #endregion
    }
}