using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace DemoMVC1.Controllers
{
    public class PersonController : Controller
    {
        // GET: /HelloWorld
        public IActionResult Inname()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
    }
}