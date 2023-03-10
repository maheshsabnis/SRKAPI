namespace Com.Application.API.Models
{
    /// <summary>
    /// To Register New USer
    /// </summary>
    public class RegisterUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    /// <summary>
    /// To Login aka Authenticate User
    /// </summary>
    public class LoginUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }


    public class AppResponse
    {
        public string? ResponseMessage { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}
