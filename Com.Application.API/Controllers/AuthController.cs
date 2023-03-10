using Com.Application.API.Models;
using Com.Application.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Application.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService service;

        /// <summary>
        /// Inject the AuthenticationService
        /// </summary>
        public AuthController(AuthenticationService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<AppResponse> CreateUser(RegisterUser user)
        {
            var response = await service.RegisterNewUserAsync(user);
            return response;
        }

        [HttpPost]
        [ActionName("auth")]
        public async Task<AppResponse> AuthUser(LoginUser user)
        {
            var response = await service.AuthenticateUser(user);
            return response;
        }
    }
}
