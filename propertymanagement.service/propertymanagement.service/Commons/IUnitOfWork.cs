using System;
using propertymanagement.service.Repositories;

namespace propertymanagement.service.Commons
{
    public interface IUnitOfWork : IDisposable
    {

        #region Master
        
        UserAccessRepository UnitOfUserAccessRepository();
        UserAppRepository UnitOfUserAppRepository();
        DropdownRepository UnitOfDropdownRepository();

        RoleRepository UnitOfRoleRepository();

        MenuRepository UnitOfMenuRepository();

        MasterRepository UnitOfMasterRepository();

       CommonRepository UnitOfCommonRepository();

        #endregion

        #region Transaction
        AuthenticationRepository UnitOfAuthenticationRepository();

        ARPaymentRepository UnitOfARPaymentRepository();

        UserManagementRepository UnitOfUserManagementRepository();


        #endregion

        #region Marketing

        MarketingRepository UnitOfMarketingRepository();

        #endregion

    }
}
