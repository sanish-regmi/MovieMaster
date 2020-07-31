using System;
using System.Collections.Generic;
using ServiceLayer.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class MovieRepository : IMovie
    {
        private AppDbContext _appDbContext;
        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ListViewModel> getActor(string search)
        {

           ListViewModel model = new ListViewModel();
            try
            {
                if (!String.IsNullOrEmpty(search))
                {
                    model.Actors = await _appDbContext.Actors.Where(x => x.FirstName.Contains(search)).ToListAsync();
                    model.Movies = await _appDbContext.Movies.Where(x => x.Name.Contains(search)).ToListAsync();
                }
            } catch (Exception ex)
            {
                throw ex;
            }

          return model;
        }

        public List<Movie> getMovie()
        {
            throw new NotImplementedException();
        }
    }
}
