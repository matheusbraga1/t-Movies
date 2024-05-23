using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace tMovies.API.Models
{
    [Table("users")]
    public class User : IdentityUser
    {
        public ICollection<Profile> Profiles { get; set; }
    }
}
