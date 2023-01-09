using DAL.Models;
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
                
            };
        }
    }
}
