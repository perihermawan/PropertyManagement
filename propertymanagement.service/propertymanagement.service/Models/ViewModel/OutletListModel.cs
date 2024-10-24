using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class OutletListModel
    {
        public Guid? OutletId { get; set; }
        public string OutletName { get; set; }
        public string OutletTypeName { get; set; }
        public Guid? lobId { get; set; }
        public string lobname { get; set; }
        public string subLob { get; set; }
    }
}
