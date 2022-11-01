using MyProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IRoleService
    {
        List<RoleModel> GetList();

        RoleModel GetById(int id);

        RoleModel Add(int id, string name, string title);

        RoleModel Update(RoleModel role);

        void Delete(int id);
    }
}
