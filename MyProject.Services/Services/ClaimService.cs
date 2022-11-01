using MyProject.Common.Models;
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
        
        public ClaimModel Add(int id, int roleId, int permissionId, PolicyType policyType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClaimModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClaimModel> GetList()
        {
            throw new NotImplementedException();
        }

        public ClaimModel Update(ClaimModel claim)
        {
            throw new NotImplementedException();
        }
    }
}
