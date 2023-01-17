using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DTO;

namespace BL
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepositoy _plantRepository;

        public PlantService(IPlantRepositoy plantRepository)
        {
            _plantRepository= plantRepository;
        }

        #region GET
        /// <summary>
        /// Get all plants
        /// </summary>
        /// <returns>List of all plants</returns>
        public IEnumerable<PlantDTO> Get()
        {
            return _plantRepository.Get();
        }

        /// <summary>
        /// Get a plant by id
        /// </summary>
        /// <returns>a plantDTO</returns>
        public PlantDTO Get(int id)
        {
            return _plantRepository.Get(id);
        }
        #endregion

        #region POST
        public bool Add(PlantDTO dto)
        {
            return _plantRepository.Add(dto);
        }
        #endregion

        #region PUT
        public bool Update(PlantDTO dto)
        {
            return _plantRepository.Update(dto);
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
            return _plantRepository.Remove(plant);
        }
        #endregion
    }
}