﻿using Runtime.Context.Game.Scripts.Enum;
using UnityEngine;

namespace Runtime.Context.Game.Scripts.Models.Layer
{
  public interface ILayerModel
  {
    void AddLayer(Layers key, Transform value);
    Transform GetLayer(Layers key);
  }
}