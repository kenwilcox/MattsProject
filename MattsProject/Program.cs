using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MattsProject.Implementation;

namespace MattsProject
{
  class Program
  {
    static void Main(string[] args)
    {
      SquareList list = new SquareList();
      for (int row = 0; row < 8; row++)
      {
        for (int col = 0; col < 8; col++)
        {
          list.Add(new Square(row, col));
        }
      }
      list.FindAllNeighbors();

      // Each Square knows the neighbor
      // Pick a random square and print out neighbors
      // Write a unit test - Nunit
      // build a board with set rows and columns

      //Random rand = new Random();
      //Square randomSquare = list[rand.Next(list.Count)];

      // http://stackoverflow.com/questions/9449452/linq-order-by-random
      Square randomSquare = list.OrderBy(x => Guid.NewGuid()).First();
      randomSquare.PrintNeighbors();


      Board board = new Board(new TickTackToeBoard(), new BoardStyleHugsAndKisses());
      board.ShowBoard();

      Console.ReadKey();
    }
  }
}
