using ApiForTest.Data;
using ApiForTest.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace ApiForTest.Services.UnitServices
{
    public class UnitServices : IUnitServices
    {
        private readonly SkladBd _skladBd;
        private const bool isArchive = true;

        public UnitServices(SkladBd skladBd)
        {
            _skladBd = skladBd;
        }

        public async Task<IEnumerable<Unit>> GetAllUnit()
        {
            return await _skladBd.UnitDb.Where(r => r.State == false).ToListAsync();
        }

        public async Task<Unit?> GetUnitById(int id)
        {
            return await _skladBd.UnitDb.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task PostUnit(Unit unit)
        {
            await _skladBd.UnitDb.AddAsync(unit);
            await _skladBd.SaveChangesAsync();
        }

        public async Task PutUnit(int id, Unit unit)
        {
            var element = await _skladBd.UnitDb.FindAsync(id);

            if (element != null)
            {
                element.Name = unit.Name;
                await _skladBd.SaveChangesAsync();
            }
        }

        public async Task DeleteUnit(int id)
        {
            var delUnit = await _skladBd.UnitDb.FindAsync(id);
            _skladBd.UnitDb.Remove(delUnit);
            await _skladBd.SaveChangesAsync();
        }

        public async Task<IEnumerable<Unit>> GetArchiveUnit()
        {
            return await _skladBd.UnitDb.Where(r => r.State == true).ToListAsync();
        }

        public async Task DoArchiveUnit(int id)
        {
            var archUnity = await _skladBd.UnitDb.FindAsync(id);
            if (archUnity.State != isArchive)
            {
                archUnity.State = isArchive;
                await _skladBd.SaveChangesAsync();
            }
        }
    }
}
