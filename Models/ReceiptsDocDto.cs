namespace ApiForTest.Models
{
    public class ReceiptsDocDto
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public List<ReceiptsResourceDto> receiptsResourceDto { get; set; } = new();

        public ReceiptsResourceDto receiptsResource { get; set; }
    }
}
