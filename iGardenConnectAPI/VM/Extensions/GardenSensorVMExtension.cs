using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Extensions
{
    public static class GardenSensorVMExtension
    {
        public static GardenSensorVM ToVM(this GardenSensorDTO dto)
        {
            if (dto != null)
            {
                return new GardenSensorVM
                {
                    IdSensor = (int)dto.IdSensor,
                    Name = dto.Name,
                    Type = dto.Type,
                    Brand = dto.Brand,
                    Price = dto.Price,
                    Value = dto.Value,
                    State = dto.State,

                };
            }
            return null;
        }

        public static GardenSensorDTO ToDTO(this GardenSensorVM vm)
        {
            if (vm != null)
            {
                return new GardenSensorDTO
                {
                    
                    IdSensor = (int)vm.IdSensor,
                    Name = vm.Name,
                    Type = vm.Type,
                    Brand = vm.Brand,
                    Price = vm.Price,
                    Value = vm.Value,
                    State = vm.State,
                };
            }

            return null;
        }
    }
}
