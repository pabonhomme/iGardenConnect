using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<UserDTO> Get();
        public UserDTO Get(int id);
        public bool Add(UserDTO dto);
        public bool Update(UserDTO userDTO);
        public bool Remove(UserDTO userDTO);
    }
}
