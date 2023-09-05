using Runtime.Context.Game.Scripts.Command;
using Runtime.Context.Game.Scripts.Models.Layer;
using Runtime.Context.Game.Scripts.Models.Panel;
using Runtime.Context.Game.Scripts.Models.Player;
using Runtime.Context.Game.Scripts.View.Layer;
using Runtime.Context.Game.Scripts.View.Welcome;
using Runtime.Context.Game.Scripts.View.XoButton;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Runtime.Context.Game.Scripts.Config
{
  public class GameContext : MVCSContext
  {
    public GameContext(MonoBehaviour view) : base(view)
    {
      //constructor
    }

    protected override void mapBindings()
    {
      base.mapBindings();

      injectionBinder.Bind<IPanelModel>().To<PanelModel>().ToSingleton();
      injectionBinder.Bind<ILayerModel>().To<LayerModel>().ToSingleton();
      injectionBinder.Bind<IPlayerModel>().To<PlayerModel>().ToSingleton();

      mediationBinder.Bind<LayerView>().To<LayerMediator>();
      mediationBinder.Bind<XoButtonView>().To<XoButtonMediator>();
      mediationBinder.Bind<WelcomePanelView>().To<WelcomePanelMediator>();

      commandBinder.Bind(ContextEvent.START).To<InitGameCommand>();
    }
  }
}