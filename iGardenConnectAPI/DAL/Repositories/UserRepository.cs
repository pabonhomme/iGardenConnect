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
    public class UserRepository : IUserRepository
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public UserRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool Add(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        #region GET
        /// <summary>
        /// Returns all the users in the database
        /// </summary>
        /// <returns>IEnumerable<PlantDTO></returns>
        public IEnumerable<UserDTO> Get()
        {

            return _dbcontext.Users.ToList().Select(p => p.ToDTO()).ToList();
        }

        public UserDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
