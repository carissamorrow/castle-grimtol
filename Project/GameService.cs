using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private string Name;

    public GameService(string name)
    {
      Name = name;
    }

    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Playing { get; set; }
    public Dictionary<string, string> Commands { get; set; }
    public List<string> Directions { get; set; }

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
      System.Console.WriteLine("Fine, Quit. Go Back To Your Old Lift Then");
    }

    public void Reset()
    {

    }

    public void Setup()
    {
      Commands = new Dictionary<string, string>();
      Directions = new List<string>();
      Playing = true;

      //build rooms
      Room Hallway = new Room("Hallway", "You are in the hallway. So many choices for your new life but how do you choose? Be very careful, some choices seem obvious and better than others but this is your new life so choose wisely. Which way will you go?");

      Room Career = new Room("Career", "You are in the career room. Seems bright at first but dims as the day goes on…not enough coffee to save you. You see a small door to the north and to the east, the South door is locked. Which door will you choose to continue?...");

      Room Family = new Room("Family Room", "You are in the Family Room. Children running everywhere, cereal on the floor and giggles fill the air. You are pleasantly happy and stressed all at the same time. There are doors all around you but the South door is locked, will you retreat?...");

      Room Worldtravel = new Room("World Traveler", "You are a World Traveler. You are sitting in a café in Italy, violins are playing in the background and you have the whole day ahead of you with no plans. A young couple to your right are having a loud conversation. You see the door to the West....");

      Room Random = new Room("Random Room", "You are in a room of endless opportunities. Good things may happen, bad things may happen. You have doors all around you, do you take the chance and stay?...");
    }

    public void StartGame()
    {
      Setup();
      while (Playing)
      {
        System.Console.Write($"\n What will your next move be? {CurrentPlayer.PlayerName}? Go North, South, East, or West ");
        GetUserInput();
      }

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