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
  public class DestinationsController : Controller
  {
    private readonly TravelMVCContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public DestinationsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TravelMVCContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public ActionResult Index()
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
        return View(destinations);
    }
    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Destination destination)
    {
        if (!ModelState.IsValid)
            return BadRequest("Not a valid model");

        Destination newDestination = new Destination();
        destination.Rating = 0;
        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(destination), Encoding.UTF8, "application/json");
    
            using (var response = await httpClient.PostAsync("http://localhost:5000/api/Destinations", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                newDestination = JsonConvert.DeserializeObject<Destination>(apiResponse);
            }
        }
        return RedirectToAction("Index");

        // using (var ctx = new TravelAPIContext())
        // {
        //     ctx.Students.Add(new Student()
        //     {
        //         StudentID = student.Id,
        //         FirstName = student.FirstName,
        //         LastName = student.LastName
        //     });

        //     ctx.SaveChanges();
        // }

        // return Ok();
    }

    public ActionResult Details(int id)
    {
        Destination destination = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            //HTTP GET
            var responseTask = client.GetAsync("destinations/" + id);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Destination>();
                readTask.Wait();

                destination = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                destination = null;

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
        }

        
        return View(destination);
    }
    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
        Destination destination = new Destination();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            using (var response = await httpClient.GetAsync("Destinations/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                destination = JsonConvert.DeserializeObject<Destination>(apiResponse);
            }
        }
        return View(destination);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(Destination destination)
    {
        using (var httpClient = new HttpClient())
        {
    
            using (var response = await httpClient.PutAsJsonAsync<Destination>("http://localhost:5000/api/Destinations/" + destination.DestinationId, destination))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Success";
            }
        }
        return RedirectToAction("Details", new {id = destination.DestinationId});
    }

    [Authorize]
    public async Task<ActionResult> AddReview(int id)
    {
        
        Destination destination = new Destination();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            using (var response = await httpClient.GetAsync("Destinations/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                destination = JsonConvert.DeserializeObject<Destination>(apiResponse);
            }
        }
        ViewBag.Destination = destination;
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> AddReview(Review review, int id)
    {
        review.DestinationId = id;
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
        return RedirectToAction("Details", new {id = review.DestinationId});
    }
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        Destination destination = new Destination();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            using (var response = await httpClient.GetAsync("Destinations/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                destination = JsonConvert.DeserializeObject<Destination>(apiResponse);
            }
        }
        return View(destination);
    }
    [HttpPost, ActionName("Delete")]
    public async Task <ActionResult> DeleteConfirmed(int id)
    {
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/Destinations/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        } 
        return RedirectToAction("Index");
    }
    // [Authorize]
    // [HttpPost, ActionName("DeleteFlavor")]
    // public ActionResult DeleteFlavor(int joinId)
    // {
    //   var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
    //   _db.TreatFlavor.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Details", new {id = joinEntry.TreatId});
    // }
  }
}