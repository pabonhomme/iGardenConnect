using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
     public interface IGardenRepository
    {
        public IEnumerable<GardenSensorDTO> GetGardenSensors(string idGarden);

        public IEnumerable<GardenDTO> Get();
        public GardenDTO Get(string id);
        public bool Add(GardenDTO dto, int idUser, int idPlant);
        public bool Update(GardenDTO gardenDTO);
        public bool Remove(GardenDTO garden);
    }
}
