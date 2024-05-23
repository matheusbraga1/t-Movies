using System.ComponentModel.DataAnnotations;
using tMovies.API.Utilities;

namespace tMovies.API.ViewModels
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [DateFormat("dd-MM-yyyy")]
        public string DateOfBirth { get; set; }
    }
}
