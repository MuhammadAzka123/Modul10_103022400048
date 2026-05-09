using Microsoft.AspNetCore.Mvc;
using Modul10_103022400048;

namespace Modul10_103022400048.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public static List<Game> games = new List<Game>
        {
            new Game {
            id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS",
            Rating = 8.5, Platform = ["PC"], Mode = ["Multiplayer"], IsOnline = true, Harga = 0
            },
            new Game {
            id = 2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World",
            Rating = 9.5, Platform = ["PC, PS4, PS5, Xbox"], Mode = ["Singleplayer","Multiplayer"], IsOnline = true, Harga = 300000
            },
            new Game {
            id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG",
            Rating = 9.7, Platform = ["PC, PS4, PS5, Xbox, Switch"], Mode = ["Singleplayer"], IsOnline = false, Harga = 250000}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll()
        {
            return Ok(games);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(int id)
        {
            if (id < 1 || id > games.Count)
                return NotFound();

            return Ok(games[id - 1]);
        }

        [HttpPost]
        public ActionResult AddGame([FromBody] Game game)
        {
            if (game == null)
                return BadRequest("Data kosong / tidak terbaca");

            games.Add(game);
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            if (id < 1 || id > games.Count)
                return NotFound();

            games.RemoveAt(id - 1);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Game game)
        {
            games[id] = game;
            return Ok();
        }
    }
}
