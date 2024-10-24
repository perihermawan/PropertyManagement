using Microsoft.EntityFrameworkCore;
using propertymanagement.service.Models;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Commons
{ 

    public class DatabaseContext : DbContext
    {
        #region Depenency Injection
        public DbContextOptions<DatabaseContext> options;

        #endregion

        #region DbSet Model

        #region Master
        public DbSet<EmployeeModel> dbset_M_Employee { get; set; }
        public DbSet<EmployeeAccountModel> dbset_M_EmployeeAccount { get; set; }
        public DbSet<BuildingModel> dbset_M_Building { get; set; }
        public DbSet<GroupAccessModel> dbset_M_GroupAccess { get; set; }
        public DbSet<GroupModel> dbset_M_Group { get; set; }
        public DbSet<MenuModel> dbset_M_Menu { get; set; }
        public DbSet<UserAccessModel> dbset_M_UserAccess { get; set; }
        public DbSet<UserAppModel> dbset_M_UserApp { get; set; }
        public DbSet<LeaveTypeModel> dbset_M_LeaveType { get; set; }
        public DbSet<RoleModel> dbset_Role { get; set; }
        public DbSet<RentVoucherListModel> dbset_VW_RentVoucherList { get; set; }
        public DbSet<PermissionModel> dbset_M_Permission { get; set; }
        public DbSet<PermissionModel> dbset_M_UserFormAccess { get; set; }

        public DbSet<ViewUnitModel> dbset_VW_MsUnit { get; set; }
        public DbSet<UserListModel> dbset_VW_MsUser { get; set; }

        public DbSet<ViewEmployeeModel> dbset_VW_MsEmployee { get; set; }


        #endregion

        #region Management Fee and utility
        public DbSet<TenantMgtListModel> dbset_VW_FRMTENANTMGTLIST { get; set; }
        #endregion

        #endregion


        #region Constructor
        public DatabaseContext() : base()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options)
        {
            options = _options;
        }

        #endregion

        #region Creating Model
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<RoleModel>()
                    .ToTable("MsRoles")
                        .HasKey(m => new
                        {
                            m.RoleId
                        });
            builder
               .Entity<MenuModel>()
                   .ToTable("MsMenuPM")
                       .HasKey(m => new
                       {
                           m.ID
                       });
            builder
               .Entity<MenuGroupModel>()
                   .ToTable("MsMenuPMGroup")
                       .HasKey(m => new
                       {
                           m.ID
                       });
            builder
               .Entity<PermissionModel>()
                   .ToTable("MsPermission")
                       .HasKey(m => new
                       {
                           m.ID
                       });
            builder
                .Entity<UserAppModel>()
                    .ToTable("MsUsers")
                        .HasKey(m => new
                        {
                            m.UserId
                        });
            builder
                .Entity<EmployeeModel>()
                    .ToTable("M_Employee")
                        .HasKey(m => new
                        {
                            m.EmployeeID
                        });
            builder
                .Entity<BuildingModel>()
                    .ToTable("MsBuilding")
                        .HasKey(m => new
                        {
                            m.BuildingId
                        });
            builder
                .Entity<PermissionModel>()
                    .ToTable("MsPermission")
                        .HasKey(m => new
                        {
                            m.ID
                        });
            builder
                .Entity<UserFormAccessModel>()
                    .ToTable("MsUserFormAccess")
                        .HasKey(m => new
                        {
                            m.ID
                        });
            builder
               .Entity<RentVoucherListModel>()
               .HasNoKey()
                   .ToView("vw_RentVoucherList");

            builder
              .Entity<ViewUnitModel>()
              .HasNoKey()
                  .ToView("vw_MsUnit");
            builder
              .Entity<UserListModel>()
              .HasNoKey()
                  .ToView("vw_MsUserList");
            builder
              .Entity<ViewEmployeeModel>()
              .HasNoKey()
                  .ToView("vw_MsEmployeeList");
            //builder
            //   .Entity<UnitListModel>()
            //       .ToView("vw_MsUnit");
            //builder
            //    .Entity<EmployeeModel>()
            //        .ToTable("TM_EMPLOYEE")
            //            .HasKey(m => new
            //            {
            //                m.ID
            //            });


            base.OnModelCreating(builder);
        }
        #endregion


    }

}