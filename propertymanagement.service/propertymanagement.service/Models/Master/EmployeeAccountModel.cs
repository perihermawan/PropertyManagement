using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class EmployeeAccountModel
    {
        [Key]
        public int ID { get; set; }
        public int IDEMPLOYEE { get; set; }
        public string ALIASNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }

    }
}
