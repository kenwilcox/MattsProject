using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MattsProject.Classes;
using MattsProject.Interface;
using Microsoft.Practices.Unity;

namespace MattsProject
{
  class Program
  {
    static void Main()
    {
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
      Console.WriteLine("Boards: {0} - Styles: {1}", boards.Count(), styles.Count());

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
