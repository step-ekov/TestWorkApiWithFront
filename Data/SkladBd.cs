using ApiForTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForTest.Data
{
    public class SkladBd : DbContext
    {
        public SkladBd(DbContextOptions<SkladBd> options) : base(options) { }

        public DbSet<Resource> ResourceDb { get; set; }
        public DbSet<Unit> UnitDb { get; set; }
        public DbSet<ReceiptsDoc> ReceiptsDocDb { get; set; }
        public DbSet<ReceiptsResource> ReceiptsResourcesDb { get; set; }
    }
}
