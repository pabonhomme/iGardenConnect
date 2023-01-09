using DAL.Extensions;
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
    public static class PlantRepository
    {
        #region GET
        /// <summary>
        /// Returns all the plants in the database
        /// </summary>
        /// <returns>IEnumerable<PlantDTO></returns>
        public static IEnumerable<PlantDTO> Get(iGardenConnectDBContext dbcontext)
        {

             return dbcontext.Plants.ToList().Select(p => p.ToDTO()).ToList();
        }

        
        /// <summary>
        /// Returns a plant with a id
        /// </summary>
        /// <returns>PlantDTO</returns>
        public static PlantDTO Get(iGardenConnectDBContext dbcontext, string id)
        {
            
             return dbcontext.Plants.FirstOrDefault(p => p.IdPlant == id).ToDTO();
            
        }
        #endregion

        #region PUT
        /// <summary>
        /// Add or update a plant into the database
        /// </summary>
        /// <param name="plantDTO">plant to add or update in the database</param>
        /// <returns>if the add or update went well</returns>
        public static bool AddOrUpdate(iGardenConnectDBContext dbcontext, PlantDTO plantDTO)
        {
            try
            {
                var entity = plantDTO.ToEntity();
                dbcontext.AddOrUpdate(entity);
                dbcontext.SaveChanges();
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
        public static bool Remove(iGardenConnectDBContext dbcontext, PlantDTO plant)
        {
            try
            {
                var entity = plant.ToEntity();

                if (dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    dbcontext.Entry(entity).State = EntityState.Modified;
                }

                dbcontext.Plants.Remove(entity);

                dbcontext.SaveChanges();
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
