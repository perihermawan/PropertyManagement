using Microsoft.AspNetCore.SignalR;
using System;
using propertymanagement.service.Hubs;
using propertymanagement.service.Repositories;

namespace propertymanagement.service.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Property
        internal DatabaseContext Context;
        internal IHubContext<NotificationHub> HubContext;
        #region Repository
        private AuthenticationRepository AuthenticationRepositories;
        private UserAppRepository UserAppRepositories;
        private UserAccessRepository UserAccessRepositories;
        private DropdownRepository DropdownRepositories;
        private RoleRepository RoleRepositories;
        private ARPaymentRepository ARPaymentRepositories;
        private MenuRepository MenuRepositories;
        private MasterRepository MasterRepositories;
        private CommonRepository CommonRepositories;
        private UserManagementRepository UserManagementRepositories;
        private MarketingRepository MarketingRepositories;
        private ChargeRepository ChargeRepositories;

        #endregion


        #endregion

        #region Disposed
        public bool Disposing;

        private void DisposingProperties()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
        protected virtual void Disposed(bool _disposing)
        {
            if (!Disposing)
            {
                if (_disposing)
                {
                    DisposingProperties();
                }
            }
            Disposing = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Constructor
        public UnitOfWork(DatabaseContext _context, IHubContext<NotificationHub> _hubContext)
        {
            Context = _context;
            HubContext = _hubContext;
        }
        #endregion

        #region Controller
        public AuthenticationRepository UnitOfAuthenticationRepository()
        {
            if (AuthenticationRepositories == null)
            {
                AuthenticationRepositories = new AuthenticationRepository(Context);
            }
            return AuthenticationRepositories;
        }
        
        public UserAccessRepository UnitOfUserAccessRepository()
        {
            if (UserAccessRepositories == null)
            {
                UserAccessRepositories = new UserAccessRepository(Context);
            }
            return UserAccessRepositories;
        }
        public UserAppRepository UnitOfUserAppRepository()
        {
            if (UserAppRepositories == null)
            {
                UserAppRepositories = new UserAppRepository(Context, HubContext);
            }
            return UserAppRepositories;
        }
       
        public DropdownRepository UnitOfDropdownRepository()
        {
            if (DropdownRepositories == null)
            {
                DropdownRepositories = new DropdownRepository(Context);
            }
            return DropdownRepositories;
        }
        public RoleRepository UnitOfRoleRepository()
        {
            if (RoleRepositories == null)
            {
                RoleRepositories = new RoleRepository(Context);
            }
            return RoleRepositories;
        }

        public ARPaymentRepository UnitOfARPaymentRepository()
        {
            if (ARPaymentRepositories == null)
            {
                ARPaymentRepositories = new ARPaymentRepository(Context);
            }
            return ARPaymentRepositories;
        }

        public MenuRepository UnitOfMenuRepository()
        {
            if (MenuRepositories == null)
            {
                MenuRepositories = new MenuRepository(Context);
            }
            return MenuRepositories;
        }

        public MasterRepository UnitOfMasterRepository()
        {
            if (MasterRepositories == null)
            {
                MasterRepositories = new MasterRepository(Context);
            }
            return MasterRepositories;
        }

        public CommonRepository UnitOfCommonRepository()
        {
            if (CommonRepositories == null)
            {
                CommonRepositories = new CommonRepository(Context);
            }
            return CommonRepositories;
        }

        public UserManagementRepository UnitOfUserManagementRepository()
        {
            if (UserManagementRepositories == null)
            {
                UserManagementRepositories = new UserManagementRepository(Context);
            }
            return UserManagementRepositories;
        }

        public MarketingRepository UnitOfMarketingRepository()
        {
            if (MarketingRepositories == null)
            {
                MarketingRepositories = new MarketingRepository(Context);
            }
            return MarketingRepositories;
        }

        public ChargeRepository UnitOfChargeRepository()
        {
            if (ChargeRepositories == null)
            {
                ChargeRepositories = new ChargeRepository(Context);
            }
            return ChargeRepositories;
        }
        #endregion


    }
}
