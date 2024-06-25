using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.ViewModel
{
    public class ViewAccessMenuModel
    {
        public Guid id { get; set; }
        public Guid parentid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }

    }
}
