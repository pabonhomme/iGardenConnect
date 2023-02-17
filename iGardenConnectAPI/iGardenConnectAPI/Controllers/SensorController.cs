using BL;
using BL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using System.Resources;
using VM;
using VM.Extensions;

namespace iGardenConnectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        #region Properties
        private readonly ISensorService _sensorService;

        public SensorController(ISensorService SensorService)
        {
            _sensorService = SensorService;
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("")]
        public IEnumerable<SensorVM> Get()
        {
            var SensorsDTO = _sensorService.Get();

            return SensorsDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("{id}")]
        public SensorVM Get(int id)
        {
            var SensorDTO = _sensorService.Get(id);

            return SensorDTO.ToVM();
        }
        #endregion


        #region POST
        [HttpPost]
        [Route("")]
        public bool Add(SensorVM sensorVM)
        {
            var dto = sensorVM.ToDTO();
            var state = _sensorService.Add(dto);
            return state;
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("")]
        public bool Update(SensorVM sensorVM)
        {
            var state = _sensorService.Update(sensorVM.ToDTO());
            return state;
        }
        #endregion

       /* #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var SensorDTO = Get(id).ToDTO();

            if (SensorDTO is null)
            {
                return NotFound();
            }

            var state = _sensorService.Remove(SensorDTO);
            return Ok(state);
        }
        #endregion*/
    }
}
