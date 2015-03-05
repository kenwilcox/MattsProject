using System;
using MattsProject.Classes;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  class BoardStyleHugsAndKisses : BaseBoardStyle, IBoardStyle
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

    protected override string GetCellValue(Square square)
    {
      return String.Format("{0}", GetXorO());
    }
  }
}
