namespace MovieAplication.WebApi.ViewModelsSerial.SerialAdd
{
    public class SerialAddRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int Episode { get; set; }
        public int Seison { get; set; }
        public int GenreId { get; set; }

    }
}
