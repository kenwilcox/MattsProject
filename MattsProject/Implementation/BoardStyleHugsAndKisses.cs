using System;
using MattsProject.Classes;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  class BoardStyleHugsAndKisses: IBoardStyle
  {
    private readonly Random _random;
    
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
          line += String.Format("{0}", GetXorO()) + "|";
        }
        Console.WriteLine(line);
      }
    }
    #endregion
  }
}
