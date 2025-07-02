using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;
public class PersionController:Controller


{
    public IActionResult Index()
    {
        return View();
    }

}