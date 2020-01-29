using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private TravelAPIContext _db;

    public ReviewsController(TravelAPIContext db)
    {
      _db = db;
    }

    // GET api/reviews
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string country, string city)
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
        return query.ToList();
    }

    // GET api/reviews/1
    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
    {
        return _db.Reviews.Include(review => review.Destination).FirstOrDefault(destination => destination.ReviewId == id);
    }

    //POST api/reviews
    [HttpPost]
    public void Post([FromBody] Review review)
    {
      List<Review> reviews = _db.Reviews.Where(rev => rev.DestinationId == review.DestinationId).ToList();
      double rating = review.Rating;
      int j = 1;
      foreach (Review rev in reviews)
      {
        rating += rev.Rating;
        j++;
      }
      Destination currentDestination =_db.Destinations.FirstOrDefault(dest => dest.DestinationId == review.DestinationId);
      currentDestination.Rating = rating/j;
      _db.Entry(currentDestination).State = EntityState.Modified;
      _db.Reviews.Add(review);
      _db.SaveChanges();
    }

    // PUT api/reviews/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
      review.ReviewId = id;

      List<Review> reviews = _db.Reviews.Where(rev => rev.DestinationId == review.DestinationId && rev.ReviewId != review.ReviewId).ToList();
      double rating = review.Rating;
      int j = 1;
      foreach (Review rev in reviews)
      {
        rating += rev.Rating;
        j++;
      }
      Destination currentDestination =_db.Destinations.FirstOrDefault(dest => dest.DestinationId == review.DestinationId);
      currentDestination.Rating = rating/j;
      _db.Entry(currentDestination).State = EntityState.Modified;
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/reviews/5
    [HttpDelete("{id}")]
    public void Delete(int id, string user_name)
    {
      var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id && entry.user_name == user_name);
      if (reviewToDelete != null)
      {
        _db.Reviews.Remove(reviewToDelete);
        _db.SaveChanges();
      }
    }

  }
}