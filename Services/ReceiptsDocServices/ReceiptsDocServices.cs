using ApiForTest.Data;
using ApiForTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForTest.Services.ReceiptsDocServices
{
    public class ReceiptsDocServices : IReceiptsDocServices
    {
        private readonly SkladBd _skladBd;

        public ReceiptsDocServices(SkladBd skladBd)
        {
            _skladBd = skladBd;
        }

        public async Task<IEnumerable<ReceiptsDoc>> GetAllReceiptsDoc()
        {
            return await _skladBd.ReceiptsDocDb.ToListAsync();
        }

        public async Task<ReceiptsDoc?> GetReceiptsDocById(int id)
        {
            return await _skladBd.ReceiptsDocDb.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task PostReceiptsDoc(ReceiptsDoc receiptsDoc)
        {
            await _skladBd.ReceiptsDocDb.AddAsync(receiptsDoc);
            await _skladBd.SaveChangesAsync();
        }

        public async Task PutReceiptsDoc(int id, ReceiptsDoc receiptsDoc)
        {
            var element = await _skladBd.ReceiptsDocDb.FindAsync(id);

            if (element != null)
            {
                element.Number = receiptsDoc.Number;
                element.Date = receiptsDoc.Date;
                await _skladBd.SaveChangesAsync();
            }
        }

        public async Task DeleteReceiptsDoc(int id)
        {
            var delReceip = await _skladBd.ReceiptsDocDb.FindAsync(id);
            _skladBd.ReceiptsDocDb.Remove(delReceip);
            await _skladBd.SaveChangesAsync();
        }
    }
}
