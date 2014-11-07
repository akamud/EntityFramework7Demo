using EntityFramework7Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Framework.Logging;
using Microsoft.Framework.DependencyInjection.Advanced;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Fallback;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Data.Entity;

namespace EntityFramework7Demo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var db = new BloggingContext();

            db.Configuration.LoggerFactory.AddProvider(
                new DiagnosticsLoggerProvider(
                    new SourceSwitch("SourceSwitch", "Verbose"),
                    new ConsoleTraceListener()));

            int id = 1;
            var query = db.Blogs.Include(b => b.Posts).Where(b => b.BlogId == id).OrderByDescending(b => b.Url);
            //var query = db.Blogs.Include(b => b.Posts).Where(b => b.BlogId == id && b.Posts.Any(p => p.Title == "Teste")).OrderByDescending(b => b.Url);
            //var query = db.Blogs.Include(b => b.Posts).Where(b => b.BlogId == id).OrderByDescending(b => b.Url).Skip(1).Take(10);

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