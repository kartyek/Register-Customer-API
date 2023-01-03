using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        

        public UsersController(
            IUserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            } 
            else 
            { 
                try
                {
                     // create user
                    _userService.Create(user);
                     return Ok();

                }
                catch (AppException ex)
                {
                    // return error message if there was an exception
                     return BadRequest(new { message = ex.Message });
                }
            }
        }
    }
}
