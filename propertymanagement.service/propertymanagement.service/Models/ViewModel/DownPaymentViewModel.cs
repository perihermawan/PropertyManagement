using System;

namespace propertymanagement.service.Models.ViewModel
{
    public class DownPaymentViewModel
    {
        public Guid DownPaymentId { get; set; }
        public Guid? RentId { get; set; }
        public int PeriodDp { get; set; }
        public decimal DpAmount { get; set; }
        public decimal DpPPN { get; set; }
        public decimal DpTotal { get; set; }
        public DateTime DpDate { get; set; }
    }
}
