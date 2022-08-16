using MovieAplication.WebApi.Entities;
using MovieAplication.WebApi.Entities.Data;
using MovieAplication.WebApi.Interfaces;

namespace MovieAplication.WebApi.Repositories
{
    public class SerialRepository : GenericRepository<Serial>, IGenericRepository<Serial>
    {
        public SerialRepository(DataContext context) : base(context)
        {
        }
    }
}
