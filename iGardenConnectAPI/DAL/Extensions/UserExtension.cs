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
                Login = dto.Login.Trim(),
                Role = dto.Role.Trim(),
                Password = dto.Password.Trim(),

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
                Login = entity.Login.Trim(),
                Role = entity.Role.Trim(),
                Password = entity.Password.Trim(),
            };
        }
    }
}
