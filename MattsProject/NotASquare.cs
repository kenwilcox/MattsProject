using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattsProject
{
  /// <summary>
  /// Since I don't want any square to have null as a neighbor
  /// This class was created as a placeholder
  /// </summary>
  public class NotASquare: Square
  {
    public NotASquare() : base(-1, -1) { }
    public override string ToString()
    {
      return "There is no square here";
    }
  }
}
