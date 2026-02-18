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

    public IActionResult Confirmation(NewMovie newMovie)
    {
        return View(newMovie);
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(NewMovie newMovie)
    {
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        
        return RedirectToAction("Confirmation", newMovie);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}