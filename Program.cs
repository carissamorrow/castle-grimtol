﻿using System;
using System.Collections.Generic;
using CastleGrimtol.Project;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();

      System.Console.Write("\n Welcome to The Game of Your New Life!  What is your name?  ");
      string name = Console.ReadLine();
      Console.Write($"\n\nAre You ready to see your new life {name}?  y/n  ");
      string response = Console.ReadLine().ToLower();
      if (response == "y" || response == "yes")
      {
        Player player = new Player(name);
        GameService gameService = new GameService(player);
        gameService.Setup();
        gameService.StartGame();
      }
      else if (response != "y" || response != "yes")
      {
        System.Console.WriteLine("That's too bad, come back when you are ready");
      }
    }
  }
}
