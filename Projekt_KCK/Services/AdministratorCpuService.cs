using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorCpuService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorCpuService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CPU Methods
        public async Task<CpuDto> GetCpuById(int id)
        {
            var cpu = await _dbContext.Set<Cpu>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return cpu == null ? null : cpu.ToDto();
        }

        public async Task<IEnumerable<CpuDto>> GetCpus()
        {
            var cpus = await _dbContext.Set<Cpu>().AsNoTracking().ToListAsync();
            return cpus.Select(e => e.ToDto());
        }

        public async Task<int> CreateCpu(CpuDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Cpu>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteCpu(int id)
        {
            var cpu = await _dbContext.Set<Cpu>().FindAsync(id);
            if (cpu == null)
            {
                return false;
            }

            _dbContext.Set<Cpu>().Remove(cpu);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCpu(int id, CpuDto dto)
        {
            var cpu = await _dbContext.Set<Cpu>().FindAsync(id);
            if (cpu == null)
            {
                return false;
            }

            cpu.Model = dto.Model;
            cpu.Cores = dto.Cores;
            cpu.ClockSpeed = dto.ClockSpeed;
            cpu.Socket = dto.Socket;

            _dbContext.Entry(cpu).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
