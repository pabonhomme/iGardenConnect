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
                    Value = vm.Value,
                    State = vm.State,
                };
            }

            return null;
        }
    }
}
