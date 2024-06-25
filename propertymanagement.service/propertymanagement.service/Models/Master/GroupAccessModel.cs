using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class GroupAccessModel
    {
        public string ID { get; set; }
        public string MENUID { get; set; }
        public string GROUPID { get; set; }
        public string SUBGROUPID { get; set; }
        public string DIVISIONID { get; set; }
        public bool ISREAD { get; set; }
        public bool ISADD { get; set; }
        public bool ISEDIT { get; set; }
        public bool ISDELETE { get; set; }
        public bool ISDELETED { get; set; }
        public bool ISACTIVE { get; set; }
        public DateTime CREATED_BY { get; set; }
        public string CREATED_DT { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DT { get; set; }

    }
}
