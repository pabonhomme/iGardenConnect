
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
    public class GardenController : ControllerBase
    {

        #region Properties
        private readonly IGardenService _GardenService;


        public GardenController(IGardenService gardenService)
        {
            _GardenService = gardenService;
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("")]
        public IEnumerable<GardenVM> Get()
        {
            var gardensDTO = _GardenService.Get();

            return gardensDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("{id}")]
        public GardenVM Get(string id)
        {
            var gardenDTO = _GardenService.GetByIdGarden(id);

            return gardenDTO.ToVM();
        }
        #endregion

        [HttpGet]
        [Route("user/{idUser}")]
        public IEnumerable<GardenVM> Get(int idUser)
        {
            var gardensDTO = _GardenService.Get(idUser);

            return gardensDTO.Select(dto => dto.ToVM());
        }
        
        #region POST
        [HttpPost]
        [Route("{idUser}")]
        public ActionResult Add(GardenVM gardenVM, int idUser)
        {
            var gardenDTO = gardenVM.ToDTO();
            var state = _GardenService.Add(gardenDTO, idUser);
            if (!state) return BadRequest("Ce jardin appartient déjà à un autre utilisateur");
            return Ok(state);
        }

        #endregion

        #region PUT
        [HttpPut]
        [Route("")]
        public bool Update(GardenVM gardenVM)
        {
            
            var gardenDTO = _GardenService.GetByIdGarden(gardenVM.IdGarden);
            var state = false;

            if (gardenVM.Name != gardenDTO.Name && gardenVM.Plant.IdPlant != gardenDTO.Plant.IdPlant)
            {
                var stateName = _GardenService.UpdateByNamePlant(gardenDTO, gardenVM.Name, gardenVM.Plant.IdPlant);
                state = stateName;

            }
            else if (gardenVM.Name != gardenDTO.Name)
            {
                var stateName = _GardenService.UpdateByName(gardenDTO, gardenVM.Name);
                state = stateName;

            }
            else if (gardenVM.Plant.IdPlant != gardenDTO.Plant.IdPlant)
            {
                var statePlant = _GardenService.UpdateByPlant(gardenDTO, gardenVM.Plant.IdPlant);
                state = statePlant;
            }

            return state;
        }


        [HttpPut]
        [Route("{idGarden}/{idSensor}/{duration}")]
        public bool UpdateWateringDuration(string idGarden, int duration)
        {
            var gardenDTO = _GardenService.GetByIdGarden(idGarden);
            var state = _GardenService.UpdateByWateringDuration(gardenDTO, duration);

            return state;
        }

        #endregion
        #region DELETE
        [HttpDelete]
        [Route("{idGarden}")]
        public ActionResult Delete(string idGarden)
        {
            var gardenDTO = _GardenService.GetByIdGarden(idGarden);


            if (gardenDTO is null)
            {
                return NotFound();
            }

            var state = _GardenService.Remove(gardenDTO);
            return Ok(state);
        }
        #endregion

    }
}