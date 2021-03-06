using Microsoft.AspNetCore.Mvc;
using TravelMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Text;

namespace TravelMVC.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly TravelMVCContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public ReviewsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TravelMVCContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public ActionResult Index()
    {
        IEnumerable<Review> reviews = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            //HTTP GET
            var responseTask = client.GetAsync("reviews");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Review>>();
                readTask.Wait();

                reviews = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                reviews = Enumerable.Empty<Review>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
        }
        return View(reviews);
    }

    public ActionResult Create()
    {
      IEnumerable<Destination> destinations = null;

      using (var client = new HttpClient())
      {
          client.BaseAddress = new Uri("http://localhost:5000/api/");
          //HTTP GET
          var responseTask = client.GetAsync("destinations");
          responseTask.Wait();

          var result = responseTask.Result;
          if (result.IsSuccessStatusCode)
          {
              var readTask = result.Content.ReadAsAsync<IList<Destination>>();
              readTask.Wait();

              destinations = readTask.Result;
          }
          else //web api sent error response 
          {
              //log response status here..

              destinations = Enumerable.Empty<Destination>();

              ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
          }
      }
      ViewBag.DestinationId = new SelectList(destinations, "DestinationId", "City");

      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Review review)
    {
      if (!ModelState.IsValid)
          return BadRequest("Not a valid model");

      Review newReview = new Review();
      using (var httpClient = new HttpClient())
      {
          StringContent content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");
  
          using (var response = await httpClient.PostAsync("http://localhost:5000/api/Reviews", content))
          {
              string apiResponse = await response.Content.ReadAsStringAsync();
              newReview = JsonConvert.DeserializeObject<Review>(apiResponse);
          }
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Review review = null;

      using (var client = new HttpClient())
      {
          client.BaseAddress = new Uri("http://localhost:5000/api/");
          //HTTP GET
          var responseTask = client.GetAsync("reviews/" + id);
          responseTask.Wait();

          var result = responseTask.Result;
          if (result.IsSuccessStatusCode)
          {
              var readTask = result.Content.ReadAsAsync<Review>();
              readTask.Wait();

              review = readTask.Result;
          }
          else //web api sent error response 
          {
              //log response status here..

              review = null;

              ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
          }
      }
      return View(review);
    }
    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
        Review review = new Review();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            using (var response = await httpClient.GetAsync("Reviews/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                review = JsonConvert.DeserializeObject<Review>(apiResponse);
            }
        }
        return View(review);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(Review review)
    {
        using (var httpClient = new HttpClient())
        {
    
            using (var response = await httpClient.PutAsJsonAsync<Review>("http://localhost:5000/api/Reviews/" + review.ReviewId, review))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Success";
            }
        }
        return RedirectToAction("Details", new {id = review.ReviewId});
    }
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        Review review = new Review();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            using (var response = await httpClient.GetAsync("Reviews/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                review = JsonConvert.DeserializeObject<Review>(apiResponse);
            }
        }
        return View(review);
    }
    [HttpPost, ActionName("Delete")]
    public async Task <ActionResult> DeleteConfirmed(int id)
    {
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/Reviews/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        } 
        return RedirectToAction("Index");
    }

  }
}