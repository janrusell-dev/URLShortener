using Microsoft.EntityFrameworkCore;
using URLShortener.Model;



namespace URLShortener.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Url> Urls { get; set; }

        
    }
}
