using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadAssDogTreats_Website.Data;
using BadAssDogTreats_Website.Models;

namespace BadAssDogTreats_Website.Pages.BackEnd.Store
{
    public class CreateModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;
        private IWebHostEnvironment _environment;


        public CreateModel(BadAssDogTreats_Website.Data.WebContext context, IWebHostEnvironment environment) {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public IFormFile? Image1 { get; set; }
        
        [BindProperty]
        public StoreItem StoreItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StoreItem == null || StoreItem == null)
            {
                return Page();
            }

            Image1 = HttpContext.Request.Form.Files[0];

                if (Image1 != null) {

                var filepath = Path.Combine(_environment.WebRootPath, "Images", Image1.FileName);

                StoreItem.Image = new Image()
                {
                    FileName = Image1.FileName,
                    FilePath = filepath,
                    StoreItemId = StoreItem.ID
                };

                using (var fileStream = new FileStream(filepath, FileMode.Create)) {
                    await Image1.CopyToAsync(fileStream);
                }

                _context.Image.Add(StoreItem.Image);
            }


            _context.StoreItem.Add(StoreItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
