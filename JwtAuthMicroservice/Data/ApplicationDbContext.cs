using Microsoft.EntityFrameworkCore;
using JwtAuthMicroservice.API.Models;

namespace JwtAuthMicroservice.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
