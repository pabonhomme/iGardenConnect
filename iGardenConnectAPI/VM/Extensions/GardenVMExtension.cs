using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Extensions
{
    public static class GardenVMExtension
    {
        public static GardenVM ToVM(this GardenDTO dto)
        {
            if (dto != null)
            {
                return new GardenVM
                {
                    IdGarden = dto.IdGarden,
                    Name = dto.Name,
                    Watered = dto.Watered,
                    LastWatered = dto.LastWatered,
                    Plant = dto.Plant == null ? new PlantVM() : dto.Plant.ToVM(),
                    GardenSensors = (dto.GardenSensors == null || dto.GardenSensors.Count() == 0 ? new List<GardenSensorVM>() : dto.GardenSensors.Select(s => s.ToVM()).ToList()),

                };
            }
            return null;
        }

        public static GardenDTO ToDTO(this GardenVM vm)
        {
            if (vm != null)
            {
                return new GardenDTO
                {
                    IdGarden = vm.IdGarden,
                    Name = vm.Name,
                    Watered = vm.Watered,
                    LastWatered = vm.LastWatered,
                    Plant = vm.Plant == null ? new PlantDTO() : vm.Plant.ToDTO(),
                    GardenSensors = vm.GardenSensors == null || vm.GardenSensors.Count() == 0 ? new List<GardenSensorDTO>() : vm.GardenSensors.Select(s => s.ToDTO()).ToList(),
                };
            }

            return null;
        }
    }
}
