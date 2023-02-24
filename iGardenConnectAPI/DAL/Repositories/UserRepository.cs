using DAL.Extensions;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
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
            return _dbcontext.Users.FirstOrDefault(p => p.IdUser == id).ToDTO();
        }

        public UserDTO GetByLogin(string login)
        {
            return _dbcontext.Users.FirstOrDefault(u => u.Login == login).ToDTO();
        }

        public bool Add(UserDTO userdto)
        {
            bool state = false;
            try
            {
                var entity = userdto.ToEntity();
                if (_dbcontext.Users.Any(u => u.Login == entity.Login))
                {
                    Console.WriteLine($"User with id {entity.IdUser} already exists in the database.");
                    state = false;
                }
                else
                {
                    entity.Password = BC.HashPassword(entity.Password);
                    _dbcontext.Add(entity);
                    _dbcontext.SaveChanges();
                    state = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                state = false;
            }

            return state;
        }

        public UserDTO CheckCredentials(UserDTO user)
        {
            var userDTO = _dbcontext.Users.SingleOrDefault(u => u.Login == user.Login).ToDTO();
            return userDTO;
        }

        public bool Authenticate(UserDTO account)
        {
            //get account user from database
            var userDTO = CheckCredentials(account);

            //check account found and verify password;
            if(userDTO == null || !BC.Verify(userDTO.Password, account.Password))
            {
                return false; //authentication failed
            }
            return true; // authentication successful
        }
        public bool Remove(UserDTO userDTO)
        {
            bool state = false;
            try
            {
                var entity = userDTO.ToEntity();

                if (_dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                }
                if(!_dbcontext.Users.Any(u => u.IdUser == entity.IdUser))
                {
                    _dbcontext.Users.Remove(entity);
                    _dbcontext.SaveChanges();
                    state = true;

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return state;
        }

        public bool Update(UserDTO userDTO)
        {
            try
            {
                var entity = userDTO.ToEntity();
                _dbcontext.Update(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        #endregion
    }
}
