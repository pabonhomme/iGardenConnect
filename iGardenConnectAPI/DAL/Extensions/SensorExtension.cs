using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class SensorExtension
    {
        public static Sensor ToEntity(this SensorDTO dto, int action)
        {
            if (dto is null)
            {
                return null;
            }

            var sensor = new Sensor()
            {
                
                Name = dto.Name.Trim(),
                Type = dto.Type.Trim(),
                Brand = dto.Brand.Trim(),
                Price = dto.Price.Trim(),
            };
            if(action == 1) //if update
            {
                sensor.IdSensor = dto.IdSensor;

            }
            return sensor;
        }
        public static SensorDTO ToDTO(this Sensor entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new SensorDTO
            {
                IdSensor = (int)entity.IdSensor,
                Name = entity.Name.Trim(),
                Type = entity.Type.Trim(),
                Brand = entity.Brand.Trim(),
                Price= entity.Price.Trim(),
            };
        }
    }
}
