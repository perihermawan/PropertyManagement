using System;

namespace propertymanagement.service.Models.ViewModel
{
    public class PaymentScheduleViewModel
    {
        public Guid? RentId { get; set; }
        public string KsmNumber { get; set; }
        public int KsmType { get; set; }
        public string PsmNumber { get; set; }
        public string LocationMap { get; set; }
        public decimal Square { get; set; }
        public string OutletName { get; set; }
        public string TenantOwner { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ChargeType { get; set; }
        public string Status { get; set; }

    }

    public class PaymentScheduleCustomerInfoViewModel
    {
        public Guid? ChargeId { get; set; }
        public Guid? RentId { get; set; }
        public Guid? ChargeTypeId { get; set; }
        public DateTime? ChargeDate { get; set; }
        public int Installment { get; set; }
        public decimal Square { get; set; }
        public decimal OutStandingAmount{ get; set; }
        public decimal BasicAmount{ get; set; }
        public decimal MagPortion{ get; set; }
        public decimal OmsetAmount { get; set; }
        public decimal AdditionalAmount { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal RentAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDeleted { get; set; }
        public string LocationMap { get; set; }
        public string ChargeType { get; set; }
        public string KsmNumber { get; set; }
        public string PsmNumber { get; set; }
        public decimal PeriodYear{ get; set; }
        public string TenantOwner { get; set; }
        public string OutletName { get; set; }
        public string UnitOwner { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsFoodCourt { get; set; }
        public int Editable { get; set; }
        public DateTime? ChargeDateFrom { get; set; }
        public DateTime? ChargeDateTo { get; set; }
        public string Description { get; set; }
        public DateTime? OmsetFrom { get; set; }
        public DateTime? OmsetTo { get; set; }

    }

}
