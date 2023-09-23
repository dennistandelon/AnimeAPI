using AnimeAPI.Helper;
using AnimeAPI.Models;
using AnimeAPI.Models.Request;
using AnimeAPI.Output;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controller
{
    [Route("/")]
    [ApiController]
    public class AnimeController : ControllerBase
    {

        private AnimeHelper helper;
        public AnimeController(AnimeHelper helper) {
            this.helper = helper;
        }

        [HttpGet("version")]
        [Produces("application/json")]
        public IActionResult Version()
        {
            try
            {
                return new OkObjectResult("Anime API V1.0");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("anime")]
        [Produces("application/json")]
        public IActionResult getAllAnime()
        {
            try
            {
                List<Anime> animeList = helper.getAllAnime();
                return new OkObjectResult(animeList);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("anime/add")]
        [Produces("application/json")]
        public IActionResult addNewAnime([FromBody] AnimeRequest request)
        {
            try
            {
                List<Anime> data = new List<Anime>();
                foreach (AnimeDTO item in request.animes)
                {
                    data.Add(new Anime { title = item.title, description = item.description, episode = item.episode });   
                }

                Status animeList = helper.addNewAnime(data);
                return new OkObjectResult(animeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("anime/update")]
        [Produces("application/json")]
        public IActionResult updateAnime([FromBody] Anime request)
        {
            try
            {
                Status animeList = helper.updateAnime(request);
                return new OkObjectResult(animeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("anime/delete")]
        [Produces("application/json")]
        public IActionResult deleteAnime([FromBody] int id)
        {
            try
            {
                Status animeList = helper.deleteAnime(id);
                return new OkObjectResult(animeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
