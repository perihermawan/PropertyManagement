using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class RentPullOutListListModel
    {
        public Guid? RentId { get; set; }
        public string KSMNumber { get; set; }
        public string PSMNumber { get; set; }
        public string LocationMap { get; set; }
        public decimal? Square { get; set; }
        public Guid? OutletId { get; set; }
        public string OutletName { get; set; }
        public Guid? OutletTypeId { get; set; }
        public string OutletType { get; set; }
        public bool IsFoodCourt { get; set; }
        public Guid? LobId { get; set; }
        public string VirtualAccountRent { get; set; }
        public string VirtualAccountMFUtl { get; set; }
        public string UnitOwner { get; set; }
        public string TenantOwner { get; set; }
        public string Status { get; set; }
    }
}
