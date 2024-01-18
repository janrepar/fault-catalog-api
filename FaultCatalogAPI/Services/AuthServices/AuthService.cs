using FaultCatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FaultCatalogAPI.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        public readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return user;
        }

        // Method to create password hash that uses HMACSHA512 hash algorithm
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
