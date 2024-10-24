using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.ViewModel
{
    public class TenantMgtListModel
    {
        public Guid? ID { get; set; }
        public string mode { get; set; }
        public string LocationMap { get; set; }
        public decimal? Square { get; set; }
        public string? OutletName { get; set; }
        public string? Ownername { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string NUMBER { get; set; }
        public string? Types { get; set; }
    }
}
