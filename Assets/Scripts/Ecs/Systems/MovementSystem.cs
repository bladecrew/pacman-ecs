using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
  public class MovementSystem : IEcsRunSystem
  {
    private EcsFilter<MovementComponent> _filter;
    
    public void Run()
    {
      foreach (var index in _filter)
      {
        var @object = _filter.Get1(index).Object;
        var speed = _filter.Get1(index).Speed;
        var direction = _filter.Get1(index).Direction;
        
        @object.transform.position += direction * (speed / 100 * Time.timeScale);
      }  
    }
  }
}