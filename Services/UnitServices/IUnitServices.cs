using ApiForTest.Models;

namespace ApiForTest.Services.UnitServices
{
    public interface IUnitServices
    {
        Task<IEnumerable<Unit>> GetAllUnit();
        Task<Unit?> GetUnitById(int id);
        Task PostUnit(Unit unit);
        Task PutUnit(int id, Unit unit);
        Task DeleteUnit(int id);
        Task<IEnumerable<Unit>> GetArchiveUnit();
        Task DoArchiveUnit(int id);
        Task FromArchiveUnit(int id);
    }
}
