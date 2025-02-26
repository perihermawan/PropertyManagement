﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace propertymanagement.service.Models.ViewModel
{
    public class RentUnitListModel
    {
        public Guid? UnitId { get; set; }
        public string MapNumber { get; set; }
        public decimal OrigSquare { get; set; }
        public decimal ExtSquare { get; set; }
        public decimal FacSquare { get; set; }
        public decimal RentSquare { get; set; }
        public string KwhMeter { get; set; }
        public string KwhMeter2 { get; set; }
        public string PamMeter { get; set; }
        public string GasMeter { get; set; }
        public decimal Power { get; set; }
        public int Phasa { get; set; }
        public int CTFactor { get; set; }
        public string pipeType { get; set; }
        public string pressureType { get; set; }
        public bool TelpFlag { get; set; }
        public string StatusDesc { get; set; }
        public string TitipSewaFlag { get; set; }
        public string OwnerName { get; set; }
    }

    public class RentUnitListEditModel
    {
        public Guid? UnitId { get; set; }
        public Guid? RentDid { get; set; }
        public string MapNumber { get; set; }
        public decimal OrigSquare { get; set; }
        public decimal ExtSquare { get; set; }
        public decimal FacSquare { get; set; }
        public decimal othrsSquare2 { get; set; }
        public string KwhMeter { get; set; }
        public string KwhMeter2 { get; set; }
        public string PamMeter { get; set; }
        public string PamMeter2 { get; set; }
        public string GasMeter { get; set; }
        public string GasMeter2 { get; set; }
        public decimal Power { get; set; }
        public decimal lastPower { get; set; }
        public int Phasa { get; set; }
        public int CTFactor { get; set; }
        public Guid? pipeTypeId { get; set; }
        public Guid? pressureTypeId { get; set; }
        public string pipeType { get; set; }
        public string pressureType { get; set; }
        public bool TelpFlag { get; set; }
    }
    public class RentTelpListEditModel
    {
        public Guid? TelpId { get; set; }
        public Guid? SourceId { get; set; }
        public string MapNumber { get; set; }
        public string TelpNumber { get; set; }
        public int TelpStatus { get; set; }
    }

    public class ListUnitTelpModel
    {
        public List<RentUnitListEditModel> Unit { get; set; }
        public List<RentTelpListEditModel> Telp { get; set; }
    }
}
