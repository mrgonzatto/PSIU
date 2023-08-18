using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Models;

namespace PSIUWeb.Data
{
    public class AppDbContext : 
        IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Pacient>? Pacients { get; set; }

    }
}
