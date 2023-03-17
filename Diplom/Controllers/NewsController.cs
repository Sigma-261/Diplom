using Diplom.DB;
using Diplom.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Controllers
{
    public class NewsController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment _appEnvironment;

        public NewsController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View(db.Files.ToList());
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
        public async Task<IActionResult> CreateNews(News news, IFormFileCollection uploads)
        {
            db.News.Add(news);
            db.SaveChanges();

            foreach (var uploadedFile in uploads)
            {
                string pathdir = _appEnvironment.WebRootPath + "/Images/News/" + news.Id;
                DirectoryInfo dirInfo = new DirectoryInfo(pathdir);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                // путь к папке /Images/News/
                string path = "/Images/News/" + news.Id + "/" + uploadedFile.FileName;
                // сохраняем файл в папку /Images/News/ в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                db.Files.Add(file);
            }
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
