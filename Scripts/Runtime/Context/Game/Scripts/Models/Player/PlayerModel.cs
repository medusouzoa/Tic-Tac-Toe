using Runtime.Context.Game.Scripts.Enum;
using UnityEngine;

namespace Runtime.Context.Game.Scripts.Models.Player
{
  public enum Result
  {
    None,
    Start,
    Same
  }

  public class PlayerModel : IPlayerModel
  {
    private Choice _p1Choice;
    private Choice _p2Choice;

    public void SetPlayer1Choice(Choice choice)
    {
      _p1Choice = choice;
      Debug.Log("set p1: " + _p1Choice);
    }

    public void SetPlayer2Choice(Choice choice)
    {
      _p2Choice = choice;
      Debug.Log("set p2: " + _p2Choice);
    }

    public Choice GetPlayer1Choice()
    {
      return _p1Choice;
    }

    public Choice GetPlayer2Choice()
    {
      return _p2Choice;
    }

    public Result CheckStart()
    {
      if (_p1Choice == Choice.O && _p2Choice == Choice.O || _p1Choice == Choice.X && _p2Choice == Choice.X)
      {
        return Result.Same;
      }

      if (_p1Choice != Choice.O && _p1Choice != Choice.X || _p2Choice != Choice.O && _p2Choice != Choice.X)
      {
        return Result.None;
      }

      return Result.Start;
    }
  }
}