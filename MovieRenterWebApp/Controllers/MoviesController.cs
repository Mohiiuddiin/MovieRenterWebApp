using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRenterWebApp.Models;

namespace MovieRenterWebApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };
            return View(movie);
        }
    }
}