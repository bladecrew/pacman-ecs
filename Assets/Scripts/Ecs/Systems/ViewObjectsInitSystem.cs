using Ecs.ViewObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
  public class ViewObjectsInitSystem : IEcsInitSystem
  {
    private EcsWorld _world;
    
    public void Init()
    {
      var objects = Object.FindObjectsOfType<ViewObject>();
      foreach (var viewObject in objects)
        viewObject.Inject(_world);
    }
  }
}