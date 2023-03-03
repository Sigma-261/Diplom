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

        /// <summary>
        /// Просмотри сведений о новости
        /// </summary>
        /// <param name="id">Id возвращаемого элемента</param>
        /// <returns></returns>
        public ActionResult GetNews(int id)
        {
            News? news = db.News.Find(id);
            if (news != null)
            {
                return PartialView("Read", news);
            }
            return View("Index");
        }

        // Добавление
        public ActionResult CreateNews()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNews(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Редактирование
        public ActionResult UpdateNews(int id)
        {
            News? news = db.News.Find(id);
            if (news != null)
            {
                return PartialView("Update", news);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateNews(News news)
        {
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Удаление
        public ActionResult DeleteNews(int id)
        {
            News? news = db.News.Find(id);
            if (news != null)
            {
                return PartialView("Delete", news);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNews(News news)
        {
            if (news != null)
            {
                db.News.Remove(news);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
