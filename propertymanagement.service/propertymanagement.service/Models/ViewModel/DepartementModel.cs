using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class DepartementModel
    {
        public Guid? departementId { get; set; }
        public string departementName { get; set; }
    }
}
