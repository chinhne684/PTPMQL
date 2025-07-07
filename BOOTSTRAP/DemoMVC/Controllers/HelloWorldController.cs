using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        
            public IActionResult Index(){
            return View();
        }
        // GET: /HelloWorld/Welcome/
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
       
    }    
}
