﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class PressureTypeModel
    {
        public Guid? pressureTypeId { get; set; }
        public string pressureTypeName { get; set; }
    }
}
