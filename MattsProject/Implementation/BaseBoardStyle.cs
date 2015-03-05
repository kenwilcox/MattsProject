using System;
using MattsProject.Classes;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  /// <summary>
  /// Noticed I wasn't being very DRY
  /// </summary>
  public abstract class BaseBoardStyle : IBoardStyle
  {
    protected virtual string GetCellValue(Square square)
    {
      return String.Format("{0}, {1}", square.Col, square.Row);
    }

    #region IBoardStyle Members

    public void Draw(IBoardInterface board, SquareList list)
    {
      Console.WriteLine();
      Console.WriteLine(board.GetBoardTitle() + "| " + GetType().Name);
      for (int row = board.GetMinIndex(); row < board.GetMaxIndex(); row++)
      {
        string line = String.Empty;
        for (int col = board.GetMinIndex(); col < board.GetMaxIndex(); col++)
        {
          Square square = list.FindSquare(col, row);
          line += GetCellValue(square) + "|";
        }
        Console.WriteLine(line);
      }
    }

    #endregion
  }
}
