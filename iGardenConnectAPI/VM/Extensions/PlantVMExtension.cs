using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Extensions
{
    public static class PlantVMExtension
    {
        public static PlantVM ToVM(this PlantDTO dto)
        {
            if (dto != null)
            {
                return new PlantVM
                {
                    IdPlant = dto.IdPlant,
                    Name = dto.Name,
                    Species = dto.Species,
                    OptimalTemperature = dto.OptimalTemperature,
                    SoilMoisture = dto.SoilMoisture,
                    AirMoisture = dto.AirMoisture,
                    Light = dto.Light,
                };
            }
            return null;
        }

        public static PlantDTO ToDTO(this PlantVM vm)
        {
            if (vm != null)
            {
                return new PlantDTO
                {
                    IdPlant = vm.IdPlant,
                    Name = vm.Name,
                    Species = vm.Species,
                    OptimalTemperature = vm.OptimalTemperature,
                    SoilMoisture = vm.SoilMoisture,
                    AirMoisture = vm.AirMoisture,
                    Light = vm.Light,
                };
            }

            return null;
        }
    }
}
