using FaultCatalogAPI.Models;
using FaultCatalogAPI.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FaultCatalogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.Register(request);

            if (user == null)
            {
                return BadRequest("User already exists or password not provided.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var token = await _authService.Login(request);
            if (token == null)
            {
                return BadRequest("User not found or password incorrect.");
            }

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            Console.WriteLine(token);

            return Ok(token.Value);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var user = new User();
            
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid refresh token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            var token = await _authService.RefreshToken();
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token.Value);
        }

        // This method creates a new refresh token
        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        // This method sets refresh token in the response cookies and updates user properties for future validation
        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var user = new User();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken",newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }
    }
}
