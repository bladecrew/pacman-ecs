using Ecs.Components;
using Ecs.Components.Events;
using Leopotam.Ecs;

namespace Ecs.Systems
{
  public class DamageSystem : IEcsRunSystem
  {
    private EcsFilter<CollisionEvent> _eventFilter;
    private EcsFilter<PacmanComponent> _pacmanFilter;
    private EcsFilter<EnemyComponent> _enemiesFilter;

    public void Run()
    {
      foreach (var index in _eventFilter)
      {
        var target = _eventFilter.Get1(index).Target;
        var teaser = _eventFilter.Get1(index).Teaser;

        var pacmanECPair = _pacmanFilter.FirstOrDefault(x => x.Object == target);

        if (pacmanECPair == null)
          return;

        var enemyECPair = _enemiesFilter.FirstOrDefault(x => x.Object == teaser);

        if (enemyECPair == null)
          return;

        ref var pacmanComponent = ref pacmanECPair.Entity.Set<PacmanComponent>();

        pacmanComponent.Health = pacmanECPair.Component.Health - enemyECPair.Component.Damage;
      }
    }
  }
}