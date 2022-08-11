using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BadAssDogTreats_Website.Pages
{
    public class StoreModel : PageModel
    {
        private readonly WebContext _context;

        public StoreModel(WebContext context) {
            _context = context;
        }

        public List<StoreItem> StoreItems;

        public void OnGet()
        {
            StoreItems = _context.StoreItem.ToList();
        }
    }
}
