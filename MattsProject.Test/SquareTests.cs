using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsProject;
using NUnit.Framework;

namespace MattsProject.Test
{
  [TestFixture]
  public class SquareTests
  {
    [Test]
    public void TestToString()
    {
      Square square = new Square(0, 0);
      Assert.AreEqual("I am square 0, 0", square.ToString());
    }

    [Test]
    public void TestNoNeighbors()
    {
      SquareList list = new SquareList();
      Square square = new Square(0, 0);
      list.Add(square);

      list.FindNeighbors(square);

      Assert.AreEqual("There is no square here", square.North.ToString());
      Assert.AreEqual("There is no square here", square.South.ToString());
      Assert.AreEqual("There is no square here", square.East.ToString());
      Assert.AreEqual("There is no square here", square.West.ToString());
    }

    [Test]
    public void TestNeighbors()
    {
      SquareList list = new SquareList();
      for (int row = 0; row < 3; row++)
      {
        for (int col = 0; col < 3; col++)
        {
          list.Add(new Square(row, col));
        }
      }
      list.FindAllNeighbors();

      Square centerSquare = list.FindSquare(1, 1);
      Assert.AreEqual(centerSquare.North.row, 0);
      Assert.AreEqual(centerSquare.South.row, 2);
      Assert.AreEqual(centerSquare.East.col, 2);
      Assert.AreEqual(centerSquare.West.col, 0);

    }

    [Test]
    public void TestRandomNeighbor()
    {
      // North, row -1 col same
      // South, row +1 col same
      // East, row same col +1
      // West, row same col -1
      SquareList list = new SquareList();
      for (int row = 0; row < 30; row++)
      {
        for (int col = 0; col < 30; col++)
        {
          list.Add(new Square(row, col));
        }
      }
      list.FindAllNeighbors();

      Square randomSquare = list.OrderBy(x => Guid.NewGuid()).First();

      // North
      Assert.AreEqual(randomSquare.col, randomSquare.North.col);
      Assert.AreEqual(randomSquare.row - 1, randomSquare.North.row);

      // South
      Assert.AreEqual(randomSquare.col, randomSquare.South.col);
      Assert.AreEqual(randomSquare.row + 1, randomSquare.South.row);

      // East
      Assert.AreEqual(randomSquare.col + 1, randomSquare.East.col);
      Assert.AreEqual(randomSquare.row, randomSquare.East.row);

      // West
      Assert.AreEqual(randomSquare.col - 1, randomSquare.West.col);
      Assert.AreEqual(randomSquare.row, randomSquare.West.row);

    }
  }
}
