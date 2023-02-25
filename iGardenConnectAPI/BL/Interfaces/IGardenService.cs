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
        public IEnumerable<GardenDTO> Get(int idUser);
        public GardenDTO GetByIdGarden(string id);
        public bool Add(GardenDTO gardenDTO, int idUser);


        public bool UpdateByName(GardenDTO gardenDTO, string name);
        public bool UpdateByNamePlant(GardenDTO gardenDTO, string name, int idPlant);

        public bool UpdateByPlant(GardenDTO gardenDTO, int idPlant);

        public bool Remove(GardenDTO gardenDTO);
    }
}
