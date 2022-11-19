using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Role> AddAsync(string name, string description)
        {
            var newRole = new Role { Name = name, Description = description };
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();
            return newRole;
        }

        public async Task DeleteAsync(int id)
        {
            var role = await GetByIdAsync(id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var updatedRole = _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return updatedRole.Entity;
        }                    
    }                        
}
