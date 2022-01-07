using angular_teste.Model;
using Microsoft.EntityFrameworkCore;


namespace angular_teste.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        public DbSet<Developer> Developers { get; set; }
    }
}
