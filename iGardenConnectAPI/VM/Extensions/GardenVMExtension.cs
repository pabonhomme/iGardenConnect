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
                    Price = dto.Price,
                    WateringDuration = dto.WateringDuration,
                    Watered = dto.Watered,
                    LastWatered = dto.LastWatered,
                    IdPlant = dto.IdPlant,
                    IdUser = dto.IdUser,
                    GardenSensors = (ICollection<SensorVM>)(dto.GardenSensors == null || dto.GardenSensors.Count() == 0 ? new List<SensorVM>() : dto.GardenSensors.Select(s => s.ToVM()).ToList()),

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
                    Price = vm.Price,
                    WateringDuration = vm.WateringDuration,
                    Watered = vm.Watered,
                    LastWatered = vm.LastWatered,
                    IdPlant = vm.IdPlant,
                    IdUser = vm.IdUser,
                    GardenSensors = vm.GardenSensors == null || vm.GardenSensors.Count() == 0 ? new List<SensorDTO>() : vm.GardenSensors.Select(s => s.ToDTO()).ToList(),
                };
            }

            return null;
        }
    }
}
