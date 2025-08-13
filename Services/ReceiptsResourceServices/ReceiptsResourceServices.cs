using ApiForTest.Data;
using ApiForTest.Models;
using ApiForTest.Services.ReceiptsDocServices;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace ApiForTest.Services.ReceiptsResourceServices
{
    public class ReceiptsResourceServices : IReceiptsResourceServices
    {
        private readonly SkladBd _skladBd;
        private readonly IReceiptsDocServices _receiptsDocServices;

        public ReceiptsResourceServices(SkladBd skladBd, IReceiptsDocServices receiptsDocServices)
        {
            _skladBd = skladBd;
            _receiptsDocServices = receiptsDocServices;
        }

        public async Task<IEnumerable<Result>> GetAllReceiptRes()
        {
            return await GetReceipt().ToListAsync();
        }

        public async Task<IEnumerable<Result?>> GetReceiptResById(int id)
        {
            return await GetReceipt()
                .Where(r => r.Id == id)
                .ToListAsync();
        }

        public async Task PostReceiptRes(ReceiptsResource receiptsResource)
        {
            await _skladBd.ReceiptsResourcesDb.AddAsync(receiptsResource);
            await _skladBd.SaveChangesAsync();
        }

        public async Task PutReceiptRes(int id, ReceiptsResource receiptsDoc)
        {
            var receipt = await _skladBd.ReceiptsResourcesDb.FirstOrDefaultAsync(r => r.Id == id);

            if (receipt != null)
            {
                if(receipt.ReceiptsResourceID != receiptsDoc.ReceiptsResourceID && receiptsDoc.ReceiptsResourceID != 0)
                    receipt.ReceiptsResourceID = receiptsDoc.ReceiptsResourceID;
                
                if(receipt.ResourceID != receiptsDoc.ResourceID && receiptsDoc.ResourceID != 0)
                    receipt.ResourceID = receiptsDoc.ResourceID;
                
                if(receipt.UnitID != receiptsDoc.UnitID && receiptsDoc.UnitID != 0)
                    receipt.UnitID = receiptsDoc.UnitID;
                
                if(receipt.Count != receiptsDoc.Count && receiptsDoc.Count != 0)
                    receipt.Count = receiptsDoc.Count;
                
                await _skladBd.SaveChangesAsync();
            }
        }

        public async Task DeleteReceiptRes(int id)
        {
            var del = await _skladBd.ReceiptsResourcesDb.FindAsync(id);
            if(del != null)
            {
                _skladBd.ReceiptsResourcesDb.Remove(del);
                await _skladBd.SaveChangesAsync() ;
            }
        }

        //public async Task<IEnumerable<Result>> FilterDate(ReceiptsDoc receiptsDoc)
        //{

        //}

        public async Task<IEnumerable<Result>> FilterReceipts(int receiptsDocId)
        {
            var result =  await GetReceipt()
                .Where(r => r.NumberRDoc == receiptsDocId)
                .ToListAsync();

            if (result.Count == 0)
                throw new Exception("Таких значений нет");
            return result;
        }

        public async Task<IEnumerable<Result>> FilterResource(string resourceName)
        {
            var result = await GetReceipt()
                .Where(r => r.NameResource == resourceName)
                .ToListAsync();

            if (result.Count == 0)
                throw new Exception("Таких значений нет");
            return result;
        }

        public async Task<IEnumerable<Result>> FilterUnit(string unitName)
        {
            var result = await GetReceipt()
                .Where(r => r.NameUnit == unitName)
                .ToListAsync();

            if (result.Count == 0)
                throw new Exception("Таких значений нет");
            return result;
        }


        private IQueryable<Result> GetReceipt()
        {
            var result = from rr in _skladBd.ReceiptsResourcesDb
                         join rd in _skladBd.ReceiptsDocDb on rr.ReceiptsResourceID equals rd.Id
                         join r in _skladBd.ResourceDb on rr.ResourceID equals r.Id
                         join u in _skladBd.UnitDb on rr.UnitID equals u.Id

                         select new Result
                         {
                             Id = rr.Id,
                             NumberRDoc = rd.Number,
                             DateRDoc = DateOnly.FromDateTime(rd.Date),
                             NameResource = r.Name,
                             NameUnit = u.Name,
                             CountRResource = rr.Count
                         };

            return result;
        }
    }
}
