using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorRamService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorRamService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RamDto> GetRamById(int id)
        {
            var ram = await _dbContext.Set<Ram>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return ram == null ? null : ram.ToDto();
        }

        public async Task<IEnumerable<RamDto>> GetRams()
        {
            var rams = await _dbContext.Set<Ram>().AsNoTracking().ToListAsync();
            return rams.Select(e => e.ToDto());
        }

        public async Task<int> CreateRam(RamDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Ram>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteRam(int id)
        {
            var ram = await _dbContext.Set<Ram>().FindAsync(id);
            if (ram == null)
            {
                return false;
            }

            _dbContext.Set<Ram>().Remove(ram);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRam(int id, RamDto dto)
        {
            var ram = await _dbContext.Set<Ram>().FindAsync(id);
            if (ram == null)
            {
                return false;
            }

            ram.Model = dto.Model;
            ram.Capacity = dto.Capacity;
            ram.Type = dto.Type;
            ram.Speed = dto.Speed;

            _dbContext.Entry(ram).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
