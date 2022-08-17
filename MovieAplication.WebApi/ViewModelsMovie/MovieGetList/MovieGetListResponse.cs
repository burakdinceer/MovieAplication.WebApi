using MovieAplication.WebApi.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAplication.WebApi.ViewModels
{
    public class MovieGetListResponse
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public decimal Rating { get; set; }
        
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
