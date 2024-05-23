using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tMovies.API.Models
{
    [Table("users")]
    public class User : IdentityUser
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}
