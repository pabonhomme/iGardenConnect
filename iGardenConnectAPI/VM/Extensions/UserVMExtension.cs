using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Extensions
{
    public static class UserVMExtension
    {
        public static UserVM ToVM(this UserDTO dto)
        {
            if (dto != null)
            {
                return new UserVM
                {
                    IdUser = dto.IdUser,
                    Name = dto.Name,
                    Username = dto.Username,
                    Login = dto.Login,
                    Role = dto.Role,
                };
            }
            return null;
        }

        public static UserDTO ToDTO(this UserVM vm)
        {
            if (vm != null)
            {
                return new UserDTO
                {
                    IdUser = vm.IdUser,
                    Name = vm.Name,
                    Username = vm.Username,
                    Login = vm.Login,
                    Role = vm.Role,
                };
            }

            return null;
        }
    }
}
