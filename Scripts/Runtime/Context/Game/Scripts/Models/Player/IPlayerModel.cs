using Runtime.Context.Game.Scripts.Enum;

namespace Runtime.Context.Game.Scripts.Models.Player
{
  public interface IPlayerModel
  {
    void SetPlayer1Choice(Choice choice);
    void SetPlayer2Choice(Choice choice);
    Choice GetPlayer1Choice();
    Choice GetPlayer2Choice();
    Result CheckStart();
  }
}