using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class GroupModel
    {
        public int ID { get; set; }
        public string GROUPNAME { get; set; }
        public string SUBGROUPID { get; set; }
        public string DIVISIONID { get; set; }
        public bool ISDELETED { get; set; }
        public bool ISACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DT { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DT { get; set; }
            
    }
}
