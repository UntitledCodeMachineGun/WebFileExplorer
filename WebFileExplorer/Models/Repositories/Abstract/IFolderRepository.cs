namespace WebFileExplorer.Models.Repositories.Abstract
{
    public interface IFolderRepository
    {
        IQueryable<Folder> GetFolders();
        IQueryable<Folder> GetRootFolders();
        IQueryable<Folder> GetChildFolders(int id);
        Folder GetFolder(int id);
        void SaveFolder(Folder folder);
        void DeleteFolder(int id);
    }
}
