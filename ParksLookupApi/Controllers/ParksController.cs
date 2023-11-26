using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookupApi.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ParkLookupApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkLookupApiContext _db;

    public ParksController(ParkLookupApiContext db)
    {
      _db = db;
    }

    // GET api/parks
     [EnableCors("Policy1")]
    [HttpGet]
    public async Task<List<Park>> Get(string location, string name, string climate)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (climate != null)
      {
        query = query.Where(entry => entry.Climate == climate);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }
      

      return await query.ToListAsync();
    }

    // GET: api/Parks/5
     [EnableCors("Policy1")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // POST api/parks
     [EnableCors("Policy1")]
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

        // PUT: api/Parks/5

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}