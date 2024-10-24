using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class TenantModel
    {
        public Guid? tenantId { get; set; }
        public string tenantName { get; set; }
    }
}
