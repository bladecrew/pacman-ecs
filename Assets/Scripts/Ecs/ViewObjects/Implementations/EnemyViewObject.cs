using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.ViewObjects.Implementations
{
  public class EnemyViewObject : ViewObject
  {
    [SerializeField]
    private float _damage;

    [SerializeField]
    private float _speed;


    public override void Inject(EcsWorld world)
    {
      var entity = world.NewEntity();
      ref var enemyComponent = ref entity.Set<EnemyComponent>();
      enemyComponent.Damage = _damage;
      enemyComponent.Object = gameObject;

      ref var movementComponent = ref entity.Set<MovementComponent>();
      movementComponent.Direction = Vector3.forward;
      movementComponent.Object = gameObject;
      movementComponent.Speed = _speed;
    }
  }
}