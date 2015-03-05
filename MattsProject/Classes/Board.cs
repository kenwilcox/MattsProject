using System;
using System.Linq;
using MattsProject.Interface;

namespace MattsProject
{
  /// <summary>
  /// A Board is just a fancy wrapper to SquareList
  /// </summary>
  public class Board
  {
    private readonly IBoardInterface _board;
    private readonly IBoardStyle _style;
    private readonly SquareList _list;

    public Board(IBoardInterface board, IBoardStyle style)
    {
      _board = board;
      _style = style;

      _list = new SquareList();
      for (int row = _board.GetMinIndex(); row < _board.GetMaxIndex(); row++)
      {
        for (int col = _board.GetMinIndex(); col < _board.GetMaxIndex(); col++)
        {
          _list.Add(new Square(col, row));
        }
      }
      _list.FindAllNeighbors();
    }

    public void ShowBoard()
    {
      _style.Draw(_board, _list);
    }

    public Square GetRandomSquare()
    {
      return _list.OrderBy(x => Guid.NewGuid()).First();
    }
  }
}
