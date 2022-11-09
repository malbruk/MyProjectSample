using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyProject.Repositories
{
    public interface IContext
    {
        DbSet<Role> Roles { get; set; }

        DbSet<Permission> Permissions { get; set; }

        DbSet<Claim> Claims { get; set; }

        int SaveChanges();
    }
}
