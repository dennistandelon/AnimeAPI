using AnimeAPI.Models;
using AnimeAPI.Models.Request;
using AnimeAPI.Output;
using AnimeAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Helper
{
    public class AnimeHelper
    {
        private AnimeDBContext dBContext { get; set; }
        public AnimeHelper(AnimeDBContext dBContext) {
            this.dBContext = dBContext;
        }
        public List<Anime> getAllAnime()
        {
            List<Anime> a = dBContext.anime.Select(x => x).ToList();

            return a;
        }

        public Status addNewAnime(List<Anime> newAnime)
        {
            try
            {
                foreach (Anime item in newAnime)
                {                
                    dBContext.anime.Add(item);
                }
                dBContext.SaveChanges();
            } catch(Exception ex) { 
                return new Status { code = 4000, message = ex.Message };
            }

            return new Status { code = 200, message = "Successfully added" };
        }

        public Status updateAnime(Anime newAnime)
        {
            try
            {
                Anime data = dBContext.anime.Where(x => x.animeID == newAnime.animeID).FirstOrDefault();

                if(data == null)
                {
                    return new Status { code = 404, message = "Data not Found" };
                }

                data.title = newAnime.title;
                data.description = newAnime.description;
                data.episode = newAnime.episode;

                dBContext.anime.Update(data);
                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Status { code = 4000, message = ex.Message };
            }

            return new Status { code = 200, message = "Successfully updated" };
        }

        public Status deleteAnime(int id)
        {
            try
            {
                Anime data = dBContext.anime.Where(x => x.animeID == id).FirstOrDefault();

                if (data == null)
                {
                    return new Status { code = 404, message = "Data not Found" };
                }

                dBContext.anime.Remove(data);
                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Status { code = 4000, message = ex.Message };
            }

            return new Status { code = 200, message = "Successfully removed" };
        }

    }
}
