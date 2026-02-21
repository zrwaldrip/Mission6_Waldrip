using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(NewMovie newMovie)
    {
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        
        return View("Confirmation", newMovie);
    }

    [HttpGet]
    public IActionResult ViewMovies()
    {
        var movies = _context.Movies.ToList();
        ViewBag.Categories = _context.Categories.ToList();

        return View(movies);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}