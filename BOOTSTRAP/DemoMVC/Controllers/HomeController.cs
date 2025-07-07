using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using System.Net.Sockets;

namespace DemoMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
// PHẦN NHẬN YÊU CẦU
    public IActionResult Index()
    {
        return View();
    }
[HttpPost]
   public IActionResult Index (string FullName, string Address)
  {
    string strOutput = "Xin chào"+ FullName + "Đến từ"+ Address;
    ViewBag.Message = strOutput;
    return View();
}
}
