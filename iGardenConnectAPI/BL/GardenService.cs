using BL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GardenService : IGardenService
    {
        private readonly IGardenRepository _gardenRepository;

        public GardenService(IGardenRepository gardenRepository)
        {
            _gardenRepository = gardenRepository;
        }

        public bool Add(GardenDTO dto)
        {
            return _gardenRepository.Add(dto);
        }

        public IEnumerable<GardenDTO> Get()
        {
           return _gardenRepository.Get();
        }

        public GardenDTO Get(int id)
        {
            return _gardenRepository.Get(id);
        }

        public bool Remove(GardenDTO plant)
        {
            throw new NotImplementedException();
        }

        public bool Update(GardenDTO plantDTO)
        {
            throw new NotImplementedException();
        }
    }
}
