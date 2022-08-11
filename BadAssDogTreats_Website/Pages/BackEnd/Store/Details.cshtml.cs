using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;

namespace BadAssDogTreats_Website.Pages.BackEnd.Store
{
    public class DetailsModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;

        public DetailsModel(BadAssDogTreats_Website.Data.WebContext context)
        {
            _context = context;
        }

      public StoreItem StoreItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StoreItem == null)
            {
                return NotFound();
            }

            var storeitem = await _context.StoreItem.FirstOrDefaultAsync(m => m.ID == id);
            if (storeitem == null)
            {
                return NotFound();
            }
            else 
            {
                StoreItem = storeitem;
            }
            return Page();
        }
    }
}
