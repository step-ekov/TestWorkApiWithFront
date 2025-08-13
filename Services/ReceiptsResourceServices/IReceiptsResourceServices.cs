using ApiForTest.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiForTest.Services.ReceiptsResourceServices
{
    public interface IReceiptsResourceServices
    {
        Task<IEnumerable<Result>> GetAllReceiptRes();
        Task<IEnumerable<Result?>> GetReceiptResById(int id);
        Task PostReceiptRes(ReceiptsResource receiptsResource);
        Task PutReceiptRes(int id, ReceiptsResource receiptsDoc);
        Task DeleteReceiptRes(int id);


        //Task<IEnumerable<Result>> FilterDate(ReceiptsDoc receiptsDoc);
        Task<IEnumerable<Result>> FilterReceipts(int receiptsDocId);
        Task<IEnumerable<Result>> FilterResource(string resourceName);
        Task<IEnumerable<Result>> FilterUnit(string unitName);
    }
}
