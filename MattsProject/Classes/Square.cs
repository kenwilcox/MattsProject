using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MattsProject
{
  public class Square
  {
    private static readonly Square Nas = new Square();

    private readonly string _message;

    public Square North { get; set; }
    public Square South { get; set; }
    public Square East { get; set; }
    public Square West { get; set; }

    public int Row { get; private set; }
    public int Col { get; private set; }

    public Square(int col, int row)
    {
      this.Row = row;
      this.Col = col;
      _message = String.Format("I am square {0}, {1}", Col, Row);
    }

    public Square(): this(-1, -1)
    {
      // Just need to replace message
      _message = "There is no square here";
    }

    public static Square Empty
    {
      get { return Nas; }
    }

    public void PrintNeighbors()
    {
      Console.WriteLine(this.ToString());
      Console.WriteLine("North: {0}", North.ToString());
      Console.WriteLine("South: {0}", South.ToString());
      Console.WriteLine("East : {0}", East.ToString());
      Console.WriteLine("West : {0}", West.ToString());
    }

    public override string ToString()
    {
      return _message;
    }
  }
}
