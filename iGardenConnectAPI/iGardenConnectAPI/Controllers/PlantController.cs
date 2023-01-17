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
    public class PlantController : ControllerBase
    {
        #region Properties
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }
        #endregion

#region GET
        [HttpGet]
        [Route("")]
        public IEnumerable<PlantVM> Get()
        {
            var plantsDTO = _plantService.Get();

            return plantsDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("{id}")]
        public PlantVM Get(string id)
        {
            var plantDTO = _plantService.Get(id);

            return plantDTO.ToVM();
        }
        #endregion
        

        #region POST
        [HttpPost]
        [Route("")]
        public bool Add(PlantVM plantVM)
        {
            var state = _plantService.Add(plantVM.ToDTO());
            return state;
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("")]
        public bool Update(PlantVM plantVM)
        {
            var state = _plantService.Update(plantVM.ToDTO());
            return state;
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            var plantDTO = Get(id).ToDTO();

            if (plantDTO is null)
            {
                return NotFound();
            }

            var state = _plantService.Remove(plantDTO);
            return Ok(state);
        }
        #endregion
    }
}
