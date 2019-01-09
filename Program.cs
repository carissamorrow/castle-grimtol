using System;
using System.Collections.Generic;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      System.Console.Write("\n Welcome to The Game of Your New Life!  What is your name?  ");
      string name = Console.ReadLine();
      Console.Write($"\n\n Are You ready to see your new life {name}?  ");
      string response = Console.ReadLine().ToLower();
      if (response == "y" || response == "yes")
      {
        GameService gameService = new GameService(name);
        gameService.StartGame();
      }
    }
  }
}
