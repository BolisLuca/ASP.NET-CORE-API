using API_Chess.Entities;
using API_Chess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Chess.Controllers
{
    [Route("chess")] //Necessario --> definisce su quale rotta si attiva il controller
    [ApiController] //the class with the [ApiController] attribute. This attribute indicates that the controller responds to web API requests.
                    //Definisce che la classse che segue si occuperà di gestire richieste API
    public class GamesController : Controller
    {
        private readonly dbchessgamesContext _context;

        public GamesController(dbchessgamesContext context)
        {
            _context = context; //Prendo il context 
        }

        [HttpGet("games")] //al percorso chess/games --> è possibile quindi definire sottopercorsi. Anche  es: [HttpGet("{id}")] chess/5 e prende 5 come parametro e lo salva nella varibile id
        public async Task<ActionResult<IEnumerable<GamesDTO>>> GetGames([FromQuery] string gameid = "", [FromQuery] string rated = "", [FromQuery] string victory_status = "", [FromQuery] string winner = "") //Dentro a <ActionResult<-- qui---IEnumerable<Games>----> Va il tipo della risosta che si vuole restituire
        {

            if (_context.Games.Any())
            {
                var result = await _context.Games.Select(
        s => new GamesDTO //DTO 
        {
            Pkid = s.Pkid,
            Rated = s.Rated,
            CreatedAt = s.CreatedAt,
            LastMoveAt = s.LastMoveAt,
            Turns = s.Turns,
            VictoryStatus = s.VictoryStatus,
            Winner = s.Winner,
            IncrementCode = s.IncrementCode,
            FkwhiteId = s.FkwhiteId,
            FkblackId = s.FkblackId,
            OpeningEco = s.OpeningEco
        }
    ).ToListAsync();

                //Filtri
                if (gameid != "")
                {
                    result = result.Where(i => i.Pkid == gameid).ToList();
                }
                if(rated != "")
                {
                    result = result.Where(i => i.Rated == bool.Parse(rated)).ToList();
                }
                if(victory_status != "")
                {
                    result = result.Where(i => i.VictoryStatus == victory_status).ToList();
                }
                if(winner != "")
                {
                    result = result.Where(i => i.Winner == winner).ToList();
                }


                return result; //-->N.B. Di tutto ciò che viene eseguito viene svolto il pars in JSON in automatico e viene automaticamente
                               //inserito nel bosy della risposta, e viene definito anche l'header a 200 di default.
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpGet("game")] //al percorso chess/games --> è possibile quindi definire sottopercorsi. Anche  es: [HttpGet("{id}")] chess/5 e prende 5 come parametro e lo salva nella varibile id
        public async Task<ActionResult<List<MovesDTO>>> GetMoves([FromQuery] string gameid) //Dentro a <ActionResult<-- qui---IEnumerable<Games>----> Va il tipo della risosta che si vuole restituire
        {
            if (_context.Moves.Any())
            {
                 var Movesofthegame = await _context.Moves.Where(i=> i.PpkfkGameId == gameid).Select(s=> new MovesDTO
                 {
                     Ppkid = s.Ppkid,
                     PpkfkGameId = s.PpkfkGameId,
                     Move = s.Move
            }
                 ).ToListAsync();

               
                

                return Movesofthegame;
                // return await _context.Moves.FindAsync().ToList(); //-->N.B. Di tutto ciò che viene eseguito viene svolto il pars in JSON in automatico e viene automaticamente
                //inserito nel bosy della risposta, e viene definito anche l'header a 200 di default.
            }
            else
            {
                return new EmptyResult();
            }
            return new EmptyResult();
        }
    }
}
