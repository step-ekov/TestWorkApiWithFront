using ApiForTest.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiForTest.Services.ReceiptsResourceServices
{
    public interface IReceiptsResourceServices
    {
        Task<IEnumerable<Result>> GetAllReceiptRes();
        Task<IEnumerable<Result?>> GetReceiptResById(int id);
        Task<ReceiptsResource?> GetIDReceiptResById(int id);
        Task PostReceiptRes(ReceiptsResource receiptsResource);
        Task PutReceiptRes(int id, List<ReceiptsResource> receiptsDoc);
        Task DeleteReceiptRes(int id);


        Task<IEnumerable<Result>> FilterDate(DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<Result>> FilterReceipts(int receiptsDocId);
        Task<IEnumerable<Result>> FilterResource(string resourceName);
        Task<IEnumerable<Result>> FilterUnit(string unitName);
    }
}
