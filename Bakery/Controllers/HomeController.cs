using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;


namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
      public HomeController(UserManager<ApplicationUser> userManager, BakeryContext db)
      {
        _userManager = userManager;
        _db = db;
      }

    [HttpGet("/")]
    public ActionResult Index()
    {
      var model = new Dictionary<string, List<object>>
      {
        { "treats", _db.Treats.Cast<object>().ToList() },
        { "flavs", _db.Flavors.Cast<object>().ToList() }
      };
      return View(model);
    }
  }
}