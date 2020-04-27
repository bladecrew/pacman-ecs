using Ecs.Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Ecs.Systems
{
  public class InputSystem : IEcsRunSystem
  {
    private EcsFilter<MovementComponent>.Exclude<EnemyComponent> _filter;

    private RaycastService _raycastService;

    public void Run()
    {
      if (!Input.anyKeyDown)
        return;

      foreach (var index in _filter)
      {
        ref var component = ref _filter.Get1(index);

        var possibleDirection = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
          possibleDirection = Vector3.forward;
        else if (Input.GetKey(KeyCode.S))
          possibleDirection = Vector3.back;
        else if (Input.GetKey(KeyCode.A))
          possibleDirection = Vector3.left;
        else if (Input.GetKey(KeyCode.D))
          possibleDirection = Vector3.right;

        var seeingObjects =
          _raycastService.SeeingPoints(component.Object.transform.position, new[] {possibleDirection});

        if (seeingObjects.Count == 0)
          continue;

        component.TargetDirection = seeingObjects[Random.Range(0, seeingObjects.Count)];
      }
    }
  }
}