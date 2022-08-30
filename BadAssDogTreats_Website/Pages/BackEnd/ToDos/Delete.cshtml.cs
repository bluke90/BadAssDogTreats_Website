using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;

namespace BadAssDogTreats_Website.Pages.BackEnd.ToDos
{
    public class DeleteModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;

        public DeleteModel(BadAssDogTreats_Website.Data.WebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ToDo ToDo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDo == null)
            {
                return NotFound();
            }

            var todo = await _context.ToDo.FirstOrDefaultAsync(m => m.Id == id);

            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                ToDo = todo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ToDo == null)
            {
                return NotFound();
            }
            var todo = await _context.ToDo.FindAsync(id);

            if (todo != null)
            {
                ToDo = todo;
                _context.ToDo.Remove(ToDo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
