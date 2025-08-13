namespace ApiForTest.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int NumberRDoc { get; set; }
        public DateOnly DateRDoc {  get; set; }
        public string NameResource { get; set; }
        public string NameUnit {  get; set; }
        public int CountRResource { get; set; }
    }
}
