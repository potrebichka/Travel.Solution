using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TravelAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private TravelAPIContext _db;

    public DestinationsController(TravelAPIContext db)
    {
      _db = db;
    }

    // GET api/destinations
    [HttpGet]
    public ActionResult<IEnumerable<Destination>> Get(string country, string city)
    {
      var query = _db.Reviews.Include(review => review.Destination).AsQueryable();
      if (country != null)
      {
        query = query.Where(entry => entry.Destination.Country == country);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.Destination.City == city);
      }
      return _db.Destinations.Include(destination => destination.Reviews).OrderByDescending(review => review.Rating).ToList();
    }

    // GET api/destinations/1
    [HttpGet("{id}")]
    public ActionResult<Destination> Get(int id)
    {
        return _db.Destinations.Include(destination => destination.Reviews).FirstOrDefault(destination => destination.DestinationId == id);
    }

    //POST api/destinations
    [HttpPost]
    public void Post([FromBody] Destination destination)
    {
      _db.Destinations.Add(destination);
      _db.SaveChanges();
    }

    // PUT api/destinations/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Destination destination)
    {
        destination.DestinationId = id;
        _db.Entry(destination).State = EntityState.Modified;
        _db.SaveChanges();
    }

    // DELETE api/destinations/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var destinationToDelete = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
      _db.Destinations.Remove(destinationToDelete);
      _db.SaveChanges();
    }

    // get random destination api/destinations/random
    [HttpGet("random")]
    public ActionResult<Destination> Random ()
    {
      List<Destination> destinations = _db.Destinations.ToList();
      var rnd = new Random();
      int rndIdx = rnd.Next(0,destinations.Count-1);
      return destinations[rndIdx];
    }
  }
}