using Runtime.Context.Game.Scripts.Enum;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;


namespace Runtime.Context.Game.Scripts.View.XoButton
{
  public class XoButtonView : EventView
  {
    public Button button;
    public Player player;
    public Choice choice;
    public Button lockButton;

    public void OnChoiceSelected()
    {
      button.interactable = false;
      dispatcher.Dispatch(XoButtonEvent.Selected);
    }

    public void Check(Choice selected)
    {
      button.interactable = choice != selected;
    }
      
  }
}