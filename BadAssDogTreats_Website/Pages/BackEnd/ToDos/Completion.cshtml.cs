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
    public class CompletionModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;

        public CompletionModel(BadAssDogTreats_Website.Data.WebContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            var compNotes = ToDo.CompletionNotes;
            ToDo = await _context.ToDo.FirstOrDefaultAsync(m => m.Id == ToDo.Id);

            _context.Attach(ToDo).State = EntityState.Modified;
            ToDo.CompletionNotes = compNotes;
            ToDo.Completed = true;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException ex) { 
                if (!ToDoExists(ToDo.Id)){
                    return NotFound();
                } else {
                    throw ex;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoExists(int id)
        {
            return (_context.ToDo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
