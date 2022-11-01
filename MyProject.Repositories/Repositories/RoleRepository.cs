using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }

        public Role Add(int id, string name, string description)
        {
            var newRole = new Role { Id = id, Name = name, Description = description };
            _context.Roles.Add(newRole);
            return newRole;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(r => r.Id == id);
        }

        public Role Update(Role role)
        {
            var existRole = GetById(role.Id);
            existRole.Name = role.Name;
            existRole.Description = role.Description;
            return existRole;
        }
    }
}
