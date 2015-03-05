using System;
using System.Linq;
using MattsProject.Classes;
using NUnit.Framework;

namespace MattsProject.Test
{
  [TestFixture]
  public class SquareTests
  {
    /// <summary>
    /// Rationalization: Verify that the ToString is as expected
    /// </summary>
    [Test]
    public void TestToString()
    {
      Square square = new Square(0, 0);
      Assert.AreEqual("I am square 0, 0", square.ToString());

      square = new Square(0, 1);
      Assert.AreEqual("I am square 0, 1", square.ToString());

      square = new Square(1, 0);
      Assert.AreEqual("I am square 1, 0", square.ToString());
    }

    /// <summary>
    /// Rationalization: Verify that the ToString is as expected for empty neighbors
    /// </summary>
    [Test]
    public void TestNoNeighborsToString()
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

    /// <summary>
    /// Rationalization: Verify that the neighbors are at the right location
    /// </summary>
    [Test]
    public void TestNeighbors()
    {
      // make a tic-tac-toe type grid
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
      
      // Col should be the same
      Assert.AreEqual(centerSquare.North.Col, 1);
      Assert.AreEqual(centerSquare.South.Col, 1);
      
      // But Row should be different
      Assert.AreEqual(centerSquare.North.Row, 0);
      Assert.AreEqual(centerSquare.South.Row, 2);
      
      // Row should be the same
      Assert.AreEqual(centerSquare.East.Row, 1);
      Assert.AreEqual(centerSquare.West.Row, 1);
      
      // But Col should be different
      Assert.AreEqual(centerSquare.East.Col, 2);
      Assert.AreEqual(centerSquare.West.Col, 0);

    }

    /// <summary>
    /// Rationalization: Any random square should have the neighbor in the right location
    /// </summary>
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

      // Get a random square
      Square randomSquare = list.OrderBy(x => Guid.NewGuid()).First();

      // Neighboring squares can be Empty, don't want to assert if that's the case
      // We have another test case for that check

      // North
      if (randomSquare.North != Square.Empty)
      {
        Assert.AreEqual(randomSquare.Col, randomSquare.North.Col);
        Assert.AreEqual(randomSquare.Row - 1, randomSquare.North.Row);
      }

      // South
      if (randomSquare.South != Square.Empty)
      {
        Assert.AreEqual(randomSquare.Col, randomSquare.South.Col);
        Assert.AreEqual(randomSquare.Row + 1, randomSquare.South.Row);
      }

      // East
      if (randomSquare.East != Square.Empty)
      {
        Assert.AreEqual(randomSquare.Col + 1, randomSquare.East.Col);
        Assert.AreEqual(randomSquare.Row, randomSquare.East.Row);
      }

      // West
      if (randomSquare.West != Square.Empty)
      {
        Assert.AreEqual(randomSquare.Col - 1, randomSquare.West.Col);
        Assert.AreEqual(randomSquare.Row, randomSquare.West.Row);
      }
    }

    /// <summary>
    /// Rationalization: A list with one square should only have empty neighbors
    /// </summary>
    [Test]
    public void TestNeighborsShouldBeEmpty()
    {
      SquareList list = new SquareList() {new Square(0, 0)};
      list.FindAllNeighbors();
      Square testSquare = list[0];

      Assert.AreEqual(testSquare.North, Square.Empty);
      Assert.AreEqual(testSquare.South, Square.Empty);
      Assert.AreEqual(testSquare.East, Square.Empty);
      Assert.AreEqual(testSquare.West, Square.Empty);
    }
  }
}
