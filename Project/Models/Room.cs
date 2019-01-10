using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public bool Gameover { get; set; }
    public bool LockedRoom { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public Room(string name, string description, bool gameover = false, bool lockedroom = false)
    {
      Name = name;
      Description = description;
      Gameover = gameover;
      LockedRoom = lockedroom;
      Exits = new Dictionary<string, IRoom>();
      Items = new List<Item>();
    }

    public Item TakeItem(string itemName)
    {
      Item myitem = Items.Find(item => item.Name == itemName);
      Items.Remove(myitem);
      return myitem;
    }

    public void PrintItems()
    {
      if (Items.Count > 0)
      {
        Items.ForEach(item =>
        {
          System.Console.WriteLine($"\n{item.Name} -- {item.Description}");
        });
      }
      else
      {
        System.Console.WriteLine("you want no items in this room");
      }
    }

    public Item UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}