using Microsoft.EntityFrameworkCore;
namespace chineseAction.Models
{
    public class ProjectDbContext : DbContext
{    
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPresent> CustomerPresent { get; set; }
        public virtual DbSet<Donater> Donater { get; set; }
        public virtual DbSet<Present> Present { get; set; }
        public virtual DbSet<Maneger> Maneger { get; set; }
        public virtual DbSet<Winner> Winner { get; set; }
    }
}
