using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class OutletTypeModel
    {
        public Guid? outletTypeId { get; set; }
        public string outletTypeName { get; set; }
    }
}
