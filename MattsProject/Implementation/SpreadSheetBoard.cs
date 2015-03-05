using MattsProject.Interface;

namespace MattsProject.Implementation
{
  public class SpreadSheetBoard : IBoardInterface
  {
    #region IBoardInterface Members
    public int GetMinIndex()
    {
      // Might not want a 0 index
      return 1;
    }

    public int GetMaxIndex()
    {
      // Limit to 26, so I don't have to deal with AA... etc.
      return 10;
    }

    public string GetBoardTitle()
    {
      return GetType().Name;
    }
    #endregion
  }
}
