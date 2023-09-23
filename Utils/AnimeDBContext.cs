using AnimeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Utils
{
    public class AnimeDBContext: DbContext
    {
        public DbSet<Anime> anime { get; set; }
        public AnimeDBContext(DbContextOptions<AnimeDBContext> options) :base(options){ }
    }
}
