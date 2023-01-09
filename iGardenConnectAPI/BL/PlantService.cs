using DAL.Models;
using DAL.Repositories;
using DTO;

namespace BL
{
    public static class PlantService
    {
        #region GET
        /// <summary>
        /// Get all plants
        /// </summary>
        /// <returns>List of all plants</returns>
        public static IEnumerable<PlantDTO> Get(iGardenConnectDBContext dbcontext)
        {
            return PlantRepository.Get(dbcontext);
        }

        /// <summary>
        /// Get a plant by id
        /// </summary>
        /// <returns>a plantDTO</returns>
        public static PlantDTO Get(iGardenConnectDBContext dbcontext, string id)
        {
            return PlantRepository.Get(dbcontext, id);
        }
        #endregion
    }
}