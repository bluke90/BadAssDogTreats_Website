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
    public class IndexModel : PageModel
    {
        private readonly BadAssDogTreats_Website.Data.WebContext _context;

        public IndexModel(BadAssDogTreats_Website.Data.WebContext context)
        {
            _context = context;
        }

        public IList<StoreItem> StoreItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StoreItem != null)
            {
                StoreItem = await _context.StoreItem.ToListAsync();
            }
        }
    }
}
