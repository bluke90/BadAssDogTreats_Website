using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;

namespace BadAssDogTreats_Website.Pages.BackEnd.Store
{
    public class EditModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;

        public EditModel(BadAssDogTreats_Website.Data.WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StoreItem StoreItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StoreItem == null)
            {
                return NotFound();
            }

            var storeitem =  await _context.StoreItem.FirstOrDefaultAsync(m => m.ID == id);
            if (storeitem == null)
            {
                return NotFound();
            }
            StoreItem = storeitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StoreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreItemExists(StoreItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StoreItemExists(int id)
        {
          return (_context.StoreItem?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
