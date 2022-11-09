using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.Repositories.Repositories
{
    internal class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;

        public PermissionRepository(IContext context)
        {
            _context = context;
        }

        public Permission Add(int id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Permission> GetAll()
        {
            return _context.Permissions.ToList();
        }

        public Permission GetById(int id)
        {
            return _context.Permissions.Find(id);
        }

        public Permission Update(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
