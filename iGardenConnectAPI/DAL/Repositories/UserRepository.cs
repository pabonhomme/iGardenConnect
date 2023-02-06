using DAL.Extensions;
using DAL.Interfaces;
using DAL.Models;
using DTO;
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

        public bool Add(UserDTO userdto)
        {
            try
            {
                var entity = userdto.ToEntity();
                _dbcontext.Add(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
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

        public bool Remove(UserDTO userDTO)
        {
            try
            {
                var entity = userDTO.ToEntity();

                if (_dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                }

                _dbcontext.Users.Remove(entity);

                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
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
