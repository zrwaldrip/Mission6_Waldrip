using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Waldrip.Models;

namespace Mission06_Waldrip.Controllers;

public class HomeController : Controller
{
    private NewMovieContext _context;
    public HomeController(NewMovieContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AddMovie() //Go to the add movie page with the categories
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie) //submit the new movie if they are valid inputs
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        
            return View("Confirmation", movie);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(movie);
        }
        
    }

    [HttpGet]
    public IActionResult ViewMovies() //Go to the view movies page
    {
        //using .Include to also grab the CategoryName information for each associated CategoryId
        var movies = _context.Movies.Include(x => x.Category).ToList();
        ViewBag.Categories = _context.Categories.ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id) //Going to the Add Movie page but with a specific movie to edit
    {
        var movie = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("AddMovie", movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie) // updating the movie if the information is valid
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View("AddMovie", movie);
        }
        
    }

    [HttpGet]
    public IActionResult Delete(int id) // going to the delete confirmation page
    {
        var movie = _context.Movies.Single(x => x.MovieId == id);
        return View(movie);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie) // deleting the movie if they confirm
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // ngl don't know what this is, it was already in here
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}