using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.ViewModel
{
    public class ViewModelEmployeeAvailability
    {
        public int ID { get; set; }
        public string NIK { get; set; }
        public string FULL_NAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
        public string AVAILABLE { get; set; }
    }
}
