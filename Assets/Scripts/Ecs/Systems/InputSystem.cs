using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
  public class InputSystem : IEcsRunSystem
  {
    private EcsFilter<MovementComponent>.Exclude<EnemyComponent> _filter;
    
    public void Run()
    {
      if (!Input.anyKeyDown)
        return;

      foreach (var index in _filter)
      {
        ref var component = ref _filter.Get1(index);

        if (Input.GetKeyDown(KeyCode.W))
          component.Direction = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.A))
          component.Direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
          component.Direction = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.S))
          component.Direction = Vector3.back;
      }
    }
  }
}