using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAplication.WebApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("SerialId")]
        public virtual Serial Serial { get; set; }
        public int SeialId { get; set; }

    }
}
