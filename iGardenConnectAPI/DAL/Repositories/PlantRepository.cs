using DAL.Extensions;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
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
            using (var _dbcontext = dbcontext)
            {
                return _dbcontext.Plants.ToList().Select(p => p.ToDTO()).ToList();
            }
        }
        #endregion

    }
}
