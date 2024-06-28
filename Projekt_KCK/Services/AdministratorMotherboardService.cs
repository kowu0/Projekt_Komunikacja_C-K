using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorMotherboardService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorMotherboardService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MotherboardDto> GetMotherboardById(int id)
        {
            var motherboard = await _dbContext.Set<Motherboard>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return motherboard == null ? null : motherboard.ToDto();
        }

        public async Task<IEnumerable<MotherboardDto>> GetMotherboards()
        {
            var motherboards = await _dbContext.Set<Motherboard>().AsNoTracking().ToListAsync();
            return motherboards.Select(e => e.ToDto());
        }

        public async Task<int> CreateMotherboard(MotherboardDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Motherboard>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteMotherboard(int id)
        {
            var motherboard = await _dbContext.Set<Motherboard>().FindAsync(id);
            if (motherboard == null)
            {
                return false;
            }

            _dbContext.Set<Motherboard>().Remove(motherboard);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMotherboard(int id, MotherboardDto dto)
        {
            var motherboard = await _dbContext.Set<Motherboard>().FindAsync(id);
            if (motherboard == null)
            {
                return false;
            }

            motherboard.Model = dto.Model;
            motherboard.FormFactor = dto.FormFactor;
            motherboard.Socket = dto.Socket;
            motherboard.RAMSlots = dto.RAMSlots;
            motherboard.Chipset = dto.Chipset;

            _dbContext.Entry(motherboard).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
