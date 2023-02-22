using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class UserExtension
    {
        public static User ToEntity(this UserDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new User
            {
                IdUser = dto.IdUser,
                Name = dto.Name,
                Login = dto.Login,
                Role = dto.Role,
                Password = dto.Password,

            };
        }

        public static UserDTO ToDTO(this User entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new UserDTO
            {
                IdUser = entity.IdUser,
                Name = entity.Name,
                Login = entity.Login,
                Role = entity.Role,
                Password = entity.Password,
            };
        }
    }
}
