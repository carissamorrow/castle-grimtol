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
    public bool UseCheck { get; private set; }
    public bool UseKey { get; private set; }
    public Item IsWinnable { get; private set; }
    public Item IsLosable { get; private set; }

    public void GetUserInput()
    {
      string[] input = Console.ReadLine().ToLower().Split(" ");
      string command = input[0];
      string userOption = "";
      if (input.Length > 1)
      {
        userOption = input[1];
      }
      switch (command)
      {
        case "go":
          Go(userOption);
          break;

        // case "go south":
        //   Go("south");
        //   break;

        // case "go east":
        //   Go("east");
        //   break;

        // case "go west":
        //   Go("west");
        //   break;

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

        default:
          System.Console.WriteLine("Not a Valid option");
          break;
      }
    }

    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction) && CurrentRoom.LockedRoom != true)
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        Look();
      }
      else if (CurrentRoom.LockedRoom)
      {
        System.Console.WriteLine("It's locked, I would use a key if you have it?");
      }
      else
      {
        System.Console.WriteLine("You can't go that way");
      }

    }

    public void Help()
    {
      System.Console.WriteLine("Here are your Choices:");
      System.Console.WriteLine(@"Go <East, West, North, South>, Use <item>, Take <item>, Quit, Inventory");
    }

    public void Inventory()
    {
      foreach (var item in CurrentPlayer.Inventory)
      {
        System.Console.WriteLine(item.Name);

      }
    }

    public void Look()
    {
      Console.WriteLine($"\n {CurrentRoom.Name}:  {CurrentRoom.Description}");
      CurrentRoom.PrintItems();
    }

    public void Quit()
    {
      System.Console.WriteLine("Do You Want to play again?  y/n ");
      string response = Console.ReadLine().ToLower();
      if ((response == "y" || response == "yes"))
      {
        Reset();
      }
      else
      {
        System.Console.WriteLine("Fine, Quit. Go Back To Your Old Life Then");
        Console.Clear();
      }
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

      Room Career = new Room("Career", "You are in the career room. Seems bright at first but dims as the day goes on…not enough coffee to save you. You see a small door to the north and to the south, the East and West doors are locked. Which door will you choose to continue?...");

      Room Family = new Room("Family Room", "You are in the Family Room. Children running everywhere, cereal on the floor and giggles fill the air. You are pleasantly happy and stressed all at the same time. There are doors all around you but the South and North door is locked, where will you retreat?...");

      Room Worldtravel = new Room("World Traveler", "You are a World Traveler. You are sitting in a café in Italy, violins are playing in the background and you have the whole day ahead of you with no plans. A young couple to your right are having a loud conversation. You see the door to the West....");

      Room Random = new Room("Random Room", "You are in a room of endless opportunities. Good things may happen, bad things may happen. Life will decide your fate");

      //exits to rooms
      Hallway.Exits.Add("north", Family);
      Hallway.Exits.Add("south", Random);
      Hallway.Exits.Add("east", Career);
      Hallway.Exits.Add("west", Worldtravel);
      Random.Exits.Add("north", Career);
      Random.Exits.Add("west", Worldtravel);
      Family.Exits.Add("east", Career);
      Family.Exits.Add("west", Random);
      Career.Exits.Add("north", Family);
      Career.Exits.Add("south", Random);
      Worldtravel.Exits.Add("west", Family);
      Worldtravel.Exits.Add("south", Career);


      //directions
      Directions.Add("north");
      Directions.Add("south");
      Directions.Add("east");
      Directions.Add("west");

      //commands
      Commands.Add("Go", "<direction>");
      Commands.Add("Use", "<ItemName>");
      Commands.Add("Take", "<ItemName>");
      Commands.Add("Look", "");
      Commands.Add("Inventory", "");
      Commands.Add("Help", "");
      Commands.Add("Quit", "");


      //items
      Item key = new Item("key", "on the floor is a key that will unlock your future dream, or nightmare", true);
      Item bonus = new Item("bonus", "next to you is a bonus check, is it worth anything??", false, true);
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
    public void LoseGame()
    {
      System.Console.WriteLine("Sorry for your loss, please play again soon");
      Reset();
    }
    public void WinGame()
    {
      System.Console.WriteLine("You won! Your New Life is better and a complete upgrade! What a catch you are!");
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.TakeItem(itemName);
      if (item == null)
      {
        Console.WriteLine($"\n Cannot take {itemName} from this room");
      }
      else
      {
        CurrentPlayer.Inventory.Add(item);
        Console.WriteLine($"\n {item.Name} is in your inventory!");
      }
    }

    public void UseItem(string itemName)
    {
      Item mycurrentitem = CurrentPlayer.Inventory.Find(item => item.Name == itemName);

      if (mycurrentitem == null)
      {
        Console.WriteLine($"\n Cannot use {itemName} in this room");
      }
      else
      {
        System.Console.WriteLine($"\n You used {itemName}");
      }

      if (mycurrentitem == IsLosable)
      {
        System.Console.WriteLine("Oh No you used all of your bonus check and you ran out of money. You can no longer live in your new life");
        LoseGame();
      }
      else if (mycurrentitem == IsWinnable)
      {
        System.Console.WriteLine("Good job! You have unlocked the secret to life!.....");
        WinGame();
      }
    }
  }
}
