using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Flavor
{
  public int FlavorId { get; set; }
  [Required(ErrorMessage="Name cannot be empty")]
  public string Name { get; set; }

  public List<FlavorTreat> JoinEntities { get; set; }
}