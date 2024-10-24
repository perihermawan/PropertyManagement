using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class RentChargeStandardListModel
    {
        public Guid? rentId { get; set; }
        public string ksmNumber { get; set; }
        public string location { get; set; }
        public decimal? rentSquare { get; set; }
        public string outletName { get; set; }
        public string tenantName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }
    }
}
