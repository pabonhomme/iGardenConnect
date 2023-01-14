using DAL.Extensions;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlantRepository : IPlantRepositoy
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public PlantRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region GET
        /// <summary>
        /// Returns all the plants in the database
        /// </summary>
        /// <returns>IEnumerable<PlantDTO></returns>
        public IEnumerable<PlantDTO> Get()
        {

             return _dbcontext.Plants.ToList().Select(p => p.ToDTO()).ToList();
        }

        
        /// <summary>
        /// Returns a plant with a id
        /// </summary>
        /// <returns>PlantDTO</returns>
        public PlantDTO Get(string id)
        {
            
             return _dbcontext.Plants.FirstOrDefault(p => p.IdPlant == id).ToDTO();
            
        }
        #endregion

        #region PUT
        /// <summary>
        /// Add a plant into the database
        /// </summary>
        /// <param name="plantDTO">plant to add in the database</param>
        /// <returns>if the add went well</returns>
        public bool Add(PlantDTO plantDTO)
        {
            try
            {
                var entity = plantDTO.ToEntity();
                _dbcontext.Add(entity);
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

        #region PUT
        /// <summary>
        /// Add or update a plant into the database
        /// </summary>
        /// <param name="plantDTO">plant to add or update in the database</param>
        /// <returns>if the add or update went well</returns>
        public bool Update(PlantDTO plantDTO)
        {
            try
            {
                var entity = plantDTO.ToEntity();
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

        #region DELETE
        /// <summary>
        /// Remove a plant
        /// </summary>
        /// <param name="plant"> the plant to delete</param>
        /// <returns>Boolean indicating if the deletion went well</returns>
        public bool Remove(PlantDTO plant)
        {
            try
            {
                var entity = plant.ToEntity();

                if (_dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                }

                _dbcontext.Plants.Remove(entity);

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

    }
}
