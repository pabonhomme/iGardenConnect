using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Extensions
{
    public static class GardenSensorExtension
    {
        public static GardenSensor ToEntity(this GardenSensorDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new GardenSensor
            {
               
                IdSensor = (int)dto.IdSensor,
                Value = dto.Value.Trim(),
                State = dto.State.Trim(),
                
            };
        }

        public static GardenSensorDTO ToDTO(this GardenSensor entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new GardenSensorDTO
            {
               
                IdSensor = entity.IdSensor,
                Value = entity.Value.Trim(),
                State = entity.State.Trim(),
            };
        }
    
    }
}
