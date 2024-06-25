using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System;

namespace propertymanagement.service.Models.Marketing
{
    public class RentAmountModel
    {
        public Guid RentId { get; set; }
        public string KsmNumber { get; set; }
        public string Location { get; set; }
        public string OutletName { get; set; }
        public string TenantName { get; set; }
        public decimal Outstanding { get; set; }
        public int Installments { get; set; }
        public string ChargeType { get; set; }
    }

    public class DownPaymentModel
    {
        public Guid FormId { get; set; }
        public bool IsDeleted { get; set; }
        public DataRowState RowState { get; set; }
        public Guid DownPaymentId { get; set; }
        public int PeriodDp { get; set; }
        public decimal DpAmount { get; set; }
        public decimal DpPPN { get; set; }
        public decimal DpTotal { get; set; }
        public DateTime DpDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string DeleteUser { get; set; }
        public int InstStart { get; set; }
        public Guid InstId { get; set; }
    }
}
