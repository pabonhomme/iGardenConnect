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

        public PlantController(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet(Name = "GetPlant")]
        public IEnumerable<PlantVM> Get()
        {

            var plantsDTO = PlantService.Get(GetDbContext());

            return plantsDTO.Select(dto => dto.ToVM());
        }
    }
}
