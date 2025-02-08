using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext Context {  get; set; }

        //this constructor accept dbcontext enable by DI
        public HomeController(MovieContext ctx)
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var movies = Context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }

        
    }
}
