
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using System.Resources;
using BL;
using BL.Interfaces;
using DAL.Models;
using VM;
using VM.Extensions;
using DTO;

namespace iGardenConnectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GardenSensorController : ControllerBase
    {

        #region Properties
        private readonly IGardenSensorService _GardenSensorService;


        public GardenSensorController(IGardenSensorService gardenSensorService)
        {
            _GardenSensorService = gardenSensorService;
        }
        #endregion

        /// <summary>
        /// Get all the sensors located in a specific garden
        /// </summary>
        /// <returns></returns>
        #region GET
        [HttpGet]
        [Route("{idGarden}")]
        public IEnumerable<GardenSensorVM> Get(string idGarden)
        {
            var gardenSensorsDTO = _GardenSensorService.Get(idGarden);

            return gardenSensorsDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("{idGarden}/{idSensor}")]
        public GardenSensorVM Get(string idGarden, int idSensor)
        {
            var gardenSensorDTO = _GardenSensorService.Get(idGarden, idSensor);

            return gardenSensorDTO.ToVM();
        }
        #endregion

        #region 
        [HttpPost]
        [Route("/update/{idGarden}/{idSensor}/{value}")]
        public bool Update(string idGarden, int idSensor, string value)
        {
            var state = _GardenSensorService.Update(idGarden, idSensor, value);

            return state;
        }
        #endregion


          /*#region POST
          [HttpPost]
          [Route("{idGarden}/{idSensor}")]
          public bool Add(GardenSensorVM gardenSensorVM, string idGarden, int idSensor)
          {
              var gardenSensorDTO = gardenSensorVM.ToDTO();
              var state = _GardenSensorService.Add(gardenSensorDTO, idGarden, idSensor);
              return state;
          }
          #endregion*/
        

        #region DELETE
        [HttpDelete]
        [Route("/delete/{idGarden}/{idSensor}")]
        public ActionResult Delete(string idGarden, int idSensor)
        {
            var gardenSensorDTO = _GardenSensorService.Get(idGarden, idSensor);

            if (gardenSensorDTO is null)
            {
                return NotFound();
            }

            var state = _GardenSensorService.Remove(gardenSensorDTO, idGarden);
            return Ok(state);
        }
        #endregion


        #region DELETE
        [HttpDelete]
        [Route("/delete/{idGarden}")]
        public ActionResult Delete(string idGarden)
        {
            var gardenSensorsDTO = _GardenSensorService.Get(idGarden);

            if (gardenSensorsDTO is null)
            {
                return NotFound();
            }

            var state = _GardenSensorService.RemoveGardenSensors(gardenSensorsDTO, idGarden);
            return Ok(state);
        }
        #endregion


    }
}