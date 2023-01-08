﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Garden
    {
        public Garden()
        {
            GardenSensors = new HashSet<GardenSensor>();
            Users = new HashSet<User>();
        }

        public string IdGarden { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public DateTime? WateringDuration { get; set; }
        public short? Watered { get; set; }
        public DateTime? LastWatered { get; set; }
        public string IdPlant { get; set; }

        public virtual Plant IdPlantNavigation { get; set; }
        public virtual ICollection<GardenSensor> GardenSensors { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}