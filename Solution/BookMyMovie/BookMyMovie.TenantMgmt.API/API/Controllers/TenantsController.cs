using AutoMapper;
using BookMyMovie.TenantMgmt.API.API.Attributes;
using BookMyMovie.TenantMgmt.API.API.Models;
using BookMyMovie.TenantMgmt.API.Business.Domain;
using BookMyMovie.TenantMgmt.API.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyMovie.TenantMgmt.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly IService<Tenant> _tenantService;

        private readonly IMapper _mapper;

        public TenantsController(IService<Tenant> tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionDescription("Tenant Read", "Failed to get all the tenant data")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var tenants = await _tenantService.GetAllAsync(parameters);
            var tenantDtos = _mapper.Map<PaginatedList<TenantDto>>(tenants);
            return Ok(tenantDtos);
        }

        [HttpGet("{id}")]
        [ActionDescription("Tenant Read", "Failed to get all the tenant details")]
        public async Task<IActionResult> GetById(int id)
        {
            var tenant = await _tenantService.GetByIdAsync(id);
            if (tenant == null)
                return NotFound();

            var tenantDto = _mapper.Map<TenantDto>(tenant);
            return Ok(tenantDto);
        }

        [HttpPost]
        [ActionDescription("Tenant Create", "Failed to create tenant")]
        public async Task<IActionResult> Create([FromBody] TenantDto tenantDto)
        {
            if (tenantDto == null)
                return BadRequest("Invalid data.");

            var tenant = _mapper.Map<Tenant>(tenantDto);
            var id = await _tenantService.CreateAsync(tenant);

            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        [ActionDescription("Tenant Read", "Failed to update tenant")]
        public async Task<IActionResult> Update(int id, [FromBody] TenantDto tenantDto)
        {
            if (tenantDto == null)
                return BadRequest("Invalid data.");

            var tenant = _mapper.Map<Tenant>(tenantDto);
            var updated = await _tenantService.UpdateAsync(id, tenant);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionDescription("Tenant Read", "Failed to delete tenant")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tenantService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
