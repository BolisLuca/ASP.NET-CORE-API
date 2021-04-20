using ArticlesAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlesAPI.Controllers
{
    [ApiController] //Definisce che la classse che segue si occuperà di gestire richieste API
    [Route("articles")] //Rotta sulla quale si attiverà il controller --> le richieste a questa rotta verrano gestite da questo controller
    public class ArticlesController : ControllerBase
    {
        private readonly dbarticoliContext _context;
        public ArticlesController(dbarticoliContext context)
        {
            _context = context;
        }
        
        [HttpPost("add")] // articles/add in POST
        public async Task<ActionResult<Articoli>> AddArticoloAsync([FromForm] string titolo, [FromForm] string descrizione = "", [FromForm] decimal prezzo = -1)
        {
            if (string.IsNullOrEmpty(titolo))
            {
                return BadRequest("Missing titolo parameter.");
            }
            else
            {

                Articoli NuovoArticolo = new Articoli();
                NuovoArticolo.Titolo = titolo;
                if (prezzo > 0)
                {
                    NuovoArticolo.Prezzo = prezzo;
                }

                NuovoArticolo.Descrizione = descrizione;

                try
                {
                    _context.Articolis.Add(NuovoArticolo);

                    await _context.SaveChangesAsync();
                }catch(DbUpdateException ex)
                {
                    
                    if(ex.InnerException.ToString().Contains("Duplicate entry"))
                    {
                        return BadRequest("Duplicate Entry for Titolo" );
                    }
                    throw ex;
                }
                 

                // return _context.Articolis.Where(i => i.Titolo == NuovoArticolo.Titolo).FirstOrDefault();

                return CreatedAtAction(nameof(GetArticle), new { id = NuovoArticolo.Id }, NuovoArticolo);
            }
            
            }

        [HttpPost("addv2")] // articles/add in POST
        public async Task<ActionResult<Articoli>> AddArticoloFromJSONAsync([FromBody] Articoli articolo)
        {
            if (string.IsNullOrEmpty(articolo.Titolo))
            {
                return BadRequest("Missing titolo parameter.");
            }
            else
            {

                Articoli NuovoArticolo = new Articoli();
                NuovoArticolo.Id = articolo.Id;
                NuovoArticolo.Titolo = articolo.Titolo;
                if (articolo.Prezzo > 0)
                {
                    NuovoArticolo.Prezzo = articolo.Prezzo;
                }

                NuovoArticolo.Descrizione = articolo.Descrizione;

                try
                {
                    _context.Articolis.Add(NuovoArticolo);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {

                    if (ex.InnerException.ToString().Contains("Duplicate entry"))
                    {
                        return BadRequest("Duplicate Entry for Titolo");
                    }
                    throw ex;
                }


                // return _context.Articolis.Where(i => i.Titolo == NuovoArticolo.Titolo).FirstOrDefault();

                return CreatedAtAction(nameof(GetArticle), new { id = NuovoArticolo.Id }, NuovoArticolo);
            }
        }

            [HttpGet("show/{id}")] //show/5
        public async Task<ActionResult<Articoli>> GetArticle(int id)
        {
            var articolo = await _context.Articolis.FindAsync(id);

            if (articolo == null)
            {
                return NotFound();
            }

            return articolo;
        }

        [HttpGet("show")] // /show?tilolo= 
        public async Task<ActionResult<List<Articoli>>> show([FromQuery] string titolo = "", [FromQuery] string descrizione = "", [FromQuery] decimal prezzo = 0)
        {
            List<Articoli> result = null;
            //Filtri

            if (titolo != "")
            {
                result = await _context.Articolis.Where(i => i.Titolo.Contains(titolo)).ToListAsync();
            }

            if(descrizione != "")
            {

                 result = await _context.Articolis.Where(i => !string.IsNullOrEmpty(i.Descrizione)).Where(i=> i.Descrizione.Contains(descrizione)).ToListAsync();
            }

            if(prezzo != 0)
            {
                 result = await _context.Articolis.Where(i => i.Prezzo == prezzo).ToListAsync();
            }

            if( result == null)
            {
                result = await _context.Articolis.ToListAsync();
            }
            return result;
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Articoli>> PutTodoItem( int id,[FromQuery] string titolo= "", [FromQuery] string descrizione = "", [FromQuery] decimal prezzo = -1 )
        {
            

            var articolo = await _context.Articolis.FindAsync(id);

            if (articolo == null)
            {
                return NotFound();
            }
            if(titolo!= "")
            {
                articolo.Titolo = titolo;
            }
            if(descrizione != "")
            {
                articolo.Descrizione = descrizione;
            }
            if( prezzo > -1)
            {
                articolo.Prezzo = prezzo;
            }

            _context.Entry(articolo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Articolis.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return articolo;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Articoli>> DeleteTodoItem(int id)
        {
            var ArticoloDaEliminare = await _context.Articolis.FindAsync(id);
            if (ArticoloDaEliminare == null)
            {
                return NotFound();
            }

            _context.Articolis.Remove(ArticoloDaEliminare);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Articolis.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return ArticoloDaEliminare;
        }

    }
}
