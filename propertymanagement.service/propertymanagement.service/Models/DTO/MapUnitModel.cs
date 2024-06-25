using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Models.Master;

namespace propertymanagement.service.Models.DTO
{
    public class MapUnitModel
    {
        public UnitModel unit { get; set; }
        public MapModel map { get; set; }
    }
}
