using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MattsProject.Implementation;
using MattsProject.Interface;
using Microsoft.Practices.Unity;

namespace MattsProject
{
  class Program
  {
    static void Main(string[] args)
    {
      //SquareList list = new SquareList();
      //for (int row = 0; row < 8; row++)
      //{
      //  for (int col = 0; col < 8; col++)
      //  {
      //    list.Add(new Square(row, col));
      //  }
      //}
      //list.FindAllNeighbors();

      // Each Square knows the neighbor
      // Pick a random square and print out neighbors
      // Write a unit test - Nunit
      // build a board with set rows and columns

      //Random rand = new Random();
      //Square randomSquare = list[rand.Next(list.Count)];

      //// http://stackoverflow.com/questions/9449452/linq-order-by-random
      //Square randomSquare = list.OrderBy(x => Guid.NewGuid()).First();
      //randomSquare.PrintNeighbors();


      //Board board = new Board(new TickTackToeBoard(), new BoardStyleHugsAndKisses());
      //board.ShowBoard();

      // Now some fun - Using a random board and random board style draw some output
      // BUT we're going to be using unity for some DI goodness!
      Assembly me = Assembly.GetExecutingAssembly();
      List<Type> boards = new List<Type>();
      List<Type> styles = new List<Type>();

      foreach (Type type in me.GetTypes())
      {
        if (type.GetInterfaces().Contains(typeof (IBoardInterface)))
        {
          boards.Add(type);
        }
        else if (type.GetInterfaces().Contains(typeof (IBoardStyle)))
        {
          styles.Add(type);
        }
      }

      Console.WriteLine();
      Console.WriteLine(String.Format("Boards: {0} - Styles: {1}", boards.Count(), styles.Count()));

      Type randomBoard = boards.OrderBy(x => Guid.NewGuid()).First();
      Type randomStyle = styles.OrderBy(x => Guid.NewGuid()).First();

      var container = new UnityContainer();
      container.RegisterType(typeof (IBoardInterface), randomBoard);
      container.RegisterType(typeof (IBoardStyle), randomStyle);

      var obj = container.Resolve<Board>();
      obj.ShowBoard();
      
      Console.WriteLine();
      Square randomSquare = obj.GetRandomSquare();
      randomSquare.PrintNeighbors();

      Console.ReadKey();
    }
  }
}
