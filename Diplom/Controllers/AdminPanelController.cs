using Diplom.DB;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Controllers
{
    public class AdminPanelController : Controller
    {
        ApplicationContext db;
        public AdminPanelController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        #region Кружки

        public async Task<IActionResult> ClubsPage()
        {
            return View(await db.Clubs.ToListAsync());
        }

        public ActionResult GetClub(int id)
        {
            Club? club = db.Clubs.Find(id);
            if (club != null)
            {
                return PartialView("Clubs/Read", club);
            }
            return View("Index");
        }

        // Добавление
        public ActionResult CreateClub()
        {
            return PartialView("Clubs/Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClub(Club club)
        {
            db.Clubs.Add(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Редактирование
        public ActionResult UpdateClub(int id)
        {
            Club? club = db.Clubs.Find(id);
            if (club != null)
            {
                return PartialView("Clubs/Update", club);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updateclub(Club club)
        {
            db.Entry(club).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Удаление
        public ActionResult DeleteClub(int id)
        {
            Club? club = db.Clubs.Find(id);
            if (club != null)
            {
                return PartialView("Clubs/Delete", club);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClub(Club club)
        {
            if (club != null)
            {
                db.Clubs.Remove(club);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion Кружки

        #region Новости

        public async Task<IActionResult> NewsPage()
        {
            return View(await db.News.ToListAsync());
        }

        public ActionResult GetNews(int id)
        {
            News? news = db.News.Find(id);
            if (news != null)
            {
                return PartialView("News/Read", news);
            }
            return View("NewsPage");
        }

        // Добавление
        public ActionResult CreateNews()
        {
            return PartialView("News/Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNews(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("NewsPage");
        }

        // Редактирование
        public ActionResult UpdateNews(int id)
        {
            News? news = db.News.Find(id);
            if (news != null)
            {
                return PartialView("News/Update", news);
            }
            return View("NewsPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateNews(News news)
        {
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("NewsPage");
        }

        // Удаление
        public ActionResult DeleteNews(int id)
        {
            News? news = db.News.Find(id);
            if (news != null)
            {
                return PartialView("News/Delete", news);
            }
            return View("NewsPage");
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
            return RedirectToAction("NewsPage");
        }

        #endregion Новости
    }
}
