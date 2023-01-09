using BL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VM;
using VM.Extensions;

namespace iGardenConnectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantController : ControllerBase
    {

        private static iGardenConnectDBContext _dbcontext;

        public static iGardenConnectDBContext GetDbContext()
        {
            return _dbcontext;
        }
        #region Get
        public PlantController(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<PlantVM> Get()
        {

            var plantsDTO = PlantService.Get(GetDbContext());

            return plantsDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public PlantVM Get(string id)
        {

            var plantDTO = PlantService.Get(GetDbContext(), id);

            return plantDTO.ToVM();
        }
        #endregion
    }
}
