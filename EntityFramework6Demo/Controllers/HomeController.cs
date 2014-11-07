using EntityFramework6Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EntityFramework6Demo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var db = new BloggingEntities();

            int id = 1;
            var query = db.Blog.Where(b => b.BlogId == id).OrderByDescending(b => b.Url);
            //var query = db.Blog.Include(b => b.Post).Where(b => b.BlogId == id).OrderByDescending(b => b.Url);
            //var query = db.Blog.Include(b => b.Post).Where(b => b.BlogId == id && b.Post.Any(p => p.Title == "Teste")).OrderByDescending(b => b.Url);
            //var query = db.Blog.Include(b => b.Post).Where(b => b.BlogId == id).OrderByDescending(b => b.Url).Skip(1).Take(10);

            var lista = await query.ToListAsync();

            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}