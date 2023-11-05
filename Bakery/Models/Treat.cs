using System.Collections.Generic;

namespace Bakery.Models;

public class Treat
{
  public string Name { get; set; }
  public int TreatId { get; set; }

  public List<FlavorTreat> JoinEntities{ get; set; }

}