using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class UnitTypeModel
    {
        public Guid? unitTypeId { get; set; }
        public string unitTypeName { get; set; }
    }
}
