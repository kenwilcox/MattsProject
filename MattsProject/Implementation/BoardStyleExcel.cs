using System;
using MattsProject.Classes;
using MattsProject.Interface;

namespace MattsProject.Implementation
{
  class BoardStyleExcel : BaseBoardStyle, IBoardStyle
  {
    public string ColIndexToChar(int index)
    {
      if (index < 1 || index > 26) return index.ToString();
      char letter = (char)(index + 64);
      return letter.ToString();
    }

    protected override string GetCellValue(Square square)
    {
      return String.Format("{0}{1}", ColIndexToChar(square.Col), square.Row);
    }
  }
}
