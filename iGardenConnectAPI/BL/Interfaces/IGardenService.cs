using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IGardenService
    {
        public IEnumerable<GardenDTO> Get();
        public GardenDTO Get(int id);
        public bool Add(GardenDTO dto);
        public bool Update(GardenDTO plantDTO);
        public bool Remove(GardenDTO plant);
    }
}
