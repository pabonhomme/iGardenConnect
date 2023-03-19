using DAL.Models;
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

        public IEnumerable<GardenDTO> Get();
        public IEnumerable<GardenDTO> Get(int idUser);
        public GardenDTO Get(string id);
        public ExistingGarden GetExistingGarden(string idGarden);
        public bool Add(GardenDTO dto, int idUser, int idPlant);
        public bool UpdateByName(GardenDTO gardenDTO, string name);
        public bool UpdateByPlant(GardenDTO gardenDTO, int idPlant);

        public bool UpdateByNamePlant(GardenDTO gardenDTO, string name, int idPlant);

        public bool UpdateByWateringDuration(GardenDTO gardenDTO, int idSensor, int duration);

        public bool UpdateWateringState(GardenDTO gardenDTO, int watered);
        public bool ActivateGarden(ExistingGarden eg, int active);
        public bool Remove(GardenDTO gardenDTO);
    }
}
