    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string Rolename { get; set; }
        public string ApplicationName { get; set; }
    }
}
