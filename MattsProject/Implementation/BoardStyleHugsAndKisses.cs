using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  class BoardStyleHugsAndKisses: IBoardStyle
  {
    private Random _random;
    
    public BoardStyleHugsAndKisses()
    {
      _random = new Random();
    }

    private string GetXorO()
    {
      return _random.Next(100)%2 == 0 ? "X" : "O";
    }

    #region IBoardStyle Members
    public void Draw(IBoardInterface board, SquareList list)
    {
      Console.WriteLine();
      Console.WriteLine(board.GetBoardTitle() + "| BoardStyleHugsAndKisses");
      for (int row = board.GetMinIndex(); row < board.GetMaxIndex(); row++)
      {
        string line = String.Empty;
        for (int col = board.GetMinIndex(); col < board.GetMaxIndex(); col++)
        {
          Square square = list.FindSquare(col, row);
          line += String.Format("{0}", GetXorO()) + "|";
        }
        Console.WriteLine(line);
      }
    }
    #endregion
  }
}
