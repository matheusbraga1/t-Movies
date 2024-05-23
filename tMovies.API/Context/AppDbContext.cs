using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tMovies.API.Models;

namespace tMovies.API.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(x => x.NormalizedEmail)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(x => x.Profiles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            
            builder.Entity<Profile>()
                .HasMany(x => x.Movies)
                .WithOne(x => x.Profile)
                .HasForeignKey(x => x.ProfileId);
        }
    }
}
