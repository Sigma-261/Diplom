using Diplom.DB;
using Diplom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Controllers
{
    public class NewsController : Controller
    {
        ApplicationContext db;
        public NewsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.News.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(News news)
        {
            news.CreatedDate = DateTime.Now;
            db.News.Add(news);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
