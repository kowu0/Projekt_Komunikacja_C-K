using Microsoft.EntityFrameworkCore;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using Projekt_KCK.Extensions;

namespace Projekt_KCK.Services
{
    public class AdministratorDiskService
    {
        private readonly AppDbContext _dbContext;
        public AdministratorDiskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DiskDto> GetDiskById(int id)
        {
            var disk = await _dbContext.Set<Disk>().AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return disk == null ? null : disk.ToDto();
        }

        public async Task<IEnumerable<DiskDto>> GetDisks()
        {
            var disks = await _dbContext.Set<Disk>().AsNoTracking().ToListAsync();
            return disks.Select(e => e.ToDto());
        }

        public async Task<int> CreateDisk(DiskDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Set<Disk>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteDisk(int id)
        {
            var disk = await _dbContext.Set<Disk>().FindAsync(id);
            if (disk == null)
            {
                return false;
            }

            _dbContext.Set<Disk>().Remove(disk);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDisk(int id, DiskDto dto)
        {
            var disk = await _dbContext.Set<Disk>().FindAsync(id);
            if (disk == null)
            {
                return false;
            }

            disk.Model = dto.Model;
            disk.Capacity = dto.Capacity;
            disk.Type = dto.Type;
            disk.ReadSpeed = dto.ReadSpeed;
            disk.WriteSpeed = dto.WriteSpeed;

            _dbContext.Entry(disk).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
