using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Cnx.Caiman.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController: Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public AuthController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet("/api/auth/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    await HttpContext.SignOutAsync();
                }
                return Ok("Logout Successfully");
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/auth")]
        public async Task<IActionResult> LoginDevelopment([FromForm] UserLoginDto model)
        {
           
            return Ok();
        }
    }
}