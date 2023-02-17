using DAL.Extensions;
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
        public bool Add(GardenDTO dto, int idUser, int idPlant)
        {
            try { 
                dto.IdUser = idUser;
                dto.IdPlant = idPlant;

                var entity = dto.ToEntity();
                _dbcontext.Add(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }

            return false;
        }

        //public static IEnumerable<GardenSensorDTO> GetGardenSensors(string idGarden)
       // {


        //}
        public IEnumerable<GardenDTO> Get()
        {

            return _dbcontext.Gardens.ToList().Select(g => g.ToSmallDTO()).ToList();
        }

        public GardenDTO Get(string id)
        {
            return _dbcontext.Gardens.FirstOrDefault(g => g.IdGarden == id).ToDTO();

        }

        public IEnumerable<GardenSensorDTO> GetGardenSensors(string idGarden)
        {
            return _dbcontext.GardenSensors.ToList().Where(s => s.IdGarden == idGarden).ToList().Select(s => s.ToDTO()).ToList();
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
