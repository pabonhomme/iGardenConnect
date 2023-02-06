using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Extensions
{
    public static class SensorVMExtension
    {
        public static SensorVM ToVM(this SensorDTO dto)
        {
            if (dto != null)
            {
                return new SensorVM
                {
                    IdSensor = dto.Reference,
                    Name = dto.Name,
                    Type = dto.Type,
                    Brand = dto.Brand, 
                    Price = dto.Price,
                };
            }
            return null;
        }

        public static SensorDTO ToDTO(this SensorVM vm)
        {
            if (vm != null)
            {
                return new SensorDTO
                {
                    Reference = vm.IdSensor,
                    Name = vm.Name,
                    Type = vm.Type,
                    Brand = vm.Brand,
                    Price = vm.Price,
                };
            }

            return null;
        }
    }
}
