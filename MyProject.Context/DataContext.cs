using Microsoft.EntityFrameworkCore;
using MyProject.Repositories;

namespace MyProject.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Claim> Claims { get; set; }

        public string DbPath { get; }
        
        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "myprojectsample.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
    "Server=(localdb)\\mssqllocaldb;Database=MyProjectDB;Trusted_Connection=True;");
        }
    }
}