using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.ViewObjects.Implementations
{
  public class CoinViewObject : ViewObject
  {
    [SerializeField]
    private int _points;

    public override void Inject(EcsWorld world)
    {
      var entity = world.NewEntity();
      ref var component = ref entity.Set<CoinComponent>();
      component.Target = gameObject;
      component.Points = _points;
    }
  }
}