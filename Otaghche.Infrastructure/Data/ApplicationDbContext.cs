using Microsoft.EntityFrameworkCore;
using Otaghche.Domain.Entities;

namespace Otaghche.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }



    }
}
