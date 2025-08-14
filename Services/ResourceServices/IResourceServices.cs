using ApiForTest.Models;

namespace ApiForTest.Services.ResourceServices
{
    public interface IResourceServices
    {
        Task<IEnumerable<Resource>> GetAllResources();
        Task<Resource?> GetResourcesById(int id);
        Task PostResources(Resource resource);
        Task PutResources(int id, Resource resource);
        Task DeleteResources(int id);
        Task<IEnumerable<Resource>> GetArchiveResources();
        Task DoArchiveResources(int id);
        Task FromArchiveResources(int id);
    }
}
