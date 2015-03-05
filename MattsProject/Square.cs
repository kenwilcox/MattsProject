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
    public Square North { get; set; }
    public Square South { get; set; }
    public Square East { get; set; }
    public Square West { get; set; }

    public int row { get; set; }
    public int col { get; set; }

    public Square(int x, int y)
    {
      this.row = x;
      this.col = y;
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
      return String.Format("I am square {0}, {1}", col, row);
    }
  }
}
