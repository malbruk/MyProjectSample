using AutoMapper;
using MyProject.Common.Models;
using MyProject.Repositories;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public RoleModel GetById(int id)
        {
            //לוגיקה עסקית
            return _mapper.Map<RoleModel>(_roleRepository.GetById(id));
        }

        public List<RoleModel> GetList()
        {
            //לוגיקה עסקית
            return _mapper.Map<List<RoleModel>>(_roleRepository.GetAll());
        }

        public RoleModel Add(int id, string name, string title)
        {
            throw new NotImplementedException();
        }

        public RoleModel Update(RoleModel role)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
