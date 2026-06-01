using Microsoft.AspNetCore.Mvc;
using ReservationMS.DTOs;
using ReservationMS.Models;
using ReservationMS.Data;
using System;
using System.Runtime.InteropServices;

using System.Security;

namespace ReservationMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login ([FromBody]LoginDto logindto)
        {
            var user = _context.Users.FirstOrDefault(x =>
    x.Email == logindto.Email &&
    x.Password == logindto.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid Email Or Password"
                });
            }
            return Ok(new
            {
                message = "Login Success",
                user.UserId,
                user.FullName,
                user.Email,
                user.Role
            });
        }
    }
}
