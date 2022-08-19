using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAplication.WebApi.Entities;
using MovieAplication.WebApi.Interfaces;
using MovieAplication.WebApi.ViewModelsSerial.SerialAdd;
using MovieAplication.WebApi.ViewModelsSerial.SerialGetId;
using MovieAplication.WebApi.ViewModelsSerial.SerialGetList;
using MovieAplication.WebApi.ViewModelsSerial.SerialUpdate;
using System.Collections.Generic;
using System.Linq;

namespace MovieAplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialController : ControllerBase
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IGenericRepository<Serial> _serialRepository;
        private readonly IGenericRepository<Genre> _genreRepository;

        public SerialController(IGenericRepository<Movie> movieRepository, IGenericRepository<Serial> serialRepository, IGenericRepository<Genre> genreRepository)
        {
            _movieRepository = movieRepository;
            _serialRepository = serialRepository;
            _genreRepository = genreRepository;
        }


        [HttpGet]
        [Route("GetList")]
        public List<SerialGetListResponse> GetList()
        {
            var list = _serialRepository.GetAll().Select(x => new SerialGetListResponse
            {
                Description = x.Description,
                Episode = x.Episode,
                Seison = x.Seison,
                GenreName = x.Genre.Name,
                Name = x.Name,
                Rating = x.Rating
            }).ToList();

            return list;
        }

        [HttpGet]
        [Route("GetId")]
        public SerialGetIdResponse GetId(int id)
        {
            var getId = _serialRepository.GetId(id);
            if (getId == null)
                return null;
            else
            {
                var result = _serialRepository.GetAll().Where(x => x.SerialId == id).Select(x => new SerialGetIdResponse
                {
                    Description = x.Description,
                    Episode = x.Episode,
                    GenreDescription = x.Genre.Description,
                    GenreName = x.Genre.Name,
                    Name = x.Name,
                    Rating = x.Rating,
                    Seison = x.Seison,
                }).SingleOrDefault();
                return result;
            }

        }
        [HttpPut]
        [Route("Update")]
        public SerialGetIdResponse Update(SerialUpdateRequest model, int id)
        {
            var control = _serialRepository.GetId(id);
            if (control == null)
                return null;
            else
            {
                control.Description = model.Description;
                control.Episode = model.Episode;
                control.Name = model.Name;
                control.Rating = model.Rating;
            }
            _serialRepository.UpdateT(control);
            var result = _serialRepository.GetId(id);

            SerialGetIdResponse resultResponse = new SerialGetIdResponse()
            {
                Description = result.Description,
                Episode = result.Episode,
                GenreDescription = result.Genre.Description,
                GenreName = result.Genre.Name,
                Name = result.Name,
                Rating = result.Rating,
                Seison = result.Seison,
            };
            return resultResponse;

        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(SerialAddRequest model)
        {
            Serial newSerial = new Serial()
            {
                Description = model.Description,
                Episode = model.Episode,
                GenreId = model.GenreId,
                Rating = model.Rating,
                Seison = model.Seison,
                Name = model.Name,

            };

            var create = _serialRepository.AddT(newSerial);
            if (create == null)
                return BadRequest();
            else
                return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(int id)
        {
            var delete = _serialRepository.GetId(id);
            if (delete != null)
            {
                _serialRepository.DeleteT(id);
                return true;
            }
            else
                return false;

        }






    }
}

