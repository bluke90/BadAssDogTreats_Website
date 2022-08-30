using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BadAssDogTreats_Website.Pages
{
    public class StoreItemPageModel : PageModel
    {

        private readonly WebContext _context;

        public StoreItemPageModel(WebContext context)
        {
            _context = context;
        }

        public StoreItem Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StoreItem == null)
            {
                return NotFound();
            }

            Item = await _context.StoreItem.Include(m => m.Image).FirstOrDefaultAsync();
            if (Item == null)
            {

                return NotFound();
            
            }


            return Page();
        }
    }
}
