using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class RentListModel
    {
        public Guid? rentId { get; set; }
        public string ksmNumber { get; set; }
        public string location { get; set; }
        public decimal? rentSquare { get; set; }
        public string outletName { get; set; }
        public string tenantName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string status { get; set; }
    }
}
