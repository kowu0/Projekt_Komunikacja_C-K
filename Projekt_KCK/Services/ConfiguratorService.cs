using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;

namespace Projekt_KCK.Services
{
    public class ConfiguratorService
    {
        private readonly AppDbContext _context;
        public ConfiguratorService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ConfiguratorDto> GetById(int id)
        {
            var configurator = await _context.Configurators
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            return configurator == null ? null : new ConfiguratorDto
            {
                Id = configurator.Id,
                CpuId = configurator.CpuId,
                MotherboardId = configurator.MotherboardId,
                RamId = configurator.RamId,
                GpuId = configurator.GpuId,
                CoolerId = configurator.CoolerId,
                CaseId = configurator.CaseId,
                DiskId = configurator.DiskId
            };
        }

        public async Task<IEnumerable<ConfiguratorDto>> GetAll()
        {
            return await _context.Configurators
                .AsNoTracking()
                .Select(c => new ConfiguratorDto
                {
                    Id = c.Id,
                    CpuId = c.CpuId,
                    MotherboardId = c.MotherboardId,
                    RamId = c.RamId,
                    GpuId = c.GpuId,
                    CoolerId = c.CoolerId,
                    CaseId = c.CaseId,
                    DiskId = c.DiskId
                })
                .ToListAsync();
        }

        public async Task<int> Create(ConfiguratorDto dto)
        {
            var entity = new Configurator
            {
                CpuId = dto.CpuId,
                MotherboardId = dto.MotherboardId,
                RamId = dto.RamId,
                GpuId = dto.GpuId,
                CoolerId = dto.CoolerId,
                CaseId = dto.CaseId,
                DiskId = dto.DiskId
            };

            _context.Configurators.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var configurator = await _context.Configurators.FindAsync(id);
            if (configurator == null)
            {
                return false;
            }

            _context.Configurators.Remove(configurator);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, ConfiguratorDto dto)
        {
            var configurator = await _context.Configurators.FindAsync(id);
            if (configurator == null)
            {
                return false;
            }

            configurator.CpuId = dto.CpuId;
            configurator.MotherboardId = dto.MotherboardId;
            configurator.RamId = dto.RamId;
            configurator.GpuId = dto.GpuId;
            configurator.CoolerId = dto.CoolerId;
            configurator.CaseId = dto.CaseId;
            configurator.DiskId = dto.DiskId;

            _context.Entry(configurator).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidateComponents(ConfiguratorDto dto)
        {
            var cpuExists = await _context.Cpus.AnyAsync(c => c.Id == dto.CpuId);
            var motherboardExists = await _context.Motherboards.AnyAsync(m => m.Id == dto.MotherboardId);
            var ramExists = await _context.Rams.AnyAsync(r => r.Id == dto.RamId);
            var gpuExists = await _context.Gpus.AnyAsync(g => g.Id == dto.GpuId);
            var coolerExists = await _context.Coolers.AnyAsync(c => c.Id == dto.CoolerId);
            var caseExists = await _context.Cases.AnyAsync(c => c.Id == dto.CaseId);
            var diskExists = await _context.Discs.AnyAsync(d => d.Id == dto.DiskId);

            return cpuExists && motherboardExists && ramExists && gpuExists && coolerExists && caseExists && diskExists;
        }

        public async Task<Dictionary<string, List<int>>> GetAvailableComponentIds()
        {
            var componentIds = new Dictionary<string, List<int>>
            {
                { "Cpu", await _context.Cpus.Select(c => c.Id).ToListAsync() },
                { "Motherboard", await _context.Motherboards.Select(m => m.Id).ToListAsync() },
                { "Ram", await _context.Rams.Select(r => r.Id).ToListAsync() },
                { "Gpu", await _context.Gpus.Select(g => g.Id).ToListAsync() },
                { "Cooler", await _context.Coolers.Select(c => c.Id).ToListAsync() },
                { "Case", await _context.Cases.Select(c => c.Id).ToListAsync() },
                { "Disk", await _context.Discs.Select(d => d.Id).ToListAsync() }
            };

            return componentIds;
        }
    }
}
