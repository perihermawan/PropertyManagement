using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertymanagement.service.Models.Master
{
    public class MapModel
    {
        public Guid MapId { get; set; }
        public string MapNumber { get; set; }

        public Guid BuildingID { get; set; }

        public string Floor { get; set; }

        public string Block { get; set; }

        public string Number { get; set; }

        public Guid UnitId { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string MapNumberOld { get; set; }


    }
}
