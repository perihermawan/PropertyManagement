using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class OutletListModel
    {
        public Guid? outletId { get; set; }
        public string outletName { get; set; }
    }
}
