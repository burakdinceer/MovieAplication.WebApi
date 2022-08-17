using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAplication.WebApi.Entities;
using MovieAplication.WebApi.Interfaces;
using MovieAplication.WebApi.Repositories;
using MovieAplication.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace MovieAplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IGenericRepository<Serial> _serialRepository;
        private readonly IGenericRepository<Genre> _genreRepository;

        public MovieController(IGenericRepository<Movie> movieRepository, IGenericRepository<Serial> serialRepository, IGenericRepository<Genre> genreRepository)
        {
            _movieRepository = movieRepository;
            _serialRepository = serialRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        [Route("GetList")]
        public List<MovieGetListQuery> GetList()
        {
            var query = _movieRepository.GetAll().Select(x => new MovieGetListQuery
            {
                Description = x.Description,
                Duration = x.Duration,
                Name = x.Name,
                Rating = x.Rating,
                GenreName = x.Genre?.Name,
                MovieId = x.MovieId,
                GenreId = x.GenreId,

            }).ToList();
            return query;
        }
        [HttpGet]
        [Route("GetId")]
        public MovieGetIdQuery GetId(int id)
        {
            var query = _movieRepository.GetId(id);
            if (query == null)
            {
                return null;
            }
            else
            {
               var result = _movieRepository.GetAll().Where(x => x.MovieId == id).Select(x => new MovieGetIdQuery
                {
                    Description = x.Description,
                    Duration = x.Duration,
                    GenreDescription = x.Genre?.Description,
                    GenreName = x.Genre?.Name,
                    Name = x.Name,
                    Rating = x.Rating,

                }).FirstOrDefault();
                return result;
            }
        }
    }
}
