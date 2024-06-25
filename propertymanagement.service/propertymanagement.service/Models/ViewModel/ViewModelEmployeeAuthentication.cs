using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.ViewModel
{
    public class ViewModelEmployeeAuthentication
    {
        public int Id { get; set; }
        public string DIVISIONID { get; set; }
        public string FULL_NAME { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string USERPPWD { get; set; }
        public string TOKEN { get; set; }
        public string EMPLOYEEBASICINFOID { get; set; }
        public string ALIASNAME { get; set; }
        public List<ViewMenuModel> MENULIST { get; set; }
        public List<ViewPermissionModel> PERMISSIONLIST { get; set; }
    }
}
