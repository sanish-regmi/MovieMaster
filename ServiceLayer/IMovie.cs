using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceLayer.Model;

namespace ServiceLayer
{
    public interface IMovie
    {
       
        public List<Movie> getMovie();
        public Task<ListViewModel> getActor(string search);
    }
}
