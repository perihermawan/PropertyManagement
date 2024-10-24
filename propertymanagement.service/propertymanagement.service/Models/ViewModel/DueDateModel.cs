using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class DueDateModel
    {
        public Guid? dueDateId { get; set; }
        public string dueDateName { get; set; }
    }
}
