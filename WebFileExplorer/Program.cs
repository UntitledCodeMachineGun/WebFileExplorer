using WebFileExplorer.Domain;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Models.Repositories.Abstract;
using WebFileExplorer.Models.Repositories.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IFolderRepository, EFFolderRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB; Database=FileExplorer; Trusted_Connection=True;"));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("index", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("child", "{controller=Home}/{action=OpenFolder}/{id}");
});

app.Run();
