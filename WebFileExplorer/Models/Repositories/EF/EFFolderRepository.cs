using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Domain;
using WebFileExplorer.Models.Repositories.Abstract;

namespace WebFileExplorer.Models.Repositories.EF
{
    public class EFFolderRepository : IFolderRepository
    {
        private readonly AppDbContext context;

        public EFFolderRepository(AppDbContext context) 
        {
            this.context = context;
        }

        public void DeleteFolder(int id)
        {
            context.Folders.Remove(new Folder() { Id = id });
            context.SaveChanges();
        }

        public Folder GetFolder(int id)
        {
            return context.Folders.FirstOrDefault(x => x.Id == id) ?? new Folder() { Name = "New Folder"};
        }

        public IQueryable<Folder> GetFolders()
        {
            return context.Folders;
        }

        public IQueryable<Folder> GetRootFolders()
        {
            return context.Folders.Where(x => x.RootFolderId == null);
        }

        public IQueryable<Folder> GetChildFolders(int id)
        {
            return context.Folders.Where(x => x.RootFolderId == id);
        }

        public void SaveFolder(Folder folder)
        {
            if (folder.Id == default)
            {
                context.Entry(folder).State = EntityState.Added;
            }
            else
            {
                context.Entry(folder).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
