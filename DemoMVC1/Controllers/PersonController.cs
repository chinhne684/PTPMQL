using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC1.Models;
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
        public IActionResult Bang()
        {
            return View();
        }


[HttpPost]

public IActionResult Bang (Person ps)
{
string strOutput = "Xin chao " + ps. PersonId + "-" + ps. FullName + "-" + ps.Address;
ViewBag.infoPerson = strOutput;
return View();
}
    }
}