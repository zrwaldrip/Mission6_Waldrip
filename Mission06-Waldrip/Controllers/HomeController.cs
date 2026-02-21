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
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        
        return View("Confirmation", movie);
    }

    [HttpGet]
    public IActionResult ViewMovies()
    {
        var movies = _context.Movies.ToList();
        ViewBag.Categories = _context.Categories.ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("AddMovie", movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Single(x => x.MovieId == id);
        return View(movie);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}