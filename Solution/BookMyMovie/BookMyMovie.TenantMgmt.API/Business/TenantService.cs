using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookMyMovie.TenantMgmt.API.API.Models;
using BookMyMovie.TenantMgmt.API.Business.Domain;
using BookMyMovie.TenantMgmt.API.Business.Interfaces;
using BookMyMovie.TenantMgmt.API.Repositories.Entities;
using BookMyMovie.TenantMgmt.API.Repositories.Interfaces;

namespace BookMyMovie.TenantMgmt.API.Business
{
    public class TenantService : IService<Tenant>
    {
        private readonly IRepository<TenantEntity> _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(IRepository<TenantEntity> tenantRepository, IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            var tenants = await _tenantRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Tenant>>(tenants);
        }

        public async Task<Tenant> GetByIdAsync(int id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            return _mapper.Map<Tenant>(tenant);
        }

        public async Task<int> CreateAsync(Tenant tenant)
        {
            var tenantEntity = _mapper.Map<TenantEntity>(tenant);
            return await _tenantRepository.AddAsync(tenantEntity);
        }

        public async Task<bool> UpdateAsync(int id, Tenant tenant)
        {
            var tenantEntity = _mapper.Map<TenantEntity>(tenant);
            tenantEntity.Id = id;
            return await _tenantRepository.UpdateAsync(tenantEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _tenantRepository.DeleteAsync(id);
        }
    }
}
