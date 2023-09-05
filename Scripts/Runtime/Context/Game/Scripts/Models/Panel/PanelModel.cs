using System;
using RSG;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Runtime.Context.Game.Scripts.Models.Panel
{
  public class PanelModel : IPanelModel
  {
    public IPromise LoadPanel(string key, Transform parent)
    {
      Promise promise = new();
      AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.InstantiateAsync(key, parent);
      asyncOperationHandle.Completed += handle =>
      {
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
          promise.Reject(new Exception("Panel Couldn't Created"));
        }
        else
        {
          promise.Resolve();
        }
      };
      return promise;
    }
  }
}