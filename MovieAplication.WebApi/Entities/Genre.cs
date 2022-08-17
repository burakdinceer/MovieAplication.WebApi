using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAplication.WebApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Serial> Serials { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        

    }
}
