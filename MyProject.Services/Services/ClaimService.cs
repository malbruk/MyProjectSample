using MyProject.Common.DTOs;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{

    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        
        public ClaimDTO Add(int id, int roleId, int permissionId, PolicyType policyType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClaimDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClaimDTO> GetList()
        {
            throw new NotImplementedException();
        }

        public ClaimDTO Update(ClaimDTO claim)
        {
            throw new NotImplementedException();
        }
    }
}
