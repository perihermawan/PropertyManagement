﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Repositories.IRepositories
{
    public interface IDropdownRepository
    {
        //Task<dynamic> GetChargeCode();
        Task<dynamic> GetDDLLeaveRequest();
        Task<dynamic> GetDDLCompany();
        Task<dynamic> GetDDLRoles(string appName);
        Task<dynamic> GetDDLParam(string paramCode);

    }
}
