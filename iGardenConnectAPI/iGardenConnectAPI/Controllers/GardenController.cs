
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
        public GardenVM Get(int id)
        {
            var gardenDTO = _GardenService.Get(id);

            return gardenDTO.ToVM();
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("")]
        public bool Add(GardenVM gardenVM)
        {
            var state = _GardenService.Add(gardenVM.ToDTO());
            return state;
        }
        #endregion

    }
}