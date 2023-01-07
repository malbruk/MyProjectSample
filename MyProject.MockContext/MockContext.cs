using Microsoft.EntityFrameworkCore;
using Moq;
using MyProject.Repositories;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Mock
{
    public class MockContext //: IContext
    {
        public List<Role> Roles { get; set; }

        public List<Permission> Permissions { get; set; }

        public List<Claim> Claims { get; set; }

        private int saveIndex;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.Run(() => SaveChanges());
        }

        public int SaveChanges()
        {
            saveIndex++;
            return saveIndex;
        }

        public MockContext()
        {
            saveIndex = 0;

            //var roleList = new List<Role>() { new Role { Name = "admin", Id = 1 } }.AsQueryable();
            //var mockRoleSet = roleList.GetMockSet<Role>();
            //var mockedContext = new Mock<IContext>();
            //var x = mockedContext.Setup(x => x.Roles);
            //mockedContext.Setup(x => x.Roles).Returns(mockRoleSet.Object);
            //Roles = mockRoleSet.Object;
            //Roles.ToListAsync


            this.Roles = new List<Role>();
            this.Permissions = new List<Permission>();
            this.Claims = new List<Claim>();

            this.Roles.Add(new Role { Id = 1, Name = "admin", Description = "administrator with full access" });
            this.Roles.Add(new Role { Id = 2, Name = "user", Description = "user with limited access" });

            this.Permissions.Add(new Permission { Id = 1, Name = "VIEW_ALL_ORDERS" });
            this.Permissions.Add(new Permission { Id = 2, Name = "VIEW_ALL_PRODUCTS" });

            //this.Claims.Add(new Claim { Id = 1, RoleId = 1, PermissionId = 1, Policy = EPolicy.Allow });
            //this.Claims.Add(new Claim { Id = 2, RoleId = 2, PermissionId = 1, Policy = EPolicy.Deny });
            //this.Claims.Add(new Claim { Id = 3, RoleId = 1, PermissionId = 2, Policy = EPolicy.Allow });
            //this.Claims.Add(new Claim { Id = 4, RoleId = 2, PermissionId = 2, Policy = EPolicy.Allow });
        }
    }

    public static class MockExtensions
    {
        public static Mock<DbSet<T>> GetMockSet<T>(this IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns<T>(x => data.GetEnumerator());
            
            return mockSet;
        }
    }
}
