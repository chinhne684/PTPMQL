using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC1.Models;
namespace DemoMVC1.Controllers
{
    public class HelloWorldController : Controller
    { 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            
            return View();
        } 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
