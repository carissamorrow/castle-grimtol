using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    // private string Name;

    public GameService(Player player)
    {
      // Name = name;
      CurrentPlayer = player;
      Commands = new Dictionary<string, string>();
      Directions = new List<string>();
    }

    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Playing { get; set; }
    public Dictionary<string, string> Commands { get; set; }
    public List<string> Directions { get; set; }

    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower();
      string command = input;
      string userOption = "";
      //switch statement for actions
      switch (command)
      {
        case "go":
          Go(userOption);
          break;

        case "use":
          UseItem(userOption);
          break;

        case "take":
          TakeItem(userOption);
          break;

        case "look":
          Look();
          break;

        case "inventory":
          Inventory();
          break;

        case "help":
          Help();
          break;

        case "quit":
          Quit();
          break;

      }
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
      System.Console.WriteLine("Do You Want to play again?  y/n ");
      string response = Console.ReadLine().ToLower();
      if ((response == "y" || response == "yes")
      {
        Reset();
      }
      else
      {
        System.Console.WriteLine("Fine, Quit. Go Back To Your Old Life Then");
      }
    }

    public void Reset()
    {
      //reset the game 
      Setup();
    }

    public void Setup()
    {
      Commands = new Dictionary<string, string>();
      Directions = new List<string>();
      Playing = true;

      //build rooms
      Room Hallway = new Room("Hallway", "You are in the hallway. So many choices for your new life but how do you choose? Be very careful, some choices seem obvious and better than others but this is your new life so choose wisely. Which way will you go?");

      Room Career = new Room("Career", "You are in the career room. Seems bright at first but dims as the day goes on…not enough coffee to save you. You see a small door to the north and to the south, the East and West doors are locked. Which door will you choose to continue?...");

      Room Family = new Room("Family Room", "You are in the Family Room. Children running everywhere, cereal on the floor and giggles fill the air. You are pleasantly happy and stressed all at the same time. There are doors all around you but the South and North door is locked, where will you retreat?...");

      Room Worldtravel = new Room("World Traveler", "You are a World Traveler. You are sitting in a café in Italy, violins are playing in the background and you have the whole day ahead of you with no plans. A young couple to your right are having a loud conversation. You see the door to the West....");

      Room Random = new Room("Random Room", "You are in a room of endless opportunities. Good things may happen, bad things may happen. Life will decide your fate");

      //exits to rooms
      Hallway.Exits.Add("North", Family);
      Hallway.Exits.Add("South", Random);
      Hallway.Exits.Add("East", Career);
      Hallway.Exits.Add("West", Worldtravel);
      Random.Exits.Add("North", Career);
      Random.Exits.Add("West", Worldtravel);
      Family.Exits.Add("East", Career);
      Family.Exits.Add("West", Random);
      Career.Exits.Add("North", Family);
      Career.Exits.Add("South", Random);
      Worldtravel.Exits.Add("West", Family);
      Worldtravel.Exits.Add("South", Career);


      //directions
      Directions.Add("North");
      Directions.Add("South");
      Directions.Add("East");
      Directions.Add("West");

      //commands
      Commands.Add("Go", "<direction>");
      Commands.Add("Use", "<ItemName>");
      Commands.Add("Take", "<ItemName>");
      Commands.Add("Look", "");
      Commands.Add("Inventory", "");
      Commands.Add("Help", "");
      Commands.Add("Quit", "");

      //items
      Item key = new Item("key", "on the floor is a key that will unlock your future dream, or nightmare");
      Item bonus = new Item("bonus check", "next to you is a bonus check, is it worth anything??");
      Item car = new Item("minivan", "wow it's a minivan! You need this for all of your kids");
      Item map = new Item("map", "near you is a map that may help your journey, if you can trust it...");

      //items to rooms
      Random.Items.Add(key);
      Career.Items.Add(bonus);
      Family.Items.Add(car);
      Worldtravel.Items.Add(map);

      //start player in hallway to start the game
      System.Console.WriteLine("Thank you for playing! You are starting the game in the Hallway of your new life with an option in every direction. Choose Wisely and Enjoy the Game...");
      CurrentRoom = Hallway;
      Look();
    }

    public void StartGame()
    {
      Setup();
      while (Playing)
      {
        System.Console.Write($"\n What will your next move be {CurrentPlayer.PlayerName}?");
        GetUserInput();
        Playing = true;
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