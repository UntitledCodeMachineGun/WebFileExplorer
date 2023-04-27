namespace WebFileExplorer.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RootFolderId { get; set; }
    }
}
