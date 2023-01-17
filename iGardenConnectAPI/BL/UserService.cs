using BL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Add(UserDTO dto)
        {
            throw new NotImplementedException();
        }


        #region GET
        /// <summary>
        /// Get all plants
        /// </summary>
        /// <returns>List of all plants</returns>
        public IEnumerable<UserDTO> Get()
        {
            return _userRepository.Get();
        }

        public UserDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO USERDTO)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
