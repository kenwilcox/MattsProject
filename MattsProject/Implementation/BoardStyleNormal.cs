using System;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  public class BoardStyleNormal: IBoardStyle
  {
    #region IBoardStyle Members
    public void Draw(IBoardInterface board, SquareList list)
    {
      Console.WriteLine();
      Console.WriteLine(board.GetBoardTitle() + "| BoardStyleNormal");
      for (int row = board.GetMinIndex(); row < board.GetMaxIndex(); row++)
      {
        string line = String.Empty;
        for (int col = board.GetMinIndex(); col < board.GetMaxIndex(); col++)
        {
          Square square = list.FindSquare(col, row);
          line += String.Format("{0}, {1}", square.Col, square.Row) + "|";
        }
        Console.WriteLine(line);
      }
    }
    #endregion
  }
}
