using Runtime.Context.Game.Scripts.Enum;
using Runtime.Context.Game.Scripts.Models.Player;
using strange.extensions.mediation.impl;

namespace Runtime.Context.Game.Scripts.View.XoButton
{
  public enum XoButtonEvent
  {
    Selected
  }
  public enum LockButtonEvent
  {
    CheckAllDone,
  }

  public class XoButtonMediator : EventMediator
  {
    private GameEvent _eventType;

    [Inject]
    public XoButtonView view { get; set; }

    [Inject]
    public IPlayerModel playerModel { get; set; }

    public override void OnRegister()
    {
      view.dispatcher.AddListener(XoButtonEvent.Selected, OnSelected);
      _eventType = view.player == Player.P1 ? GameEvent.P1ChoiceSelected : GameEvent.P2ChoiceSelected;
      dispatcher.AddListener(_eventType, OnChoiceSelected);
      
    }
    
    private void OnSelected()
    {
      if (view.player == Player.P1)
      {
        playerModel.SetPlayer1Choice(view.choice);
      }
      else
      {
        playerModel.SetPlayer2Choice(view.choice);
      }

      dispatcher.Dispatch(_eventType);
    }
    private void OnChoiceSelected()
    {
      Choice selected = view.player == Player.P1 ? playerModel.GetPlayer1Choice() : playerModel.GetPlayer2Choice();

      view.Check(selected);
    }

    public override void OnRemove()
    {
      view.dispatcher.RemoveListener(XoButtonEvent.Selected, OnSelected);
      dispatcher.RemoveListener(_eventType, OnChoiceSelected);
    }
  }
}