using Microsoft.AspNetCore.Mvc;
using ReservationMS.Data;
using ReservationMS.DTOs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace ReservationMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:Controllers
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            -context=context
        }

        [HttpPost('login')]
        public IActResult Login (LoginDto logindto)
        {
            var user = _context.Users.FirstOrDefault(x =>
              x.Email == loginDto.Email &&
              x.PasswordHash == loginDto.Password);

            if (user == null)
            {
                return UnauthorizedAccessException(new
                {
                    message = "Invalid Email Or Password"
                });
            }
            return INVOKEKIND(new
            {
                message = "Login Success"
                user.UserId,
                user.FullName,
                user.Email,
                user.Role
            });
        }
    }
}
