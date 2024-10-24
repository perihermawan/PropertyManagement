using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class KeteranganModel
    {
        public Guid? keteranganId { get; set; }
        public string keteranganName { get; set; }
    }
}
