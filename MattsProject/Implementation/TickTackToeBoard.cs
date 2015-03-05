using MattsProject.Interface;

namespace MattsProject.Implementation
{
  public class TickTackToeBoard: IBoardInterface
  {
    #region IBoardInterface Members
    public int GetMinIndex()
    {
      return 0;
    }

    public int GetMaxIndex()
    {
      return 3;
    }

    public string GetBoardTitle()
    {
      return "Tic-Tac-Toe";
    }
    #endregion
  }
}
