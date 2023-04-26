using Microsoft.AspNetCore.Mvc;
using WebFileExplorer.Domain;
using WebFileExplorer.Models.VievModels;

namespace WebFileExplorer.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        { 
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(new FolderViewModel() { Folders = dataManager.Folders.GetRootFolders()});
        }

        public IActionResult OpenFolder(int id)
        {
            var model = new FolderViewModel()
            {
                Folder = dataManager.Folders.GetFolder(id),
                Folders = dataManager.Folders.GetChildFolders(id)
            };
            return View("Index", model);
        }
    }
}
