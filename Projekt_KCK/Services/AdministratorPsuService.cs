using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorPsuService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorPsuService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PsuDto> GetPsuById(int id)
        {
            var psu = await _dbContext.Set<Psu>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return psu == null ? null : psu.ToDto();
        }

        public async Task<IEnumerable<PsuDto>> GetPsus()
        {
            var psus = await _dbContext.Set<Psu>().AsNoTracking().ToListAsync();
            return psus.Select(e => e.ToDto());
        }

        public async Task<int> CreatePsu(PsuDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Psu>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeletePsu(int id)
        {
            var psu = await _dbContext.Set<Psu>().FindAsync(id);
            if (psu == null)
            {
                return false;
            }

            _dbContext.Set<Psu>().Remove(psu);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePsu(int id, PsuDto dto)
        {
            var psu = await _dbContext.Set<Psu>().FindAsync(id);
            if (psu == null)
            {
                return false;
            }

            psu.Model = dto.Model;
            psu.Power = dto.Power;
            psu.EfficiencyRating = dto.EfficiencyRating;
            psu.FormFactor = dto.FormFactor;

            _dbContext.Entry(psu).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
