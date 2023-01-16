using Microsoft.Extensions.Caching.Memory;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.CachedServices
{
    public class CachedRoleService : IRoleService
    {
        private const string RoleListCacheKey = "RoleList";

        private readonly IRoleService _roleService;
        private readonly IMemoryCache _memoryCache;

        public CachedRoleService(IRoleService roleService, IMemoryCache memoryCache)
        {
            _roleService = roleService;
            _memoryCache = memoryCache;
        }

        public Task<RoleDTO> AddAsync(RoleDTO role)
        {
            _memoryCache.Remove(RoleListCacheKey);
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            _memoryCache.Remove(RoleListCacheKey);
            throw new NotImplementedException();
        }

        public Task<RoleDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDTO>> GetListAsync()
        {

            if (_memoryCache.TryGetValue(RoleListCacheKey, out List<RoleDTO> list))
                return list;

            list = await _roleService.GetListAsync();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            _memoryCache.Set(RoleListCacheKey, list, cacheOptions);

            return list;
        }

        public Task<RoleDTO> UpdateAsync(RoleDTO role)
        {
            _memoryCache.Remove(RoleListCacheKey);
            throw new NotImplementedException();
        }
    }
}
