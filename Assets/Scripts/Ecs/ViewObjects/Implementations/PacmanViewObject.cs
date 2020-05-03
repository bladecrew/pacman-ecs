using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.ViewObjects.Implementations
{
  public class PacmanViewObject : ViewObject
  {
    [SerializeField]
    private float _health = 3f;
    
    [SerializeField]
    private float _speed;
    
    protected override void Inject(EcsWorld world)
    { 
      var entity = world.NewEntity();
      
      ref var mainComponent = ref entity.Set<PacmanComponent>();
      mainComponent.Object = gameObject;
      mainComponent.Health = _health;
      mainComponent.Points = 0f;

      ref var movementComponent = ref entity.Set<MovementComponent>();
      movementComponent.Speed = _speed;
      movementComponent.Object = gameObject;
      movementComponent.Direction = Vector3.forward;
    }
  }
}