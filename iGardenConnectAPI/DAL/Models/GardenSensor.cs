﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class GardenSensor
    {
        public string IdGarden { get; set; }
        public string IdSensor { get; set; }
        public string Value { get; set; }
        public string State { get; set; }

        public virtual Garden IdGardenNavigation { get; set; }
        public virtual Sensor IdSensorNavigation { get; set; }
    }
}