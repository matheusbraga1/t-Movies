using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tMovies.API.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(180)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsInWatchList { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsWatched { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
