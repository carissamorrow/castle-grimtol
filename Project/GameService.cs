using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private string name;

    public GameService(string name)
    {
      this.name = name;
    }

    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {
      //console "go back to your old life then"
    }

    public void Reset()
    {

    }

    public void Setup()
    {

    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {
      //bonus check
    }

    public void UseItem(string itemName)
    {
      //bonus check 
    }
  }
}