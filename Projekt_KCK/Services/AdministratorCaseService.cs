using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorCaseService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorCaseService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CaseDto> GetCaseById(int id)
        {
            var @case = await _dbContext.Set<Case>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return @case == null ? null : @case.ToDto();
        }

        public async Task<IEnumerable<CaseDto>> GetCases()
        {
            var cases = await _dbContext.Set<Case>().AsNoTracking().ToListAsync();
            return cases.Select(e => e.ToDto());
        }

        public async Task<int> CreateCase(CaseDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Case>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteCase(int id)
        {
            var @case = await _dbContext.Set<Case>().FindAsync(id);
            if (@case == null)
            {
                return false;
            }

            _dbContext.Set<Case>().Remove(@case);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCase(int id, CaseDto dto)
        {
            var @case = await _dbContext.Set<Case>().FindAsync(id);
            if (@case == null)
            {
                return false;
            }

            @case.Model = dto.Model;
            @case.FormFactor = dto.FormFactor;
            @case.MaxGPULength = dto.MaxGPULength;
            @case.MaxCPUCoolerHeight = dto.MaxCPUCoolerHeight;

            _dbContext.Entry(@case).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
