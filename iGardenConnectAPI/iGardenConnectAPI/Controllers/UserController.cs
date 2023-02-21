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
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly IUserService _userService;

        public UserController(IUserService UserService)
        {
            _userService = UserService;
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("")]
        public IEnumerable<UserVM> Get()
        {
            var UsersDTO = _userService.Get();

            return UsersDTO.Select(dto => dto.ToVM());
        }

        [HttpGet]
        [Route("{id}")]
        public UserVM Get(int id)
        {
            var UserDTO = _userService.Get(id);

            return UserDTO.ToVM();
        }
        #endregion


        #region POST
        [HttpPost]
        [Route("")]
        public bool Add(UserVM UserVM)
        {
            var state = _userService.Add(UserVM.ToDTO());
            return state;
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("")]
        public bool Update(UserVM UserVM)
        {
            var state = _userService.Update(UserVM.ToDTO());
            return state;
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var UserDTO = Get(id).ToDTO();

            if (UserDTO is null)
            {
                return NotFound();
            }

            var state = _userService.Remove(UserDTO);
            return Ok(state);
        }
        #endregion
    }
}
