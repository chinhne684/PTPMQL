using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC1.Models;
namespace DemoMVC1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /HelloWorld
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}