using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Com.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Injecting the Role Manager Dependecny as well as inject
        /// UserManager to access uers
        /// </summary>
        /// <param name="roleManager"></param>
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this._roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(IdentityRole role)
        { 
            var result = await _roleManager.CreateAsync(role);
            return Ok(result.Succeeded);
        }

        [Route("roletouser")]
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userName, string roleName)
        {
            // Check if Role Exist
            var isRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!isRoleExist) return NotFound($"Role {roleName} does not exist");

            // Check if the user exist
            var userObj = await _userManager.FindByNameAsync(userName);
            if(userObj == null) return NotFound($"User {userName} does not exist");


            // Assign Role to User
                                           // IdentityUser RoleName
            var result = await _userManager.AddToRoleAsync(userObj, roleName);
            if(result.Succeeded)
                return Ok($"Role {roleName} is assign to user {userName}");

            return BadRequest($"Role {roleName} Assignment to user {userName} failed");
        }
    }
}
