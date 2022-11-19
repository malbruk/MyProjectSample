using MyProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IClaimService
    {
        List<ClaimDTO> GetList();

        ClaimDTO GetById(int id);

        ClaimDTO Add(int id, int roleId, int permissionId, PolicyType policyType);

        ClaimDTO Update(ClaimDTO claim);
        
        void Delete(int id);
    }
}
