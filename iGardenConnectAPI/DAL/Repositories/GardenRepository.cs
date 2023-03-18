using DAL.Extensions;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<GardenDTO> Get()
        {

            return _dbcontext.Gardens.ToList().Select(g => g.ToSmallDTO()).ToList();
        }
        public IEnumerable<GardenDTO> Get(int idUser)
        {

            var gardens = _dbcontext.Gardens.ToList().Where(g => g.IdUser == idUser).ToList();
            IEnumerable<GardenDTO> gardensDTO = new List<GardenDTO>();
            foreach (Garden g in gardens)
            {

                Plant p = _dbcontext.Plants.FirstOrDefault(p => p.IdPlant == g.IdPlant);
                GardenDTO gDTO = g.ToDTO();
                gDTO.Plant = p.ToDTO();
                gardensDTO = gardensDTO.Concat(new[] { gDTO });
            }
            return gardensDTO;
        }

        public GardenDTO Get(string id)
        {
            Garden g = _dbcontext.Gardens.FirstOrDefault(g => g.IdGarden == id);
            Plant plant = _dbcontext.Plants.FirstOrDefault(p => p.IdPlant == g.IdPlant);
            GardenDTO gDTO = g.ToDTO();
            gDTO.Plant = plant.ToDTO();
            return gDTO;

        }
        public bool Add(GardenDTO dto, int idUser, int idPlant)
        {
            try
            {
                var entity = dto.ToEntity();
                entity.IdUser = idUser;
                entity.IdPlant = idPlant;

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

        #region PUT
        /// <summary>
        /// Add or update a plant into the database
        /// </summary>
        /// <param name="plantDTO">plant to add or update in the database</param>
        /// <returns>if the add or update went well</returns>

        public bool UpdateByName(GardenDTO gardenDTO, string name)
        {
            try
            {
                var entity = gardenDTO.ToEntity();
                entity.Name = name;
                _dbcontext.Update(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool UpdateByPlant(GardenDTO gardenDTO, int idPlant)
        {
            try
            {
                var entity = gardenDTO.ToEntity();
                entity.IdPlant = idPlant;
                _dbcontext.Update(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool UpdateByNamePlant(GardenDTO gardenDTO, string name, int idPlant)
        {
            try
            {
                var entity = gardenDTO.ToEntity();
                entity.Name = name;
                entity.IdPlant = idPlant;
                _dbcontext.Update(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
        public bool UpdateByWateringDuration(GardenDTO gardenDTO, int idSensor, int duration)
        {

            try
            {
                Garden g = _dbcontext.Gardens.FirstOrDefault(g => g.IdGarden == gardenDTO.IdGarden);
                var entity = gardenDTO.ToEntity();
                entity.IdUser = g.IdUser;
                entity.WateringDuration = duration;
                entity.LastWatered = DateTime.Today;
                _dbcontext.Update(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        #endregion
        public bool Remove(GardenDTO garden)
        {
            try
            {
                var entity = garden.ToEntity();

                if (_dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                }

                _dbcontext.Gardens.Remove(entity);

                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

    }
}
