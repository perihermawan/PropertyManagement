﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class GroupListModel
    {
        public Guid? groupId { get; set; }
        public string groupName { get; set; }
    }
}
