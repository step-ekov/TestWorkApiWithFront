using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiForTest.Pages.Unit
{
    public class newUnitModel : PageModel
    {
        public int? Id { get; set; }

        public void OnGet(int? id)
        {
            Id = id;
        }
    }
}
