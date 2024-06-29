using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System;
using System.Collections.Generic;

namespace propertymanagement.service.Models.Marketing
{
    public class NonStandardModel
    {
        // public Guid? formId { get; set; }

        public Guid? rentId { get; set; }
        public string? ksmNumber { get; set; }
        public string locationMap { get; set; }
        public decimal square { get; set; }
        public string outletName { get; set; }
        public string tenantOwner { get; set; }
        public DateTime? chargeDateFrom { get; set; }
        public DateTime? chargeDateTo { get; set; }
        public string remark { get; set; }
        public List<NonStandardItem> RowState { get; set; }
    }

    public class NonStandardItem
    {
        public DateTime dataForm { get; set; }
        public DateTime dataUntil { get; set; }
        public string description { get; set; }
        public double monthlyBasicChargeExc { get; set; }
        public double monthlyCharge { get; set; }
        public double annualChargeExc { get; set; }
        public double monthlyChargeInc { get; set; }
        public double annualChargeInc { get; set; }
        public double additionalCharge { get; set; }
    
    }
}
