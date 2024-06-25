using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.ViewModel
{
    public class ViewPermissionModel
    {
        public Guid ID { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ParentID { get; set; }
    }
}
