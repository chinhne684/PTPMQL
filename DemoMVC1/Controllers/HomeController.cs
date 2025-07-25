using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC1.Models;

namespace DemoMVC1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index3()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Index3(string FullName, string Address)
    {
        string strOutput = "Xin chào" + FullName + " đến từ" + Address;
        ViewBag.Message = strOutput;
        return View();
    }



// /fkfrfrfifekfofrhejkdnfbygfbfbduffenifbhdjnfhbdn
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
