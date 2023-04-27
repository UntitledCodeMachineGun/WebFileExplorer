using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Models;

namespace WebFileExplorer.Domain

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Folder> Folders { get; set; }

    }
}
