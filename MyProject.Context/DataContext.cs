using Microsoft.EntityFrameworkCore;
using MyProject.Repositories;

namespace MyProject.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Claim> Claims { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    {
        //        options.UseSqlServer(
        //"Server=(localdb)\\mssqllocaldb;Database=MyProjectDB;Trusted_Connection=True;");
        //    }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(b => b.Name)
                .IsRequired();
        }
    }
}