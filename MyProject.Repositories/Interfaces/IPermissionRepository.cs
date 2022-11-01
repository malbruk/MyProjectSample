using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        List<Permission> GetAll();

        Permission GetById(int id);

        Permission Add(int id, string name, string description);

        Permission Update(Permission permission);

        void Delete(int id);
    }
}
