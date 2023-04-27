using Microsoft.AspNetCore.Mvc;
using WebFileExplorer.Domain;
using WebFileExplorer.Models.VievModels;
using Newtonsoft.Json;
using WebFileExplorer.Models;

namespace WebFileExplorer.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataManager dataManager;
        public readonly IWebHostEnvironment env;
        public HomeController(DataManager dataManager, IWebHostEnvironment env)
        {
            this.dataManager = dataManager;
            this.env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new FolderViewModel() { Folders = dataManager.Folders.GetRootFolders() });
        }

        [HttpGet]
        public IActionResult OpenFolder(int id)
        {
            var model = new FolderViewModel()
            {
                Folder = dataManager.Folders.GetFolder(id),
                Folders = dataManager.Folders.GetChildFolders(id)
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Import(IFormFile data)
        {
            if(data == null)
            {
                return RedirectToAction("Index");
            }
            if (!Path.GetFileName(data.FileName).EndsWith(".json"))
            {
                ViewBag.Error = "Invalid file type";
            }
            else 
            {
                var path = Path.Combine(env.WebRootPath, "JSONData/", data.FileName);
                using (var fs = new FileStream(path, FileMode.Create))
                { 
                    data.CopyTo(fs);
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    var dataString = sr.ReadToEnd();
                    List<Folder> folders = JsonConvert.DeserializeObject<List<Folder>>(dataString);
                    if (folders != null)
                    {
                        folders.ForEach(x =>
                        {
                            Folder folder = new Folder()
                            {
                                Name = x.Name,
                                RootFolderId = x.RootFolderId,
                            };
                            dataManager.Folders.SaveFolder(folder);
                        });
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult Export() 
        {
            IQueryable<Folder> folders = dataManager.Folders.GetFolders();
            var json = JsonConvert.SerializeObject(folders, Formatting.Indented);
            var fileName = "Exported.json";
            var path = Path.Combine(env.WebRootPath, "Exported/", fileName);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
            }

            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
