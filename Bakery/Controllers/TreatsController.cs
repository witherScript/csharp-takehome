using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
  
  public class TreatsController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(BakeryContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;

    }

    public ActionResult Index()
    {
      List<Treat> treats = _db.Treats.ToList();
      return View(treats);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      if(!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        treat.User = currentUser;
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Treat trt = _db.Treats
                          .Include(trt => trt.JoinEntities)
                          .ThenInclude(join => join.Flavor)
                          .FirstOrDefault(trt => trt.TreatId == id);
      return View(trt);
    }

    public ActionResult Edit(int id)
    {
      Treat trt = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      return View(trt);
    }

    [HttpPost]
    public ActionResult Edit(Treat trt)
    {
      _db.Treats.Update(trt);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Treat trt = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      return View(trt);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat trt = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      _db.Treats.Remove(trt);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
      public ActionResult AddFlavor(int id)
    {
      Treat trt = _db.Treats.FirstOrDefault(trt => trt.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(trt);
    }

    [HttpPost]
    public ActionResult AddTechnology(Treat trt, int flavId)
    {
      #nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.FlavorId == flavId && join.TreatId == trt.TreatId));
      #nullable disable
      if(joinEntity == null && flavId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat { FlavorId = flavId, TreatId = trt.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = trt.TreatId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}