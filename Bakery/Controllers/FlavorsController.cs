using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers;
public class FlavorsController: Controller
{
  private readonly BakeryContext _db;
  private readonly UserManager<ApplicationUser> _userManager;
  public FlavorsController(BakeryContext db, UserManager<ApplicationUser> usrmgr)
  {
    _db = db;
    _userManager = usrmgr;
  }
  public ActionResult Index()
  {
    return View(_db.Flavors.ToList());
  }

  public ActionResult AuthError()
  {
    return View();
  }

  public ActionResult Details(int id)
  {
    Flavor thisFlavor = _db.Flavors
                        .Include(flavor => flavor.JoinEntities)
                        .ThenInclude(join => join.Treat)
                        .FirstOrDefault(flavor => flavor.FlavorId == id);
    return View(thisFlavor);    
  }

  public async Task<ActionResult> Create()
  {
    string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    if(currentUser!=null)
    {
      return View();
    }
    else 
    {
      return RedirectToAction("AuthError");
    }
  }
  
  [HttpPost]
  public ActionResult Create(Flavor flavor)
  {
    _db.Flavors.Add(flavor);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }


  public async Task<ActionResult> Edit(int id)
  {
    string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    if(currentUser!=null)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
      return View(thisFlavor);
    }
    else 
    {
      return RedirectToAction("AuthError");
    }
    
  }

  [HttpPost]
  public ActionResult Edit(Flavor flav)
  {
    _db.Flavors.Update(flav);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }


  public async Task<ActionResult> Delete(int id)
  {
    string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    if(currentUser!=null)
    {
      Flavor flav = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
      return View(flav);
    }
    else 
    {
      return RedirectToAction("AuthError");
    }
    
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
  public async Task<ActionResult> DeleteJoin(int joinId)
  {
    string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    if(currentUser!=null)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    else 
    {
      return RedirectToAction("AuthError");
    }
    
  }

}