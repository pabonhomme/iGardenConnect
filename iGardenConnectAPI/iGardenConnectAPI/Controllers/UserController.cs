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

        [HttpGet]
        [Route("{login}")]
        public ActionResult Get(string login)
        {
            var userDTO = _userService.GetByLogin(login);
            if(userDTO == null)
            {
                return NotFound();
            }

            return Ok(userDTO.ToVM());
        }

        #endregion


        #region POST
        [HttpPost]
        [Route("")]
        public ActionResult Add(UserVM userVM)
        {
            var state = _userService.Add(userVM.ToDTO());
            if (!state) return NotFound();
            return Ok(state);
        }
        #endregion



        #region POST
        [HttpPost]
        [Route("auth/")]
        public ActionResult AuthUser(UserVM userVM)
        {
            var authUser = _userService.CheckCredentials(userVM.ToDTO());

          //  var mdpHashBDD = "$2a$10$WrabqmxfA1qzcOT4fGx7JuIzWnZQsDvDCuL/62RF4nUORVD5cj7tO";
            if (authUser == null)
            {
                return NotFound();
            }
            if (authUser != null && !BCrypt.Net.BCrypt.Verify(userVM.Password, authUser.Password))
            {
                return BadRequest("Incorrect Password! Please check your password!");
            }
            return Ok();
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("")]
        public ActionResult Update(UserVM UserVM)
        {
            var state = _userService.Update(UserVM.ToDTO());
            if (!state) return BadRequest(state);
            return Ok();
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
