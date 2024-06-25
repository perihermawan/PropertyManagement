using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class LeaveTypeModel
    {
        public int ID { get; set; }
        public string LEAVE_TYPE_CD { get; set; }
        public string LEAVE_TYPE_NAME { get; set; }
        public string CHARGE_CD { get; set; }
        public bool IS_LEAVE_FULLDAY { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DT { get; set; }
    }
}
