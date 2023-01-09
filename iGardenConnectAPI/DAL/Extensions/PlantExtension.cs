﻿using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class PlantExtension
    {
        public static Plant ToEntity(this PlantDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Plant
            {
                IdPlant = dto.IdPlant,
                Name = dto.Name,
                Species = dto.Species,
                WateringInterval = dto.WateringInterval,
            };
        }

        public static PlantDTO ToDTO(this Plant entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new PlantDTO
            {
                IdPlant = entity.IdPlant,
                Name = entity.Name,
                Species = entity.Species,
                WateringInterval = entity.WateringInterval,
            };
        }
    }
}
