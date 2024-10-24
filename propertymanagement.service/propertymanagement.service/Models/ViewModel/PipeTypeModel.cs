using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class PipeTypeModel
    {
        public Guid? pipeTypeId { get; set; }
        public string pipeTypeName { get; set; }
    }
}
