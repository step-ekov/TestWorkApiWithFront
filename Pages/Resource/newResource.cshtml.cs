using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiForTest.Pages.Resource
{
    public class AddItemsModel : PageModel
    {
        public int? Id { get; set; }

        public void OnGet(int? id)
        {
            Id = id;
        }
    }
}
