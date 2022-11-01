using MyProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IClaimService
    {
        List<ClaimModel> GetList();

        ClaimModel GetById(int id);

        ClaimModel Add(int id, int roleId, int permissionId, PolicyType policyType);

        ClaimModel Update(ClaimModel claim);
        
        void Delete(int id);
    }
}
