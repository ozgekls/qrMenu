
using Microsoft.EntityFrameworkCore;

namespace qrMenu.Models

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
        
        }
        public DbSet<MenuItem> MenuItems { get; set; } // EF ile DB'ye yansıyacak tablo

        public DbSet<AdminUser> AdminUsers { get; set; } // admin bilgilerini tutacak 


    }
}
