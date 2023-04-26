using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Models;

namespace WebFileExplorer.Domain

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>().HasData(new Folder
            {
                Id = 1,
                Name = "Creating Digital Images"
            });

            modelBuilder.Entity<Folder>().HasData(new Folder
            {
                Id = 2,
                Name = "Resources",
                RootFolderId = 1,
            });
            modelBuilder.Entity<Folder>().HasData(new Folder
            { 
                Id = 3,
                Name = "Evidence",
                RootFolderId = 1,
            });
            modelBuilder.Entity<Folder>().HasData(new Folder
            {
                Id = 4,
                Name = "Graphic Products",
                RootFolderId = 1,
            });
            modelBuilder.Entity<Folder>().HasData(new Folder 
            {
                Id = 5,
                Name = "Primary Sources",
                RootFolderId = 2
            });
            modelBuilder.Entity<Folder>().HasData(new Folder
            {
                Id = 6,
                Name = "Process",
                RootFolderId = 4
            });
            modelBuilder.Entity<Folder>().HasData(new Folder
            {
                Id = 7,
                Name = "Final Product",
                RootFolderId = 4,
            });
        }
    }
}
