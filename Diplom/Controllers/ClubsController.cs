using Diplom.DB;
using Diplom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Controllers
{
    public class ClubsController : Controller
    {
        ApplicationContext db;
        public ClubsController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Clubs.ToListAsync());
        }

        /// <summary>
        /// Просмотри сведений о кружке
        /// </summary>
        /// <param name="id">Id возвращаемого элемента</param>
        /// <returns></returns>
        public ActionResult GetClub(int id)
        {
            Club? club = db.Clubs.Find(id);
            if (club != null)
            {
                return PartialView("Read", club);
            }
            return View("Index");
        }

        // Добавление
        public ActionResult CreateClub()
        {
            return PartialView("Create");
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
                return PartialView("Update", club);
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
                return PartialView("Delete", club);
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
    }
}
