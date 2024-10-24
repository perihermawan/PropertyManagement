using System;

namespace propertymanagement.service.Models.ViewModel
{
    public class NonStandardChargeListViewModel
    {
        public Guid? rentId { get; set; }
        public string ksmNumber { get; set; }
        public string location { get; set; }
        public decimal? rentSquare { get; set; }
        public string outletName { get; set; }
        public string tenantName { get; set; }
        public string chargeFrom { get; set; }
        public string chargeTo { get; set; }
        public DateTime createDate { get; set; }
    }
}
