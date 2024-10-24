using System;

namespace propertymanagement.service.Models.ViewModel
{
    public class RentNonStandardListModel
    {
        public Guid RENTID { get; set; }
        public string PSMNUMBER { get; set; }
        public string KSMNUMBER { get; set; }
        public bool ISPULLOUT { get; set; }
        public bool ISCLOSING { get; set; }
        public DateTime? ClosingDate { get; set; }
        public object PullOutDate { get; set; }
        public string LocationMap { get; set; }
        public decimal Square { get; set; }
        public string OutletName { get; set; }
        public string UnitOwner { get; set; }
        public string TenantOwner { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? StatusDate { get; set; }
        public string chargetype { get; set; }
        public DateTime? HandOverDate { get; set; }
        public DateTime? ChargeDateFrom { get; set; }
        public DateTime? ChargeDateTo { get; set; }
        public DateTime? EndDateKSM { get; set; }
        public decimal RentAmount { get; set; }
        public int Installments { get; set; }
        public decimal TaxPersentage { get; set; }
        public int PeriodDay { get; set; }
        public int KSMType { get; set; }
        public int PeriodMonth { get; set; }
        public decimal OutstandingAmount { get; set; }
        public int DueDate { get; set; }
        public decimal PeriodYear { get; set; }

    }
}
