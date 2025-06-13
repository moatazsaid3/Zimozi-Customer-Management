using System.Diagnostics;
using CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    public class HomeController : Controller
    {
      public IActionResult Index()
    {
        return RedirectToAction("Index", "Customer");
    }
    }
}
