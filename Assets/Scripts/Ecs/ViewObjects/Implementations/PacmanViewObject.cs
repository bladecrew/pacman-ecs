using System.Collections.Generic;
using Ecs.Components;
using Leopotam.Ecs;
using Model;
using UnityEngine;

namespace Ecs.ViewObjects.Implementations
{
  public class PacmanViewObject : ViewObject
  {
    [SerializeField]
    private float _speed;
    
    protected override void Inject(EcsWorld world)
    { 
      var entity = world.NewEntity();
      
      ref var mainComponent = ref entity.Set<PacmanComponent>();
      mainComponent.Object = gameObject;
      mainComponent.Pacman = new Pacman
      {
        Guns = new List<Gun>()
      };

      ref var movementComponent = ref entity.Set<MovementComponent>();
      movementComponent.Speed = _speed;
      movementComponent.Object = gameObject;
      movementComponent.Direction = Vector3.forward;
    }
  }
}