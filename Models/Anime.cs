using System.ComponentModel.DataAnnotations;

namespace AnimeAPI.Models
{
    public class Anime
    {
        [Key]
        public int animeID { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public int episode { get; set; }

    }
}
