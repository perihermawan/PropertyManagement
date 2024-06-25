using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models;
using propertymanagement.service.Models.Master;

namespace propertymanagement.service.Repositories.IRepositories
{
    interface IAuthenticationRepository
    {
        UserAppModel GetByUserId(string userid);
    }
}
