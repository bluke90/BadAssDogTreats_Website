using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BadAssDogTreats_Website.Models;

namespace BadAssDogTreats_Website.Data
{
    public class WebContext : DbContext
    {
        public WebContext (DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        public DbSet<BadAssDogTreats_Website.Models.StoreItem> StoreItem { get; set; } = default!;
        public DbSet<BadAssDogTreats_Website.Models.Image> Image { get; set; } = default!; 
        public DbSet<BadAssDogTreats_Website.Models.ToDo>? ToDo { get; set; }
    }
}
