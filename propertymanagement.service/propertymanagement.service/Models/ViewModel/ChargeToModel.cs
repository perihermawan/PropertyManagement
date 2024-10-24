using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class ChargeToModel
    {
        public Guid? chargeToId { get; set; }
        public string chargeToName { get; set; }
    }
}
