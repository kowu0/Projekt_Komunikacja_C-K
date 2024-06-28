using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorGpuService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorGpuService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GpuDto> GetGpuById(int id)
        {
            var gpu = await _dbContext.Set<Gpu>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return gpu == null ? null : gpu.ToDto();
        }

        public async Task<IEnumerable<GpuDto>> GetGpus()
        {
            var gpus = await _dbContext.Set<Gpu>().AsNoTracking().ToListAsync();
            return gpus.Select(e => e.ToDto());
        }

        public async Task<int> CreateGpu(GpuDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Gpu>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteGpu(int id)
        {
            var gpu = await _dbContext.Set<Gpu>().FindAsync(id);
            if (gpu == null)
            {
                return false;
            }

            _dbContext.Set<Gpu>().Remove(gpu);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateGpu(int id, GpuDto dto)
        {
            var gpu = await _dbContext.Set<Gpu>().FindAsync(id);
            if (gpu == null)
            {
                return false;
            }

            gpu.Model = dto.Model;
            gpu.MemorySize = dto.MemorySize;
            gpu.MemoryType = dto.MemoryType;
            gpu.CoreClock = dto.CoreClock;

            _dbContext.Entry(gpu).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
