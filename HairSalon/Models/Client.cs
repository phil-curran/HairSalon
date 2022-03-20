using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Item
  {
    public int ClientId { get; set; }
    public string Description { get; set; }
    public int StylistId { get; set; }
    public virtual Stylist stylist { get; set; }
  }
}