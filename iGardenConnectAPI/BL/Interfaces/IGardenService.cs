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

        public GardenDTO Get(string id);
        public bool Add(GardenDTO gardenDTO, int idUser, int idPlant);
        public bool Update(GardenDTO plantDTO);
        public bool Remove(GardenDTO plant);
    }
}
