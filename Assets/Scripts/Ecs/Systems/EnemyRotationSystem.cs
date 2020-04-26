using System.Linq;
using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
  public class EnemyRotationSystem : IEcsRunSystem
  {
    private EcsFilter<CollisionEvent> _eventFilter;
    private EcsFilter<MovementComponent>.Exclude<PacmanComponent> _enemyFilter;
    private EcsFilter<RotationPointComponent> _rotationPointFilter;

    public void Run()
    {
      foreach (var index in _eventFilter)
      {
        var target = _eventFilter.Get1(index).Target;
        var teaser = _eventFilter.Get1(index).Teaser;

        foreach (var enemyIndex in _enemyFilter)
        {
          ref var enemyComponent = ref _enemyFilter.Get1(enemyIndex);

          if (enemyComponent.Object != target)
            continue;

          foreach (var rotationIndex in _rotationPointFilter)
          {
            var position = _rotationPointFilter.Get1(rotationIndex).Position;
            
            if(teaser.transform.position != position)
              continue;

            var directions = _rotationPointFilter.Get1(rotationIndex).Directions;

            enemyComponent.Direction = directions[Random.Range(0, directions.Count)];
          }
        }
      }
    }
  }
}