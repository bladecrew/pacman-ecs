using Ecs.Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Ecs.Systems
{
  public class FindingDirectionSystem : IEcsRunSystem
  {
    private EcsFilter<MovementComponent>.Exclude<PacmanComponent> _filter;
    
    private RaycastService _raycastService;
    
    public void Run()
    {
      foreach (var index in _filter)
      {
        ref var component = ref _filter.Get1(index);

        if (component.TargetDirection != Vector3.zero) 
          continue;
        
        var seeingObjects = _raycastService.SeeingPoints(component.Object.transform.position);

        component.TargetDirection = seeingObjects[Random.Range(0, seeingObjects.Count)];
      }
    }
  }
}