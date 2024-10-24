using Newtonsoft.Json;
using System.Data;
using System;

namespace propertymanagement.service.Models.Marketing
{
    public class StandardItemModel
    {
        public Guid? FormId { get; set; }
        public Guid? RentId { get; set; }

        [JsonProperty("PeriodFrom")]
        public DateTime PeriodFrom { get; set; }

        [JsonProperty("PeriodTo")]
        public DateTime PeriodTo { get; set; }

        [JsonProperty("FormDescription")]
        public string FormDescription { get; set; }

        [JsonProperty("BasicAmount")]
        public decimal BasicAmount { get; set; }

        [JsonProperty("AdditionalAmount")]
        public decimal AdditionalAmount { get; set; }

        [JsonProperty("ChargeAmount")]
        public decimal ChargeAmount { get; set; }

        [JsonProperty("ChargeAmountInPeriod")]
        public decimal ChargeAmountInPeriod { get; set; }

        [JsonProperty("BasicAmountInc")]
        public decimal BasicAmountInc { get; set; }

        [JsonProperty("ChargeAmountInPeriodInc")]
        public decimal ChargeAmountInPeriodInc { get; set; }
    }
}
