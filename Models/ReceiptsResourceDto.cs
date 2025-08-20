namespace ApiForTest.Models
{
    public class ReceiptsResourceDto
    {
        public int Id { get; set; }

        public int ReceiptsDocId { get; set; }

        public int? ResourceID { get; set; }

        public int? UnitID { get; set; }

        public int Count { get; set; }
    }
}
