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
        /// <summary>
        /// Generate a cookie linked to a user
        /// </summary>
        /// <param name="idUser">the id user associated to the cookie </param>
        /// <returns></returns>
        public Cookie GenerateCookie(int idUser)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var secretKey = "your_secret_key_here";

            // Create the token with the secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("idUser", idUser.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateEncodedJwt(tokenDescriptor);

            // Create the cookie and set the JWT token as the value
            var cookie = new Cookie("session-token", token);
            cookie.Expires = DateTime.UtcNow.AddDays(1);

            return cookie;

        }

        public bool ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var secretKey = "your_secret_key_here";

            try
            {
                // Validate the token
                handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true, // Enable lifetime validation
                    ClockSkew = TimeSpan.Zero // Set clock skew to zero to validate expiration exactly
                }, out SecurityToken validatedToken);
                // Check if the token has expired
                if (validatedToken != null && validatedToken.ValidTo < DateTime.UtcNow)
                {
                    // Token has expired
                    return false;
                }

                // Token is valid
                return true;
            }
            catch (Exception)
            {
                // Token is not valid
                return false;
            }
        }
        public UserDTO GetUserFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public string DecodeJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Get the claims from the decoded token
            var claims = jwtToken.Claims;

            // Extract the value of a specific claim
            var idUser = claims.FirstOrDefault(c => c.Type == "idUser")?.Value;

            // Return the decoded token or a specific claim value
            return idUser;
        }



        #endregion


    }
}
