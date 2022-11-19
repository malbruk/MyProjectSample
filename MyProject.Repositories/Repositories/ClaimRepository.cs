using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyProject.Repositories.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        }

        public Claim Add(int id, int roleId, int permissionId, EPolicy policy)
        {
            var added = _context.Claims.Add(new Claim { Id = id, /*RoleId = roleId, PermissionId = permissionId, */Policy = policy });
            _context.SaveChanges();
            return added.Entity;
        }

        public void Delete(int id)
        {
            _context.Claims.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Claim> GetAll()
        {
            return _context.Claims.ToList();
        }

        public Claim GetById(int id)
        {
            return _context.Claims.Find(id);
        }

        public Claim Update(Claim claim)
        {
            var updated = _context.Claims.Update(claim);
            _context.SaveChanges();
            return updated.Entity;
        }
    }
}
