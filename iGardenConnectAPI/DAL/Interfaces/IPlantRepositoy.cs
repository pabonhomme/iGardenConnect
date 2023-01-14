using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPlantRepositoy
    {
        public IEnumerable<PlantDTO> Get();
        public PlantDTO Get(string id);
        public bool Add(PlantDTO dto);
        public bool Update(PlantDTO plantDTO);
        public bool Remove(PlantDTO plant);
    }
}
