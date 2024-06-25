using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace propertymanagement.service.Models.Master
{
    public class OutletModel
    {
		[Key]
		public Guid OutletId { get; set; }
		public string OutletName { get; set; }
		public Guid LobId { get; set; }
		public string SubLOB { get; set; }
		public bool? IsDeleted { get; set; }
		public string CreateUser { get; set; }
		public DateTime? CreateDate { get; set; }
		public string UpdateUser { get; set; }
		public DateTime? UpdateDate { get; set; }
		public string DeleteUser { get; set; }
		public DateTime? DeleteDate { get; set; }
    }
}
