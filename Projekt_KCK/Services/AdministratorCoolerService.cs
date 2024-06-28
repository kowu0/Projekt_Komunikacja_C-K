using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorCoolerService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorCoolerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CoolerDto> GetCoolerById(int id)
        {
            var cooler = await _dbContext.Set<Cooler>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return cooler == null ? null : cooler.ToDto();
        }

        public async Task<IEnumerable<CoolerDto>> GetCoolers()
        {
            var coolers = await _dbContext.Set<Cooler>().AsNoTracking().ToListAsync();
            return coolers.Select(e => e.ToDto());
        }

        public async Task<int> CreateCooler(CoolerDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Cooler>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteCooler(int id)
        {
            var cooler = await _dbContext.Set<Cooler>().FindAsync(id);
            if (cooler == null)
            {
                return false;
            }

            _dbContext.Set<Cooler>().Remove(cooler);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCooler(int id, CoolerDto dto)
        {
            var cooler = await _dbContext.Set<Cooler>().FindAsync(id);
            if (cooler == null)
            {
                return false;
            }

            cooler.Model = dto.Model;
            cooler.Type = dto.Type;
            cooler.FanSize = dto.FanSize;
            cooler.MaxRPM = dto.MaxRPM;

            _dbContext.Entry(cooler).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

