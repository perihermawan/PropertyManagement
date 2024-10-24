using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class OwnerModel
    {
        public Guid? ownerId { get; set; }
        public string ownerName { get; set; }
    }
}
