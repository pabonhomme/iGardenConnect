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
    public class GardenSensorRepository : IGardenSensorRepository
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public GardenSensorRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public IEnumerable<GardenSensorDTO> Get(string idGarden)
        {
            return _dbcontext.GardenSensors.ToList().Where(s => s.IdGarden == idGarden).ToList().Select(s => s.ToDTO()).ToList();

        }
        /// <summary>
        /// get the garden sensor
        /// </summary>
        /// <param name="idGarden"></param>
        /// <param name="idSensor"></param>
        /// <returns>GardenSensorDTO </returns>
        public GardenSensorDTO Get(string idGarden, SensorDTO sensor)
        {
            GardenSensorDTO g = _dbcontext.GardenSensors.ToList().Where(s => s.IdGarden == idGarden).FirstOrDefault(s => s.IdSensor == sensor.IdSensor).ToDTO();
            g.Name = sensor.Name;
            g.Type = sensor.Type;
            g.Brand = sensor.Brand;
            g.Price = sensor.Price;
            return g;
        }
        public IEnumerable<GardenSensorDTO> GetByIdSensor(int idSensor)
        {
            var gardenSensors =  _dbcontext.GardenSensors.ToList().Where(s => s.IdSensor == idSensor).Select(s => s.ToDTO()).ToList();
            return gardenSensors;
        }
        public GardenSensorDTO GetByGardenIdSensor(int idSensor, string idGarden)
        {
            var gardenSensor = _dbcontext.GardenSensors.ToList().FirstOrDefault(s => s.IdSensor == idSensor && s.IdGarden == idGarden).ToDTO();
            return gardenSensor;
        }

        public bool Add(string idGarden, IEnumerable<SensorDTO> sensors)
        {
            try
            {
                GardenSensor entity = new GardenSensor();
                foreach (SensorDTO sensor in sensors)
                {

                    entity.IdGarden = idGarden;
                    entity.IdSensor = sensor.IdSensor;
                    entity.Value = "0";
                    entity.State = "OFF";


                    _dbcontext.Add(entity);
                    _dbcontext.SaveChanges();

                }
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
        /// <summary>
        /// Attach new sensor to a Garden by admin
        /// </summary>
        /// <param name="idGarden"></param>
        /// <param name="idSensor"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddGardenSensor(string idGarden, int idSensor)
        {
            try
            {
                GardenSensor entity = new GardenSensor();
                entity.IdGarden = idGarden;
                entity.IdSensor = idSensor;
                entity.Value = "13";
                entity.State = "OFF";

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
        public bool UpdateByValue(GardenSensorDTO gardenSensorDTO, string idGarden, string value)
        {
            try
            {
                var entity = gardenSensorDTO.ToEntity();
                entity.IdGarden = idGarden;
                entity.Value = value; //update 
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

        /// <summary>
        /// Update water pump and leds by state (ON or OFF)
        /// </summary>
        /// <param name="gardenSensorDTO"></param>
        /// <param name="idGarden"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateByState(GardenSensorDTO gardenSensorDTO, string idGarden, string state)
        {
            try
            {
                var entity = gardenSensorDTO.ToEntity();
                entity.IdGarden = idGarden;
                entity.State= state.Trim(); //update 
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
        #region DELETE
        /// <summary>
        /// Remove a plant
        /// </summary>
        /// <param name="gardensensor"> the sensor located in the garden to delete</param>
        /// <returns>Boolean indicating if the deletion went well</returns>
        public bool Remove(GardenSensorDTO gardensensor, string idGarden)
        {
            try
            {
                var entity = gardensensor.ToEntity();
                entity.IdGarden = idGarden; 

                if (_dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                }

                _dbcontext.GardenSensors.Remove(entity);

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
        
        public bool RemoveGardenSensorByIdSensor(int idSensor, string idGarden)
        {

            var gs = GetByGardenIdSensor(idSensor, idGarden);
            var state = false;


            state = Remove(gs, idGarden);

            return state;
        }

    }
}
