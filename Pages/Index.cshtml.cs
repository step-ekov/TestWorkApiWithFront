using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiForTest.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "";

        public void OnGet()
        {
            Message = "Привет! Сегодня отличный день.";
        }
    }
}
