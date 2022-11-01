using MyProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IPermissionService
    {
        List<PermissionModel> GetList();

        PermissionModel GetById(int id);

        PermissionModel Add(int id, string name, string title);

        PermissionModel Update(PermissionModel permission);

        void Delete(int id);
    }
}
