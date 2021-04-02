using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRenterWebApp.Models;

namespace MovieRenterWebApp.ViewModels
{
    public class MoviesView
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

    }
}