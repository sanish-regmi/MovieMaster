using System;
using System.Collections.Generic;

namespace ServiceLayer.Model
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
        }

        public List<Actor> Actors { get; set; }
        public Movie Movie { get; set; }
    }
}
