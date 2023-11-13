using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Treat
{
  [Required(ErrorMessage="Name cannot be empty")]
  public string Name { get; set; }
  public int TreatId { get; set; }

  public List<FlavorTreat> JoinEntities{ get; set; }

}