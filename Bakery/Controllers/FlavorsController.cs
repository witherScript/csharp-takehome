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

namespace EpiCodex.Controllers;
public class FlavorsController: Controller
{
  private readonly BakeryContext _db;
  public FlavorsController(BakeryContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    return View(_db.Flavors.ToList());
  }

  public ActionResult Details(int id)
  {
    Flavor thisFlavor = _db.Flavors.Include(flavor => flavor.JoinEntities).ThenInclude(join => join.Treat)
                  .FirstOrDefault(flavor => flavor.FlavorId == id);
    return View(thisFlavor);    
  }
  public ActionResult Create()
  {
    return View();
  }
  
  [HttpPost]
  public ActionResult Create(Flavor flavor)
  {
    _db.Flavors.Add(flavor);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Flavor thisFlavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
    return View(thisFlavor);
  }

  [HttpPost]
  public ActionResult Edit(Flavor flav)
  {
    _db.Flavors.Update(flav);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    Flavor flav = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
    return View(flav);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Flavor flav = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
    _db.Flavors.Remove(flav);
    _db.SaveChanges();
    return RedirectToAction("Index");
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