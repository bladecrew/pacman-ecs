using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Ecs.Systems
{
  public class MovementSystem : IEcsRunSystem
  {
    private EcsFilter<MovementComponent> _filter;

    public void Run()
    {
      foreach (var index in _filter)
      {
        ref var component = ref _filter.Get1(index);
        
        if(component.TargetDirection == Vector3.zero)
          continue;

        var position = component.Object.transform.position;
        var targetPosition = component.TargetDirection;
        var releasedPosition = Vector3.MoveTowards(position, component.TargetDirection, Time.deltaTime);

        if (releasedPosition == targetPosition)
        {
          component.TargetDirection = Vector3.zero;
          continue;
        }

        component.Object.transform.position = releasedPosition;
      }
    }
  }
}