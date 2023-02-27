using ConfigureServices.Models.ComplexModels;
using Microsoft.EntityFrameworkCore;

namespace ConfigureServices
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ComplexModel> ComplexModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=contract-manager;Trusted_Connection=True;MultipleActiveResultSets=true");
            //   optionsBuilder.UseNpgsql("Host=localhost;Database=complex-models;Username=TNE_USER;Password=123123");
            optionsBuilder.UseLowerCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
