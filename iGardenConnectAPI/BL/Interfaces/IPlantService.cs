using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IPlantService
    {
        public IEnumerable<PlantDTO> Get();
        public PlantDTO Get(int id);
        public bool Add(PlantDTO dto);

        public bool Update(PlantDTO plantDTO);
        public bool Remove(PlantDTO plant);
    }
}
