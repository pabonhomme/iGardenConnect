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
                   
                };
            }
            return null;
        }

        public static PlantDTO ToDTO(this PlantVM entity)
        {
            if (entity != null)
            {
                return new PlantDTO
                {
                    
                };
            }

            return null;
        }
    }
}
