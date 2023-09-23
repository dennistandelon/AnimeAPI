namespace AnimeAPI.Models.Request
{
    public class AnimeRequest
    {
        public List<AnimeDTO> animes {  get; set; }
    }

    public class AnimeDTO
    {
        public string title { get; set; }
        public string? description { get; set; }
        public int episode { get; set; }
    }
}
