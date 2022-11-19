using AutoMapper;
using MyProject.Common.DTOs;
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

        public async Task<RoleDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.GetByIdAsync(id));
        }

        public async Task<List<RoleDTO>> GetListAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<List<RoleDTO>>(await _roleRepository.GetAllAsync());
        }

        public async Task<RoleDTO> AddAsync(RoleDTO role)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.AddAsync(role.Name, role.Title));
        }

        public async Task<RoleDTO> UpdateAsync(RoleDTO role)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.UpdateAsync(_mapper.Map<Role>(role)));
        }

        public async Task DeleteAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }
    }
}
