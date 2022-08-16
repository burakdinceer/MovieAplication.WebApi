using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAplication.WebApi.Entities
{
    public class Serial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int  Episode { get; set; }
        public int Seison { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

    }
}
