using BL;
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
    [Route("[controller]")]
    public class PlantController : ControllerBase
    {

        #region Properties
        private static iGardenConnectDBContext _dbcontext;

        public static iGardenConnectDBContext GetDbContext()
        {
            return _dbcontext;
        }
        #endregion


        #region GET
        public PlantController(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<PlantVM> Get()
        {

            var plantsDTO = PlantService.Get(GetDbContext());

            return plantsDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("{id}")]
        public PlantVM Get(string id)
        {

            var plantDTO = PlantService.Get(GetDbContext(), id);

            return plantDTO.ToVM();
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("")]
        public bool Put(PlantVM plantVM)
        {
            var state = PlantService.AddOrUpdate(GetDbContext(), plantVM.ToDTO());
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

            var state = PlantService.Remove(_dbcontext, plantDTO);
            return Ok(state);
        }
        #endregion
    }
}
