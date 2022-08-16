using MovieAplication.WebApi.Entities;
using MovieAplication.WebApi.Entities.Data;
using MovieAplication.WebApi.Interfaces;

namespace MovieAplication.WebApi.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenericRepository<Genre>
    {
        public GenreRepository(DataContext context) : base(context)
        {
        }
    }
}
