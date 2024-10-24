using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.ViewModel
{
    public class ViewParamTenantMgt
    {
        public Guid TenantMgtId { get; set; }
        public int PrmTenantMgtId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? SourceCode { get; set; }
        public string SubscriptionFee { get; set; }
        public string MaintenanceFee { get; set; }
        public string UsageFee1 { get; set; }
        public string UsageFee2 { get; set; }
        public string PpjPercentage { get; set; }
        public string AdmPercentage { get; set; }
        public string TaxPercentage { get; set; }
        public decimal DiscPercentage { get; set; }
        public int LumpSump { get; set; }
        public int MINIMUMAMOUNT { get; set; }
        public int TotPower { get; set; }
        public int Type { get; set; }
    }
}
