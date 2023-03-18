using Azure.Core;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers; // Required for creating cookie header values
using Microsoft.Extensions.Primitives;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using BL.utils;

namespace BL
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            return _userRepository.Get(id);
        }

        public UserDTO GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }

        public bool Add(UserDTO dto)
        {
            return _userRepository.Add(dto);
        }

        public bool Update(UserDTO userDTO)
        {
            return _userRepository.Update(userDTO);
        }
        public bool Remove(UserDTO user)
        {
            return _userRepository.Remove(user);
        }

        public UserDTO CheckCredentials(UserDTO user)
        {
            return _userRepository.CheckCredentials(user);
        }
        
        public UserDTO GetUserFromToken(string token)
        {
            UserDTO userDTO = null;
            bool isValidated = Auth.ValidateToken(token);

            if(isValidated)
            {
               var idUser = Auth.DecodeJwtToken(token);
               userDTO = Get(int.Parse(idUser));
            }
            return userDTO;
        }

        



        #endregion


    }
}
