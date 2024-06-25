using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using propertymanagement.service.Helpers;
using propertymanagement.service.Models;
using propertymanagement.service.Models.Master;
using propertymanagement.service.Repositories.IRepositories;

namespace propertymanagement.service.Repositories
{
    public class AuthenticationRepository : DatabaseConfig, IAuthenticationRepository
    {
        #region Constructor
        public AuthenticationRepository() : base()
        {

        }
        public AuthenticationRepository(DatabaseContext context) : base(context)
        {

        }



        #endregion

        #region Service to database
        
        public UserAppModel GetByUserId(string userid)
        {
            var tuser = (from a in Context.dbset_M_UserApp
                         join b in Context.dbset_M_Employee on a.EmployeeNo equals b.EmployeeNo
                         where a.UserName == userid
                         select new UserAppModel
                         {
                             UserId = a.UserId,
                             EmployeeNo = a.EmployeeNo,
                             UserName = a.UserName,
                             Password = a.Password
                         }).FirstOrDefault();
            return tuser;
        }
        #endregion
    }
}
