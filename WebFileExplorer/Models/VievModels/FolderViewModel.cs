namespace WebFileExplorer.Models.VievModels
{
    public class FolderViewModel
    {
        public IQueryable<Folder> Folders { get; set; }
        public Folder Folder { get; set; }
    }
}
