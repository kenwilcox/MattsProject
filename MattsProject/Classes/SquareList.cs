using System.Collections.Generic;
using System.Linq;

namespace MattsProject.Classes
{
  public class SquareList : List<Square>
  {
    // Since the list knows all squares, ask it to find the neighbors
    public void FindNeighbors(Square square)
    {
      // North, row -1 col same
      // South, row +1 col same
      // East, row same col +1
      // West, row same col -1

      square.North = this.Where(s => s.Row == square.Row - 1 && s.Col == square.Col).DefaultIfEmpty(Square.Empty).First();
      square.South = this.Where(s => s.Row == square.Row + 1 && s.Col == square.Col).DefaultIfEmpty(Square.Empty).First();
      square.East = this.Where(s => s.Row == square.Row && s.Col == square.Col + 1).DefaultIfEmpty(Square.Empty).First();
      square.West = this.Where(s => s.Row == square.Row && s.Col == square.Col - 1).DefaultIfEmpty(Square.Empty).First();

    }

    public void FindAllNeighbors()
    {
      foreach(Square square in this)
        FindNeighbors(square);
    }

    public Square FindSquare(int col, int row)
    {
      return this.Where(s => s.Col == col && s.Row == row).DefaultIfEmpty(Square.Empty).First();
    }
  }
}
