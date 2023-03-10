using Com.Application.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Com.Application.API.Service
{
    /// <summary>
    /// Class that will be used for 
    /// containing Logic for
    /// Creating User and REgistering User
    /// </summary>
    public class AuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AppResponse> RegisterNewUserAsync(RegisterUser user)
        { 
            AppResponse response = new AppResponse();
            
            if (user == null)
            {
                response.ResponseMessage = "User Information is Missing";
            }
            else 
            {
                // check is the user already exist

                if (await _userManager.FindByEmailAsync(user.Email) != null)
                {
                    response.ResponseMessage = $"User {user.Email} is already available";
                    response.IsSuccess = false;
                }
                else 
                {
                    // Save received information into IdentityUser class
                    IdentityUser newUser = new IdentityUser()
                    {
                        Email = user.Email,
                        UserName = user.Email
                    };

                    // Create new user
                    var result = await _userManager.CreateAsync(newUser, user.Password);

                    if (result.Succeeded)
                    {
                        response.ResponseMessage = $"User {user.Email} is created successfully";
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.ResponseMessage = $"User {user.Email} Creation Failed"; ;
                        response.IsSuccess = false;
                    }
                }
            }
            return response;
        }

        public async Task<AppResponse> AuthenticateUser(LoginUser user)
        {
            AppResponse response = new AppResponse();

            if (user == null)
            {
                response.ResponseMessage = "User Information required for Log In is Missing";
            }
            else
            {
                // Login the User
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, true);
                if (result.Succeeded)
                {
                    response.ResponseMessage = $"USer {user.Email} is logged Successfully";
                    response.IsSuccess = true;
                }
                else
                {
                    response.ResponseMessage = $"USer {user.Email} Login failed";
                    response.IsSuccess = false;
                }
            }
            return response;
        }
    }
}
