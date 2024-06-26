﻿using FaultCatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ActionResult<User>> Register(UserDto request);
        Task<ActionResult<string>> Login(UserDto request);
        Task<ActionResult<string>> RefreshToken();
    }
}
