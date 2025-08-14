using System.ComponentModel.DataAnnotations;

namespace ApiForTest.Models
{
    public class Resource
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public bool State { get; set; } = false;
    }
}
