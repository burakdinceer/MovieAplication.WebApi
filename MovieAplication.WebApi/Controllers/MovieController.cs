using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAplication.WebApi.Entities;
using MovieAplication.WebApi.Interfaces;
using MovieAplication.WebApi.Repositories;
using MovieAplication.WebApi.ViewModels;
using MovieAplication.WebApi.ViewModelsMovie.MovieAdd;
using MovieAplication.WebApi.ViewModelsMovie.MovieUpdate;
using MovieAplication.WebApi.ViewModelsMovieValidation.MovieGetIdValidation;
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
        public List<MovieGetListResponse> GetList()
        {
            var query = _movieRepository.GetAll().Select(x => new MovieGetListResponse
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
        public MovieGetIdResponse GetId(int id)
        {
            var query = _movieRepository.GetId(id);
            if (query == null)
            {
                return null;
            }
            else
            {
               var result = _movieRepository.GetAll().Where(x => x.MovieId == id).Select(x => new MovieGetIdResponse
                {
                    Description = x.Description,
                    Duration = x.Duration,
                    GenreDescription = x.Genre?.Description,
                    GenreName = x.Genre?.Name,
                    Name = x.Name,
                    Rating = x.Rating,
                    MovieId=x.MovieId,

                }).FirstOrDefault();
               
                return result;
            }
        }

        [HttpPut]
        [Route("Update")]
        public MovieUpdateResponse MovieUpdate(MovideUpdateRequest model, int id)
        {
            var control = _movieRepository.GetId(id);
            if (control == null)
                return null;
            else
            {
                control.Name = model.Name;
                control.Description = model.Description;
                control.Duration= model.Duration;
            }

            _movieRepository.UpdateT(control);
            var result =_movieRepository.GetId(id);
            MovieUpdateResponse resultUpdate = new MovieUpdateResponse
            {

                Duration = result.Duration,
                Description = result.Description,
                GenreDescription = result.Genre.Description,
                GenreName = result.Genre.Name,
                Name = result.Name,
                Rating = result.Rating,
            };
            return resultUpdate;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult MovieAdd(MovieAddRequest model)
        {
            Movie newMovie = new Movie
            {
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                GenreId = model.GenreId,
                Rating = model.Rating,
            };

            var create = _movieRepository.AddT(newMovie);
            if (create == null)
                return null;
            else
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public bool MovieDelete(int id)
        {
            var delete = _movieRepository.GetId(id);
            if (delete != null)
            {
                _movieRepository.DeleteT(id);
                return true;
            }
            else
                return false;
               

        }
    }
}
