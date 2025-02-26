﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.ViewModel;

namespace propertymanagement.service.Models.DTO
{
    public class UserManagement
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string EmployeeNo { get; set; }
        public int CompId { get; set; }
        public string Module { get; set; }

        public List<ViewAccessMenuModel> permissionlist { get; set; }
    }
}
