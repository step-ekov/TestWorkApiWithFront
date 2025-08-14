using ApiForTest.Models;

namespace ApiForTest.Services.ReceiptsDocServices
{
    public interface IReceiptsDocServices
    {
        Task<IEnumerable<ReceiptsDoc>> GetAllReceiptsDoc();
        Task<ReceiptsDoc?> GetReceiptsDocById(int id);
        Task<int> PostReceiptsDoc(ReceiptsDoc receiptsDoc);
        Task PutReceiptsDoc(int id, ReceiptsDoc receiptsDoc);
        Task DeleteReceiptsDoc(int id);
    }
}
