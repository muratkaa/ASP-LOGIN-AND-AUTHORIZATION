using System.ComponentModel;

namespace AuthAPI.ViewModels
{
    public class LoginRequest
    {
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}