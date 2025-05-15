using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        //Even though we are using ITokenService which is an interface, it is frameworks responsibility to inject appropriate implementation of the interface
        public AccountController(DataContext context, ITokenService tokenService) {
            this._context = context;
            this._tokenService = tokenService;
        }

        //Query params automatically bind to the method parameters
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){
            using var hmac = new HMACSHA512(); //using keyword is used dispose the object after use

            if(await UserExists(registerDto.UserName)) return BadRequest("Username already exists");

            var user = new AppUser 
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto()
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if(!computedHash.SequenceEqual(user.PasswordHash)) return Unauthorized("Invalid password");

            return new UserDto()
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}