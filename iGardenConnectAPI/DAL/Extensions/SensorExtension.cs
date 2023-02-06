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
        public static Sensor ToEntity(this SensorDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Sensor
            {
                IdSensor = dto.Reference,
                Name = dto.Name,
                Type = dto.Type,
                Brand = dto.Brand,
                Price = dto.Price,
            };
        }
        public static SensorDTO ToDTO(this Sensor entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new SensorDTO
            {
                Reference = entity.IdSensor,
                Name = entity.Name,
                Type = entity.Type,
                Brand = entity.Brand,
                Price= entity.Price,
            };
        }
    }
}
