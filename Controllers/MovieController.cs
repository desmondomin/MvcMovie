using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext Context { get; set; }

        public MovieController(MovieContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add New Movie";
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Movie());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Movie";
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
            //LINQ query to find movie by Id - pk search
            var movie = Context.Movies.Find(id);
            return View(movie);

        }

        [HttpGet]
        //id parameter is sent from the url
        public IActionResult Delete(int id)
        {
            //ViewBag.Action = $"{nameof(Delete)}";
            var movie = Context.Movies.Find(id) ;
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            Context.Movies.Remove(movie);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            //either add a new movie or edit a movie
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    Context.Movies.Add(movie);
                } else
                {
                    Context.Movies.Update(movie);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                //this will show validation error
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                ViewBag.Genres  = Context.Genres.OrderBy(g => g.Name).ToList();
                return View(movie);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
