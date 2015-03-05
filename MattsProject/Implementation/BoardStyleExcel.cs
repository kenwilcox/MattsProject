using System;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  class BoardStyleExcel : IBoardStyle
  {
    public string ColIndexToChar(int index)
    {
      if (index < 1 || index > 26) return index.ToString();
      char letter = (char)(index + 64);
      return letter.ToString();
    }

    #region IBoardStyle Members
    public void Draw(IBoardInterface board, SquareList list)
    {
      Console.WriteLine();
      Console.WriteLine(board.GetBoardTitle() + "| BoardStyleExcel");
      for (int row = board.GetMinIndex(); row < board.GetMaxIndex(); row++)
      {
        string line = String.Empty;
        for (int col = board.GetMinIndex(); col < board.GetMaxIndex(); col++)
        {
          Square square = list.FindSquare(col, row);
          line += String.Format("{0}{1}", ColIndexToChar(square.Col), square.Row) + "|";
        }
        Console.WriteLine(line);
      }
    }
    #endregion
  }
}
