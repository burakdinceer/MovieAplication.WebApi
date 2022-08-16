using MovieAplication.WebApi.Entities;
using MovieAplication.WebApi.Entities.Data;
using MovieAplication.WebApi.Interfaces;

namespace MovieAplication.WebApi.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IGenericRepository<Movie>
    {
        public MovieRepository(DataContext context) : base(context)
        {
        }
    }
}
