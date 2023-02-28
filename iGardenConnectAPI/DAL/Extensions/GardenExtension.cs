using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class GardenExtension
    {
        public static Garden ToEntity(this GardenDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Garden
            {
                IdGarden = dto.IdGarden.Trim(),
                Name = dto.Name.Trim(),
                Watered = dto.Watered,
                LastWatered = dto.LastWatered,
                WateringDuration = dto.WateringDuration,
                IdPlant = dto.Plant.IdPlant,
              
           

            };
        }

        public static GardenDTO ToSmallDTO(this Garden entity)
        {


            if (entity is null)
            {
                return null;
            }

            return new GardenDTO
            {
                IdGarden = entity.IdGarden.Trim(),
                Name = entity.Name.Trim(),
                Watered = entity.Watered,
                LastWatered = entity.LastWatered,
                WateringDuration = entity.WateringDuration,
                Plant = new PlantDTO(),
                GardenSensors = new List<GardenSensorDTO>(),

        };
        }
        public static GardenDTO ToDTO(this Garden entity)
        {
            if (entity is null)
            {
                return null;
            }

            var dto = ToSmallDTO(entity);
            return dto;
        }
    }
}
