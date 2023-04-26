using WebFileExplorer.Models.Repositories.Abstract;

namespace WebFileExplorer.Domain
{
    public class DataManager
    {
        public IFolderRepository Folders { get; set; }

        public DataManager(IFolderRepository folders)
        {
            Folders = folders;
        }
    }
}
