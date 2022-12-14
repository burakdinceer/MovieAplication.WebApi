using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAplication.WebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public decimal Rating { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
        public int GenreId { get; set; }




    }
}
