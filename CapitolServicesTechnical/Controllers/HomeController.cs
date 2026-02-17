using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CapitolServicesTechnical.Models;
using CapitolServicesTechnical.Services.Interfaces;

namespace CapitolServicesTechnical.Controllers;

public class HomeController : Controller
{
    private readonly IFizzBuzzService _fizzBuzzService;

    public HomeController(IFizzBuzzService fizzBuzzService)
    {
        _fizzBuzzService = fizzBuzzService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> FizzBuzz()
    {
        var result = _fizzBuzzService.FizzBuzz();
        await _fizzBuzzService.SaveToDatabaseAsync();
        return Content(result, "text/plain");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
