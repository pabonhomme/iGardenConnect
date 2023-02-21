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
                IdGarden = dto.IdGarden,
                Name = dto.Name,
                Watered = dto.Watered,
                LastWatered = dto.LastWatered,
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
                IdGarden = entity.IdGarden,
                Name = entity.Name,
                Watered = entity.Watered,
                LastWatered = entity.LastWatered,
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
