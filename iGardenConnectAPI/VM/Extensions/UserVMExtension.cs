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
                    Login = dto.Login,
                    Role = dto.Role,
                    Password = dto.Password,
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
                    Login = vm.Login,
                    Role = vm.Role,
                    Password = vm.Password,

                };
            }

            return null;
        }
    }
}
