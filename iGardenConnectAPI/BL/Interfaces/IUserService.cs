using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> Get();
        public UserDTO Get(int id);

        public UserDTO GetByLogin(string login);
        public UserDTO CheckCredentials(UserDTO user);

        public bool Add(UserDTO dto);
        public bool Update(UserDTO USERDTO);
        public bool Remove(UserDTO user);

    }
}
