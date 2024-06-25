using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class UserFormAccessModel
    {
        public Guid ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PermissionID { get; set; }
        public Guid? ParentID { get; set; }


    }
}
