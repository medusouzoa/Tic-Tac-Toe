using Runtime.Context.Game.Scripts.Enum;
using Runtime.Context.Game.Scripts.Models.Layer;
using Runtime.Context.Game.Scripts.Models.Panel;
using Runtime.Context.Game.Scripts.Models.Player;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Runtime.Context.Game.Scripts.View.Welcome
{
  public enum WelcomePanelEvent
  {
    CheckAllDone,
  }
  public class WelcomePanelMediator : EventMediator
  {
   
    [Inject]
    public WelcomePanelView view { get; set; }

    [Inject]
    public IPlayerModel playerModel { get; set; }
    [Inject]
   public ILayerModel layerModel { get; set; }
   [Inject]
   public IPanelModel panelModel { get; set; }
    public override void OnRegister()
    {
      view.dispatcher.AddListener(WelcomePanelEvent.CheckAllDone, OnCheck);
    }

    private void OnCheck()
    {
      Result checkWin = playerModel.CheckStart();
      Debug.Log(checkWin);
      if (checkWin == Result.Start)
      {
        Transform parent = layerModel.GetLayer(Layers.InGameLayer);
        panelModel.LoadPanel("GamePanel", parent);
        GameObject obj = GameObject.Find("HudCanvas");
        Destroy(obj);
      }
    }

    public override void OnRemove()
    {
      view.dispatcher.RemoveListener(WelcomePanelEvent.CheckAllDone, OnCheck);
    }
  }
}