using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRenterWebApp.Models;
using MovieRenterWebApp.ViewModels;

namespace MovieRenterWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext;

        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        public ActionResult Index()
        {
            var movies = dbContext.Movies.Include(m => m.Genre).ToList();
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }
        public ActionResult Save()
        {            
            var viewModel = new MoviesView()
            {
                Genres = dbContext.Genres.ToList()
        };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int Id)
        {
            var viewModel = new MoviesView()
            {
                Genres = dbContext.Genres.ToList(),
                Movie = dbContext.Movies.SingleOrDefault(x=>x.Id==Id)
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var updateMovie = dbContext.Movies.FirstOrDefault(x => x.Id == movie.Id);

            updateMovie.Name = movie.Name;
            updateMovie.ReleaseDate = movie.ReleaseDate;
            updateMovie.DateAdded = movie.DateAdded;
            updateMovie.GenreId = movie.GenreId;
            updateMovie.NumberInStock = movie.NumberInStock;

            dbContext.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        
        public ActionResult Details(int Id)
        {
            var movie = dbContext.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Delete(int Id)
        {
            var movie = dbContext.Movies.FirstOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        // GET: Movies
        //public ActionResult Random()
        //{
        //    Movie movie = new Movie()
        //    {
        //        Id = 1,
        //        Name = "Shrek"
        //    };

        //    var customers = new List<Customer>
        //    {
        //        new Customer{Name="Customer1"},
        //        new Customer{Name="Customer2"},
        //        new Customer{Name="Customer3"},
        //    };

        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View();
        //}

        //public ActionResult Edit(int Id)
        //{
        //    return Content("id = "+Id);
        //}

        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue){
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("Page Index {0} and Sort By {1}", pageIndex, sortBy));
        //}


        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, string month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}