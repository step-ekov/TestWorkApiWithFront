using ApiForTest.Data;
using ApiForTest.Models;
using ApiForTest.Services.ResourceServices;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ApiForTest.Services.ResourceServices
{
    public class ResourceServices : IResourceServices
    {
        private readonly SkladBd _skladBd;
        private const bool isArchive = true;

        public ResourceServices(SkladBd skladBd)
        {
            _skladBd = skladBd;
        }

        public async Task<IEnumerable<Resource>> GetAllResources()
        {
            return await _skladBd.ResourceDb.Where(r => r.State == false).ToListAsync();
        }

        public async Task<Resource?> GetResourcesById(int id)
        {
            return await _skladBd.ResourceDb.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task PostResources(Resource resource)
        {
            await _skladBd.ResourceDb.AddAsync(resource);
            await _skladBd.SaveChangesAsync();
        }

        public async Task PutResources(int id, Resource resource)
        {
            var element = await _skladBd.ResourceDb.FindAsync(id);

            if (element != null)
            {
                element.Name = resource.Name;
                await _skladBd.SaveChangesAsync();
            }
        }

        public async Task DeleteResources(int id)
        {
            var delResources = await _skladBd.ResourceDb.FindAsync(id);
            _skladBd.ResourceDb.Remove(delResources);
            await _skladBd.SaveChangesAsync();
        }

        public async Task<IEnumerable<Resource>> GetArchiveResources()
        {
            return await _skladBd.ResourceDb.Where(r => r.State == true).ToListAsync();
        }

        public async Task DoArchiveResources(int id)
        {
            var archResources = await _skladBd.ResourceDb.FindAsync(id);
            if (archResources.State != isArchive)
            {
                archResources.State = isArchive;
                await _skladBd.SaveChangesAsync();
            }
        }

        public async Task FromArchiveResources(int id)
        {
            var archResources = await _skladBd.ResourceDb.FindAsync(id);
            if (archResources.State == isArchive)
            {
                archResources.State = false;
                await _skladBd.SaveChangesAsync();
            }
        }
    }
}
