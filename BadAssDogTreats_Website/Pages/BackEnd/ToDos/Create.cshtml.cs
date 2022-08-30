using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;

namespace BadAssDogTreats_Website.Pages.BackEnd.ToDos
{
    public class CreateModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;

        public CreateModel(BadAssDogTreats_Website.Data.WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDo ToDo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ToDo.CreationDate = DateTime.Now;
            if (!ModelState.IsValid || _context.ToDo == null || ToDo == null)
            {
                return Page();
            }

            _context.ToDo.Add(ToDo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
