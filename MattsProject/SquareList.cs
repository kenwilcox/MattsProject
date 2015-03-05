using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattsProject
{
  public class SquareList : List<Square>
  {
    private readonly NotASquare _nas = new NotASquare();

    // Since the list knows all squares, ask it to find the neighbors
    public void FindNeighbors(Square square)
    {
      // North, row -1 col same
      // South, row +1 col same
      // East, row same col +1
      // West, row same col -1

      square.North = this.Where(s => s.row == square.row - 1 && s.col == square.col).DefaultIfEmpty(_nas).First();
      square.South = this.Where(s => s.row == square.row + 1 && s.col == square.col).DefaultIfEmpty(_nas).First();
      square.East = this.Where(s => s.row == square.row && s.col == square.col + 1).DefaultIfEmpty(_nas).First();
      square.West = this.Where(s => s.row == square.row && s.col == square.col - 1).DefaultIfEmpty(_nas).First();

    }

    public void FindAllNeighbors()
    {
      foreach(Square square in this)
        FindNeighbors(square);
    }

    public Square FindSquare(int col, int row)
    {
      return this.Where(s => s.col == col && s.row == row).DefaultIfEmpty(_nas).First();
    }
  }
}
