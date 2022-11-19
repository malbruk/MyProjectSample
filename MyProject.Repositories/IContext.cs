using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public interface IContext
    {
        DbSet<Role> Roles { get; set; }

        DbSet<Permission> Permissions { get; set; }

        DbSet<Claim> Claims { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
