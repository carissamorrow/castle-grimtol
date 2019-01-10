using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsWinnable { get; set; }
    public bool IsLosable { get; set; }
    public bool BrightenRoom { get; set; }

    public Item(string name, string description, bool winnable = false, bool losable = false, bool brighten = false)
    {
      Name = name;
      Description = description;
      IsWinnable = winnable;
      IsLosable = losable;
      BrightenRoom = brighten;

    }

  }
}