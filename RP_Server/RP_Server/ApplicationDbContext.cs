using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RP_Server.Enums;
using RP_Server.Models.Entities;

namespace RP_Server
{
    public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
    {
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Activity> Activities => Set<Activity>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<ApplicationUser>();

            var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminEmail"];
            var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminPassword"];

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                    UserName = "admin",
                    NormalizedUserName = adminEmail.ToUpper(),
                    PasswordHash = hasher.HashPassword(null, adminPassword),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    Role = Role.Admin
                }
            );

            modelBuilder.Entity<Character>()
                .HasDiscriminator<string>("CharacterType")
                .HasValue<Character>("CharacterBase")
                .HasValue<HumanoidCharacter>("HumanoidCharacter")
                .HasValue<PlayerCharacter>("PlayerCharacter");

            modelBuilder.Entity<Character>()
                .Property<string>("CharacterType")
                .HasColumnName("CharacterType");
        }
    }
}
