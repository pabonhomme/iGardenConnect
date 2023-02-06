using DAL.Interfaces;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GardenRepository : IGardenRepository
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public GardenRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Add(GardenDTO dto)
        {
            throw new NotImplementedException();
        }

        //public static IEnumerable<GardenSensorDTO> GetGardenSensors(string idGarden)
       // {


        //}
        public IEnumerable<GardenDTO> Get()
        {
            throw new NotImplementedException();
        }

        public GardenDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GardenSensorDTO> GetGardenSensors(string idGarden)
        {
            throw new NotImplementedException();
        }

        public bool Remove(GardenDTO garden)
        {
            throw new NotImplementedException();
        }

        public bool Update(GardenDTO gardenDTO)
        {
            throw new NotImplementedException();
        }
    }
}
