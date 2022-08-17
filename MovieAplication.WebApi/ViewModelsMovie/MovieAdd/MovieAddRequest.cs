namespace MovieAplication.WebApi.ViewModelsMovie.MovieAdd
{
    public class MovieAddRequest
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public decimal Rating { get; set; }
        public int GenreId { get; set; }
    }
}
