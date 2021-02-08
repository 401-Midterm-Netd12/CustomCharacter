using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUser Userservice;
        public UserController(IAppUser _context)
        {
            Userservice = _context;
        }

        [HttpPost("Register")]

        //Either we get a good user OR we throw a modelstate error.
        public async Task<ActionResult<AppUserDTO>> Register(RegisterUser data)
        {
            var user = await Userservice.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AppUserDTO>> Login(LoginData data)
        {
            //authentication verifies who you are
            //authorization says what you can do
            var user = await Userservice.Authenticate(data.Username, data.Password);

            if (user != null)
            {
                return user;
            }
            return Unauthorized();
        }

        [HttpGet("me")]
        public async Task<ActionResult<AppUserDTO>> Me()
        {
            return await Userservice.GetUser(this.User);
        }
    }
}
